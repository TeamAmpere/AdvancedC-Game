namespace SpaceWars.Interfaces
{
    public interface IAsteroid: IGiveScore
    {
        int Damage { get; set; }
    }
}
