namespace SpaceWars.Animations
{
    using Microsoft.Xna.Framework;
    using Microsoft.Xna.Framework.Graphics;

    using SpaceWars.Core.Managers;
    using SpaceWars.GameObjects;
    using SpaceWars.Interfaces;
    using SpaceWars.Model;

    public class Dash : GameObject
    {
        private Texture2D texture;
        private readonly int interval;
        private int currentFrame;
        private int spriteHeight;
        private int spriteWidth;

        public Dash(Vector2 position, Texture2D texture)
        {
            this.Texture = texture;
            this.Position = position;
            this.Timer = 0f;
            this.Interval = 100f;
            this.spriteWidth = texture.Width;
            this.spriteHeight = texture.Height;
            this.IsVisible = true;
        }
        public override void LoadContent(ResourceManager resourceManager)
        {
            this.texture = resourceManager.GetResource("dash");
        }

        public override void Think(GameTime gameTime)
        {
            this.Timer += (float)gameTime.ElapsedGameTime.TotalMilliseconds;

            if (this.Timer > this.interval)
            {
                this.currentFrame++;
                this.Timer = 0.0f;
            }

            if (this.currentFrame == 12)
            {
                this.NeedToRemove = false;
                //this.IsVisible = false;
            }

            //this.SourceRectangle = new Rectangle(this.currentFrame * this.spriteHeight, 0, this.spriteWidth, this.spriteHeight);
            this.SourceRectangle = new Rectangle(this.currentFrame * 57, 0, 55, this.spriteHeight); // WORKS ON MAGIC DON'T TOUCH CAN'T FIX IT !!!
            this.Origin = new Vector2(SourceRectangle.Width / 2, SourceRectangle.Height / 2);
        }

        public override void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(this.Texture, Player.GetPlayerPosition, this.SourceRectangle, Color.White, 1.0f, this.Origin, 2.0f, SpriteEffects.FlipVertically, 0);
        }

        public float Timer { get; set; }
        public float Interval { get; set; }

        public Vector2 Origin { get; set; }

        public Rectangle SourceRectangle { get; set; }

        public bool IsVisible { get; set; }
    }
}
