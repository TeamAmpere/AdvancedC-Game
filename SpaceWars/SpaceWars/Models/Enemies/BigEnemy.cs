namespace SpaceWars.Model
{
    using System;
    using Microsoft.Xna.Framework;
    using SpaceWars.GameObjects;
    using SpaceWars.Interfaces;
    using SpaceWars.Model.Enemies.EnemyBullets;

    public class BigEnemy: Enemy
    {
        private const int UpCorner = -131; // health bonus size
        private const int RightCorner = 800 - 100; // Screen width - health bonus width
        private const int DownCorner = 950 - 279; // Screen height - health bonus height
        private const int LeftCorner = 0;
        private const int ShootDelayConst = 40;
        private const int scoringPoints = 3;
        private int shootDelay = 0;


        public BigEnemy()
        {
            Random rand = new Random();

            Position = new Vector2(rand.Next(LeftCorner, RightCorner), UpCorner);
            this.Speed = new Vector2(0, 2);

            this.BoundingBox = new Rectangle((int)Position.X, (int)Position.Y, 100, 131);
        }

        public override void OnGetEnemy(IGameObject obj)
        {
            if (obj.GetType() == typeof(Player))
            {
                Player player = (Player)obj;

                player.TakeDMG(+100);

                Owner.RemoveObject(this);
            }
        }

        public override void Shoot()
        {
            if (shootDelay > 0)
            {
                shootDelay--;
            }
            else
            {
                int bulletX = (int)this.Position.X + 22; //22 because half of the texture width - bullet width
                Owner.AddObject(new BigEnemyBullet(new Vector2(bulletX, this.Position.Y)));

                shootDelay = ShootDelayConst;
            }
        }

        public override void LoadContent(ResourceManager resourceManager)
        {
            Texture = resourceManager.GetResource("bigEnemy");
        }

        public override void Think(GameTime gameTime)
        {
            Shoot();
        }
    }
}
