namespace SpaceWars.GameObjects
{
    using Microsoft.Xna.Framework;
    using Microsoft.Xna.Framework.Content;
    using Microsoft.Xna.Framework.Graphics;

    public class Starfield
    {
        private Texture2D texture;
        private Vector2 bgPos1, bgPos2;

        //Constructor
        public Starfield()
        {
            texture = null;
            bgPos1 = new Vector2(0, 0);
            bgPos2 = new Vector2(0, -950);
            Speed = 5;
        }

        public int Speed { get; set; }

        //Load Content
        public void LoadContent(ContentManager Content)
        {
            texture = Content.Load<Texture2D>("screens/space");
        }

        public void UnloadContet()
        {
        }

        //Update
        public void Update(GameTime gameTime)
        {
            bgPos1.Y = bgPos1.Y + Speed;
            bgPos2.Y = bgPos2.Y + Speed;

            // Scrolling the background (Repeating)

            if (bgPos1.Y >= 950)
            {
                bgPos1.Y = 0;
                bgPos2.Y = -950;
            }
        }

        //Draw
        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(texture, bgPos1, Color.White);
            spriteBatch.Draw(texture, bgPos2, Color.White);
        }
    }
}
