namespace SpaceWars.Interfaces
{
    using Microsoft.Xna.Framework;

    interface IBullet
    {

        void Intersect(IGameObject obj);

        void LoadContent(ResourceManager resourceManager);

        void Think(GameTime gameTime);
        
    }
}
