namespace SpaceWars.Model.Enemies.EnemyBullets
{
    using SpaceWars.GameObjects;
    using SpaceWars.Interfaces;
    using Microsoft.Xna.Framework;

    using SpaceWars.Core.Managers;

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
            Speed = speed;
            Position = position;
            BoundingBox = new Rectangle((int)position.X,(int)position.Y, 64, 64);
        }

        public int Damage { get; protected set; }

        public override void Intersect(IGameObject obj)
         {
            if (obj is Player)
            {
                var player = (Player)obj;
                player.TakeDMG(Damage);
                Owner.RemoveObject(this);
            }
        }

        public override void LoadContent(ResourceManager resourceManager)
        {
            Texture = resourceManager.GetResource("laser");
        }

        public override void Think(GameTime gameTime)
        {
            bool needToRemove = false;

            if (Position.X < LeftCorner)
                needToRemove = true;
            if (Position.X > RightCorner)
                needToRemove = true;
            if (Position.Y > DownCorner)
                needToRemove = true;
            if (Position.Y < UpCorner)
                needToRemove = true;

            if (needToRemove)
                Owner.RemoveObject(this);
        }

    }
}
  
