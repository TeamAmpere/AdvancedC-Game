namespace SpaceWars.Interfaces
{
    using Microsoft.Xna.Framework.Graphics;
    using Microsoft.Xna.Framework;

    public interface IGameObject : IControl
    {

        Texture2D Texture { get; set; }

        Vector2 Position { get; set; }

        Vector2 Speed { get; set; }

        Rectangle BoundingBox { get; set; }

        ObjectManager Owner { get; set; }

        bool NeedToRemove { get; set; }

        void Move();

        void Intersect(IGameObject obj);


        void Draw(SpriteBatch spriteBatch);

        void LoadContent(ResourceManager resourceManager);
    }
}
