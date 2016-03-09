namespace SpaceWars.Models.Bullets
{
    using Microsoft.Xna.Framework;

    using SpaceWars.Core.Managers;
    using SpaceWars.GameObjects;
    using SpaceWars.Interfaces;
    using SpaceWars.Models.Enemies.Bosses;

    public class BossLaser : EnemyBullet
    {
        private const int laserDamage = 80;
        private static readonly Vector2 DOWN = new Vector2(0, 10);

        private Rectangle size;

        private Vector2 origin;

        private Vector2 alienPosition;

        public BossLaser(Vector2 position, Vector2 speed)
            : base(position, speed, laserDamage)
        {
            this.Position = position + new Vector2(15, 200);
        }

        public override void Intersect(IGameObject obj)
        {
            if (obj is Player)
            {
                var player = (Player)obj;
                player.TakeDMG(laserDamage);
            }
        }

        public override void LoadContent(ResourceManager resourceManager)
        {
            this.Texture = resourceManager.GetResource("purpleBullet");
        }

        public override void Think(GameTime gameTime)
        {
            this.BoundingBox = new Rectangle((int)this.Position.X, (int)this.Position.Y, this.Texture.Width - 20, this.Texture.Height);
        }
    }
}
