namespace SpaceWars.Models.Enemies.Bosses
{
    using System;

    using Microsoft.Win32;
    using Microsoft.Xna.Framework;
    using Microsoft.Xna.Framework.Graphics;

    using SpaceWars.Core.Managers;
    using SpaceWars.GameObjects;
    using SpaceWars.Interfaces;
    using SpaceWars.Model;
    using SpaceWars.Models.Bullets;
    using SpaceWars.Models.Enemies.Bosses.Behaviours;

    public class PurpleAlien : Enemy
    {
        private const int UpCorner = -131; // health bonus size
        private const int RightCorner = 800 - 100; // Screen width - health bonus width
        private const int DownCorner = 950 - 279; // Screen height - health bonus height
        private const int LeftCorner = 0;
        private const int InititHealth = 60;
        private const int oneSecond = 1000000;
        private const long tenSeconds = 10000000000;

        private static readonly Vector2 LEFT = new Vector2(-4, 0);
        private static readonly Vector2 RIGHT = new Vector2(4, 0);
        private readonly int ShootDelayConst;
        private int shootDelay;
        private const int scoringPoints = 0;
        private int changePossitionDelay = 20;
        private int shooted = 10;
        private Texture2D helthTexture;
        private Rectangle rectangle;
        private int angryCount = 80;

        private TimeSpan timer;

        private BossLaser bossLaser;

        public PurpleAlien(int shootDelayConst, Vector2 playerPosition)
        {
            this.timer = new TimeSpan(tenSeconds);
            Random rand = new Random();
            this.IsLaserLaunched = false;
            this.Position = new Vector2(rand.Next(LeftCorner, RightCorner), -50);
            this.Speed = new Vector2(0, 0);
            this.BoundingBox = new Rectangle((int)this.Position.X, (int)this.Position.Y, 100, 50);
            this.ShootDelayConst = shootDelayConst;
            this.shootDelay = shootDelayConst;
            this.ScoringPoints = scoringPoints;
            this.Health = InititHealth;
        }

        public int Health { get; set; }

        public bool IsLaserLaunched { get; set; }

        public override void OnGetEnemy(IGameObject obj)
        {
            if (obj.GetType() == typeof(Player))
            {

                Player player = (Player)obj;

                player.TakeDMG(+100);

                this.Owner.RemoveObject(this);
            }
        }

        public override void Shoot()
        {
            if (this.shootDelay > 0)
            {
                this.shootDelay--;
            }
            else
            {
                int bulletX = (int)Position.X + 22; //22 because half of the texture width - bullet width

                    var behaviour = new PurpleAlienBehaviour(this);
                    var bullet = behaviour.ManageBehaviour(this.Health);
                    this.Owner.AddObject(bullet);
                    if (bullet is BossLaser)
                    {
                        this.bossLaser = (BossLaser)bullet;
                    }

                this.shootDelay = this.ShootDelayConst;
            }
        }

        public override void Think(GameTime gameTime)
        {
            GetAlienPosition = Position;
            this.rectangle = new Rectangle(50, 75, this.Health * 7, 20);
            this.Shoot();
            if (Player.GetPlayerPosition.X > this.Position.X)
            {
                this.Position += RIGHT;
            }
            else
            {
                this.Position += LEFT;
            }

            if (this.IsLaserLaunched)
            {

                if (this.timer.Seconds == 0)
                {
                    this.IsLaserLaunched = false;
                    this.timer = new TimeSpan(tenSeconds);
                }

                else
                {
                    this.timer -= new TimeSpan(oneSecond);
                }

            }

            //if (this.Health < 50)
            //{
            //    this.shootDelay += 20;
            //}
        }

        public override void Intersect(IGameObject obj)
        {
            OnGetEnemy(obj);
            if (obj.GetType() == typeof(Bullet))
            {
                var bullet = (Bullet)obj;
                this.shooted--;
                if (this.shooted < 0)
                {
                    this.Health -= 2;
                    Owner.RemoveObject(bullet);
                    this.shooted = 10;
                }

                if (this.Health <= 0)
                {
                    this.NeedToRemove = true;
                    Owner.RemoveObject(this.bossLaser);
                    this.ScoringPoints = 100;
                }
            }
        }

        public override void LoadContent(ResourceManager resourceManager)
        {
            this.Texture = resourceManager.GetResource("purpleAlien");
            this.helthTexture = resourceManager.GetResource("healthBar");
        }

        public override void Draw(SpriteBatch spriteBatch)
        {
            base.Draw(spriteBatch);
            spriteBatch.Draw(helthTexture, this.rectangle, Color.White);

        }

        public static Vector2 GetAlienPosition { get; private set; }
    }
}
