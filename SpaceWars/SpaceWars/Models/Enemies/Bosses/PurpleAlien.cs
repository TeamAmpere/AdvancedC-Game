namespace SpaceWars.Models.Enemies.Bosses
{
    using System;

    using Microsoft.Xna.Framework;

    using SpaceWars.Core.Managers;
    using SpaceWars.GameObjects;
    using SpaceWars.Interfaces;
    using SpaceWars.Model;
    using SpaceWars.Models.Bullets;

    public class PurpleAlien : Enemy
    {
        private const int UpCorner = -131; // health bonus size
        private const int RightCorner = 800 - 100; // Screen width - health bonus width
        private const int DownCorner = 950 - 279; // Screen height - health bonus height
        private const int LeftCorner = 0;
        private readonly int ShootDelayConst;
        private int shootDelay;
        private const int scoringPoints = 3;


        public PurpleAlien(int shootDelayConst)
        {
            Random rand = new Random();

            this.Position = new Vector2(rand.Next(LeftCorner, RightCorner), -50);
            this.Speed = new Vector2(0, 0);

            this.BoundingBox = new Rectangle((int)this.Position.X, (int)this.Position.Y, 100, 50);
            this.ShootDelayConst = shootDelayConst;
            this.shootDelay = shootDelayConst;
        }

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
                int bulletX = (int)this.Position.X + 22; //22 because half of the texture width - bullet width
                this.Owner.AddObject(new AlienRocket(new Vector2(bulletX, this.Position.Y)));
                this.shootDelay = this.ShootDelayConst;
            }
        }

        public override void LoadContent(ResourceManager resourceManager)
        {
            this.Texture = resourceManager.GetResource("purpleAlien");
        }

        public override void Think(GameTime gameTime)
        {
            this.Shoot();
        }
    }
}
