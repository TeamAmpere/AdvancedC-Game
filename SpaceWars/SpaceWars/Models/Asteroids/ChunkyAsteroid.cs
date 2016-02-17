namespace SpaceWars.GameObjects.AsteroidsPack
{
    using Microsoft.Xna.Framework;
    using System;

    class ChunkyAsteroid : Asteroid
    {
        private new const int TextureWidth = 38;
        private new const int TextureHeight = 38;
        private new const int MinXVelocity = -3;
        private new const int MaxXVelocity = 3;
        private new const int MinYVelocity = -2;
        private new const int MaxYVelocity = 9;
        private new const int damage = 30;

        public ChunkyAsteroid()
            : base(damage)
        {
            Random rand = new Random();

            Position = new Vector2(rand.Next(LeftCorner, RightCorner), UpCorner);
            Speed = new Vector2(rand.Next(MinXVelocity, MaxXVelocity), rand.Next(MinYVelocity, MaxYVelocity));
            BoundingBox = new Rectangle((int)Position.X, (int)Position.Y, TextureWidth, TextureHeight);
        }


        public override void LoadContent(ResourceManager resourceManager)
        {
            Texture = resourceManager.GetResource("asteroid");
        }

    }
}