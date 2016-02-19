﻿namespace SpaceWars.Interfaces
{
    using Microsoft.Xna.Framework;

    using SpaceWars.Core.Managers;

    interface IBullet
    {

        void Intersect(IGameObject obj);

        void LoadContent(ResourceManager resourceManager);

        void Think(GameTime gameTime);
        
    }
}
