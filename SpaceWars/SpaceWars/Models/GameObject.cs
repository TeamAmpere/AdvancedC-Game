namespace SpaceWars.Model
{
    using SpaceWars.Interfaces;
    using Microsoft.Xna.Framework;
    using Microsoft.Xna.Framework.Graphics;

    public abstract class GameObject : IGameObject
    {


        private Vector2 position;
        private Vector2 speed;
        private Texture2D texture;
        private Rectangle boundingBox;

        public Texture2D Texture { get; set; }
        public Vector2 Position { get; set; }
        public Vector2 Speed { get; set; }
        public Rectangle BoundingBox { get; set; }
        public ObjectManager Owner { get; set; }
        public bool NeedToRemove { get; set; }

        public GameObject()
        {
            NeedToRemove = false;
        }

        public virtual void Move()
        {
            Position += Speed;
            BoundingBox = new Rectangle((int)Position.X, (int)Position.Y, this.Texture.Width, this.Texture.Height);
        }

        public abstract void Intersect(IGameObject obj);

        public virtual void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(Texture, Position, Color.White);
        }

        public abstract void LoadContent(ResourceManager resourceManager);

        public abstract void Think(GameTime gameTime); 
        
    }
}
