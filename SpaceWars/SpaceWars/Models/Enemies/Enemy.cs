namespace SpaceWars.Model
{
    using SpaceWars.GameObjects;
    using SpaceWars.Interfaces;

    public abstract class Enemy: GameObject, IEnemy
    {
        public int ScoringPoints { get; set; }

        public abstract void OnGetEnemy(IGameObject obj);

        public abstract void Shoot();
        
        public override void Intersect(IGameObject obj)
        {
            OnGetEnemy(obj);
            if (obj.GetType() == typeof(Bullet))
            {
                this.NeedToRemove = true;
            }
        }
    }
}
