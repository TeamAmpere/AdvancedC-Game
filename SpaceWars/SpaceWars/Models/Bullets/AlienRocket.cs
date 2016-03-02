namespace SpaceWars.Models.Bullets
{
    using Microsoft.Xna.Framework;

    using SpaceWars.Core.Managers;

    public class AlienRocket : EnemyBullet
    {
        private static readonly Vector2 DOWN = new Vector2(0, +10);
        private new const int Damage = 100;

        public AlienRocket(Vector2 position)
            : base(position, DOWN, Damage)
        {
        }

        public override void LoadContent(ResourceManager resourceManager)
        {
            this.Texture = resourceManager.GetResource("alienRocket");
        }
    }
}
