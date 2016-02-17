namespace SpaceWars.Interfaces
{
    using Microsoft.Xna.Framework;
    using Microsoft.Xna.Framework.Graphics;

    public interface IPlayer
    {

        int Health { get;}
        int Shield { get;  }
        void LoadContent(ResourceManager resourceManager);
        void Think(GameTime gameTime);
        void Intersect(IGameObject obj);
        void TakeDMG(int dmg);
        void GiveHealth(int amount);
        void Destroy();
        void Draw(SpriteBatch spriteBatch);
        void AddShield(int amount);
        

    }
}
