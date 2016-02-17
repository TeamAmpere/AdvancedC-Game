namespace SpaceWars.Interfaces
{
    public interface IDestructibleObject
    {
        int Health { get; set; }
        
        void TakeDMG(int dmg);
        void Destroy();
    }
}
