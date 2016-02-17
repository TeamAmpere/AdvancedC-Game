namespace SpaceWars.GameObjects
{
    using Microsoft.Xna.Framework.Content;
    using Microsoft.Xna.Framework;
    using Microsoft.Xna.Framework.Graphics;
   
    public class Image
    {
        private Vector2 Position = new Vector2(0, 0);
        private string imageName;

        public Texture2D Texture { get; set; }


        public Image(string imageName)
        {
            this.imageName = imageName;
        }

        public void LoadConent(ContentManager Content)
        {
            Texture = Content.Load<Texture2D>(this.imageName);
        }

        public void UnloadContent()
        {
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(Texture, Position, Color.White);
        }

    }
}
