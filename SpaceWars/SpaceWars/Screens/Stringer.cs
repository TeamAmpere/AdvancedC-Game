namespace SpaceWars.GameObjects
{
    using Microsoft.Xna.Framework;
    using Microsoft.Xna.Framework.Content;
    using Microsoft.Xna.Framework.Graphics;

    using SpaceWars.Core.Managers;
    using SpaceWars.Model;

    public class Stringer 
    {
        private SpriteFont spriteFont;
        private Vector2 Position { get; set; }
        public string Text { get; set; }
        public Color Color { get; set; }

        public Stringer(Vector2 position)
        {
            this.Position = position;
            this.Color = Color.White;
        }

        public void LoadContent(ResourceManager resourceManager)
        {
            spriteFont = resourceManager.GetSpriteFont("spritefont");
        }

        public void LoadContent(ContentManager Content)
        {
            spriteFont = Content.Load<SpriteFont>("spritefont");
        }

        public void ScoreLoadContent(ContentManager Content)
        {
            spriteFont = Content.Load<SpriteFont>("scorefont");
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.DrawString(spriteFont, Text, Position, Color);
        }
    }
}
