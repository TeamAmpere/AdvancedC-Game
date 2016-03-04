namespace SpaceWars.GameObjects
{
    using Microsoft.Xna.Framework;
    using Microsoft.Xna.Framework.Graphics;

    using SpaceWars.Core.Managers;
    using SpaceWars.Interfaces;
    using SpaceWars.Model;

    public class Explosion : GameObject
    {
        private readonly int interval;

        private int currentFrame;

        private int spriteHeight;

        private int spriteWidth;

        public Explosion(Texture2D texture, Vector2 position)
        {
            this.Texture = texture;
            this.Position = position;
            this.Timer = 0f;
            this.Interval = 20f;
            this.spriteWidth = texture.Width;
            this.spriteHeight = texture.Height;
            this.IsVisible = true;
        }

        //public Texture2D Texture { get; set; }

        //public Vector2 Position { get; set; }


        public override void LoadContent(ResourceManager resourceManager)
        {
        }

        public override void Think(GameTime gameTime)
        {
            this.Timer += (float)gameTime.ElapsedGameTime.TotalMilliseconds;

            if (this.Timer > this.interval)
            {
                this.currentFrame++;
                this.Timer = 0f;
            }

            if (this.currentFrame == 17)
            {
                this.NeedToRemove = false;
                //this.IsVisible = false;
            }

            this.SourceRectangle = new Rectangle(this.currentFrame * this.spriteHeight, 0, this.spriteWidth, this.spriteHeight);
            this.SourceRectangle = new Rectangle(this.currentFrame * 120, 0, 120, this.spriteHeight); // WORKS ON MAGIC DON'T TOUCH CAN'T FIX IT !!!
            this.Origin = new Vector2(SourceRectangle.Width / 2, SourceRectangle.Height / 2);
        }


        public override void Intersect(IGameObject obj)
        {
            throw new DeviceNotResetException();
        }

        public override void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(this.Texture, this.Position, this.SourceRectangle, Color.White, 0f, this.Origin, 1.0f, SpriteEffects.None, 0);
        }

        public float Timer { get; set; }

        public float Interval { get; set; }

        public Vector2 Origin { get; set; }

        public Rectangle SourceRectangle { get; set; }

        public bool IsVisible { get; set; }
    }
}