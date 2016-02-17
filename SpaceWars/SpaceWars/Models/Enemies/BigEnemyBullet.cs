namespace SpaceWars.Model.Enemies.EnemyBullets
{
    using Microsoft.Xna.Framework;
   
    public class BigEnemyBullet : EnemyBullet
    {
        private static readonly Vector2 DOWN = new Vector2(0, +10);
        private new const int Damage = 50;

        public BigEnemyBullet(Vector2 position)
            : base(position, DOWN, Damage)
        {
        }

        public override void LoadContent(ResourceManager resourceManager)
        {
            Texture = resourceManager.GetResource("bigEnemyBullet");
        }
    }
}
