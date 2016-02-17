namespace SpaceWars.GameObjects
{
    using System;
    using Microsoft.Xna.Framework;
    using Microsoft.Xna.Framework.Graphics;
    using SpaceWars.Interfaces;
    using SpaceWars.Model;

    public abstract class Asteroid : GameObject, IAsteroid
    {
        protected const int TextureWidth = 0; 
        protected const int TextureHeight = 0; 
        protected const int UpCorner = - 50; // asteroid size
        protected const int RightCorner = 800 - TextureWidth; // Screen width - asteroid width
        protected const int DownCorner = 950 - TextureHeight; // Screen height - asteroid height
        protected const int LeftCorner = 0;
        protected const int MinXVelocity = 0;
        protected const int MaxXVelocity = 0;
        protected const int MinYVelocity = 0;
        protected const int MaxYVelocity = 0;
        protected int damage;
        protected static Random rand = new Random();
        protected Vector2 origin;
        protected float rotationAngle = rand.Next(0, 180);
        private int scoringPoints = 1;

        protected Asteroid(int damage)
        {
            Random rand = new Random();
            Damage = damage;
            Position = new Vector2(rand.Next(LeftCorner, RightCorner), UpCorner);
            Speed = new Vector2(rand.Next(MinXVelocity, MaxXVelocity), rand.Next(MinYVelocity, MaxYVelocity));
            BoundingBox = new Rectangle((int)Position.X, (int)Position.Y, TextureWidth, TextureHeight);
        }

        public int Damage { get; set; }
        public Vector2 Origin
        {
            get { return this.origin; }
            set
            {
                if (value.X <= 0 || value.Y <= 0)
                {
                    throw new ArgumentException("Origin cannot be 0 or negative");
                }
                this.origin = value;
            }
        }

        public int ScoringPoints 
        {
            get { return this.scoringPoints; }
            set { this.scoringPoints = value; }
        }

        public override void Intersect(IGameObject obj)
        {
            if (obj.GetType() == typeof(Player))
            {
                Player player = (Player)obj;
                player.TakeDMG(Damage);
                Owner.RemoveObject(this);
            }
        }
 
        public override void Think(GameTime gameTime)
        {
            bool needToRemove = Position.Y > DownCorner + TextureHeight;
            if (Position.X < LeftCorner - TextureWidth)
            {
                needToRemove = true;
            }
            if (Position.X > RightCorner + TextureWidth)
            {
                needToRemove = true;
            }
            if (Position.Y < UpCorner)
            {
                needToRemove = true;
            }
            Rotate(gameTime);
            if (needToRemove)
            {
                Owner.RemoveObject(this);
            }

            origin.X = TextureWidth / 2f;
            origin.Y = TextureHeight / 2f;
        }


        private void Rotate(GameTime gameTime)
        {
            float elapsed = (float)gameTime.ElapsedGameTime.TotalSeconds;
            rotationAngle += elapsed;
            float cirlce = MathHelper.Pi * 2;
            rotationAngle = rotationAngle % cirlce;
        }

        public override void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(Texture, Position, null, Color.White, rotationAngle, origin, 1.0f, SpriteEffects.None, 0f);
        }

        
    }       
}
