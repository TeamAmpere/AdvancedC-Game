namespace SpaceWars.Screens
{
    using SpaceWars.Screens.ScreenManagement;
    using SpaceWars.GameObjects;

    using Microsoft.Xna.Framework.Input;

    public class SplashScreen : GameScreen
    {
        Starfield Background = new Starfield();
        Image Image = new Image("startBackground");

        public override void LoadContent(Microsoft.Xna.Framework.Content.ContentManager Content)
        {
            Background.LoadContent(Content);
            Image.LoadConent(Content);

            base.LoadContent(Content);
        }

        public override void UnloadContent()
        {
            Background.UnloadContet();
            Image.UnloadContent();

            base.UnloadContent();
        }

        public override void Update(Microsoft.Xna.Framework.GameTime gameTime)
        {
            Background.Update(gameTime);

            //Controls
            KeyboardState keyboard = Keyboard.GetState();

            if (keyboard.IsKeyDown(Keys.Escape))
            {
                ScreenManager.Instance.Engine.Exit();
            }
            else if (keyboard.IsKeyDown(Keys.Enter))
            {
                ScreenManager.Instance.ChangeScreen("MainScreen");
            }
            else if (keyboard.IsKeyDown(Keys.I))
            {
                ScreenManager.Instance.ChangeScreen("InstructionsScreen");
            }
            else if (keyboard.IsKeyDown(Keys.H))
            {
                ScreenManager.Instance.ChangeScreen("HighscoreScreen");
            }
            
            base.Update(gameTime);
        }

        public override void Draw(Microsoft.Xna.Framework.Graphics.SpriteBatch spriteBatch)
        {
            Background.Draw(spriteBatch);
            Image.Draw(spriteBatch);
            base.Draw(spriteBatch);
        }
    }
}
