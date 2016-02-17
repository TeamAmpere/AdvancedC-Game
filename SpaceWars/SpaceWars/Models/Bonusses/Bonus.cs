namespace SpaceWars.Model
{
    using SpaceWars.Interfaces;

    public abstract class Bonus: GameObject, IBonus
    {
        public abstract void OnGetBonus(IGameObject obj);

        public override void Intersect(IGameObject obj)
        {
            OnGetBonus(obj);
        }
        
    }
}
