namespace SpaceWars.Model.Enemies.EnemyBullets
{
    using Microsoft.Xna.Framework;

    using SpaceWars.Core.Managers;

    public class LittleEnemyBullet : EnemyBullet
    {
        private static readonly Vector2 DOWN = new Vector2(0, +10);
        private new const int Damage = 30;

        public LittleEnemyBullet(Vector2 position)
            : base(position, DOWN, Damage)
        {
        }

        public override void LoadContent(ResourceManager resourceManager)
        {
            Texture = resourceManager.GetResource("smallEnemyBullet");
        }

    }
}
