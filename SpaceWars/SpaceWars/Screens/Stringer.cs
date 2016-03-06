namespace SpaceWars.GameObjects
{
    using Microsoft.Xna.Framework;
    using Microsoft.Xna.Framework.Content;
    using Microsoft.Xna.Framework.Graphics;

    using SpaceWars.Core.Managers;

    public class Stringer
    {
        private SpriteFont spriteFont;

        public Stringer(Vector2 position)
        {
            this.Position = position;
            this.Color = Color.White;
        }

        private Vector2 Position { get; set; }

        public string Text { get; set; }

        public Color Color { get; set; }

        public void LoadContent(ResourceManager resourceManager)
        {
            this.spriteFont = resourceManager.GetSpriteFont("spritefont");
        }

        public void LoadContent(ContentManager Content)
        {
            this.spriteFont = Content.Load<SpriteFont>("spritefont");
        }

        public void ScoreLoadContent(ContentManager Content)
        {
            this.spriteFont = Content.Load<SpriteFont>("sprites/scorefont");
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.DrawString(this.spriteFont, this.Text, this.Position, this.Color);
        }
    }
}