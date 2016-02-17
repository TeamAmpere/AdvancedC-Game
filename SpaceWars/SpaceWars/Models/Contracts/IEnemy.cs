namespace SpaceWars.Interfaces
{
    public interface IEnemy: IGiveScore
    {
        void OnGetEnemy(IGameObject obj);
        void Shoot();
    }

}
