namespace SpaceWars.Screens.ScreenManagement
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Xml.Serialization;

    using Microsoft.Xna.Framework;
    using Microsoft.Xna.Framework.Graphics;
    using Microsoft.Xna.Framework.Content;

    public abstract class GameScreen
    {
        protected ContentManager content;
        [XmlIgnore]
        public Type Type { get; set; }
        public GameScreen()
        {
            Type = this.GetType();
        }

        public virtual void LoadContent(ContentManager Content)
        {
            content = new ContentManager(ScreenManager.Instance.Content.ServiceProvider, "Content");
        }

        public virtual void UnloadContent()
        {
            content.Unload();
        }

        public virtual void Update(GameTime gameTime)
        {
        }

        public virtual void Draw(SpriteBatch spriteBatch)
        {
        }

    }
}