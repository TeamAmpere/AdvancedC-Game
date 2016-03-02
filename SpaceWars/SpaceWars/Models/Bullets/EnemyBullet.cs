namespace SpaceWars.Models.Bullets
{
    using Microsoft.Xna.Framework;

    using SpaceWars.Core.Managers;
    using SpaceWars.GameObjects;
    using SpaceWars.Interfaces;
    using SpaceWars.Model;

    public abstract class EnemyBullet : GameObject, IBullet
    {
        //private static readonly Vector2 UP = new Vector2(0, -30);
        private const int LeftCorner = 0;
        private const int RightCorner = 800;
        private const int UpCorner = 0;
        private const int DownCorner = 1000;


        protected EnemyBullet(Vector2 position, Vector2 speed, int damage)
        {
            this.Damage = damage;
            this.Speed = speed;
            this.Position = position;
            this.BoundingBox = new Rectangle((int)position.X,(int)position.Y, 64, 64);
        }

        public int Damage { get; protected set; }

        public override void Intersect(IGameObject obj)
         {
            if (obj is Player)
            {
                var player = (Player)obj;
                player.TakeDMG(this.Damage);
                this.Owner.RemoveObject(this);
            }
        }

        public override void LoadContent(ResourceManager resourceManager)
        {
            this.Texture = resourceManager.GetResource("laser");
        }

        public override void Think(GameTime gameTime)
        {
            bool needToRemove = false;

            if (this.Position.X < LeftCorner)
                needToRemove = true;
            if (this.Position.X > RightCorner)
                needToRemove = true;
            if (this.Position.Y > DownCorner)
                needToRemove = true;
            if (this.Position.Y < -130)
                needToRemove = true;

            if (needToRemove)
                this.Owner.RemoveObject(this);
        }

    }
}
  
