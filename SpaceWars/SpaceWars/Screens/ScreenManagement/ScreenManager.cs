namespace SpaceWars.Screens.ScreenManagement
{
    using Xml;
    using Screens;
    using Microsoft.Xna.Framework;
    using Microsoft.Xna.Framework.Content;
    using Microsoft.Xna.Framework.Graphics;

    public class ScreenManager
    {
        private static ScreenManager instance;
        private XmlManager<GameScreen> xmlGameScreenManager;

        public Vector2 Dimensions { private set; get; }
        public ContentManager Content { private set; get; }
        public Engine Engine;

        GameScreen currentScreen, newScreen;
        public GraphicsDevice GraphicsDevice;
        public SpriteBatch SpriteBatch;

        public static ScreenManager Instance
        {
            get
            {
                if (instance == null)
                    instance = new ScreenManager();

                return instance;
            }
        }

        public void ChangeScreen(string screenName)
        {
            newScreen = ScreenFactory.CreateScreen(screenName);
            xmlGameScreenManager = new XmlManager<GameScreen>();
            xmlGameScreenManager.Type = newScreen.Type;
            currentScreen.UnloadContent();
            currentScreen = xmlGameScreenManager.Load("Loads/" + screenName + ".xml");
            currentScreen.LoadContent(Content);

        }


        public ScreenManager()
        {
            Dimensions = new Vector2(800, 950);
            currentScreen = new SplashScreen();
            xmlGameScreenManager = new XmlManager<GameScreen>();
            xmlGameScreenManager.Type = currentScreen.Type;
            currentScreen = xmlGameScreenManager.Load("Loads/SplashScreen.xml");
        }

        public void LoadContent(ContentManager Content)
        {
            this.Content = new ContentManager(Content.ServiceProvider, "Content");
            currentScreen.LoadContent(Content);
        }

        public void UnloadContent()
        {
            currentScreen.UnloadContent();
        }

        public void Update(GameTime gameTime)
        {
            currentScreen.Update(gameTime);
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            currentScreen.Draw(spriteBatch);
        }
    }
}