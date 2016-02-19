namespace SpaceWars.Screens
{
    using Microsoft.Xna.Framework;
    using Microsoft.Xna.Framework.Graphics;
    using GameObjects;
    using ScreenManagement;
    using Microsoft.Xna.Framework.Input;

    using SpaceWars.Core.Managers;

    public class MainScreen : GameScreen
    {
        Starfield bakcground = new Starfield();
        Player player = new Player();
        ObjectManager objectManager = new ObjectManager();

        public override void LoadContent(Microsoft.Xna.Framework.Content.ContentManager Content)
        {
            bakcground.LoadContent(Content);
            objectManager.LoadContent(Content);
            objectManager.AddObject(player);
            base.LoadContent(Content);
        }

        public override void UnloadContent()
        {
            bakcground.UnloadContet();
            base.UnloadContent();
        }

        public override void Update(GameTime gameTime)
        {
            //Controls
            KeyboardState keyboard = Keyboard.GetState();

            if (keyboard.IsKeyDown(Keys.Escape))
            {
                ScreenManager.Instance.Engine.Exit();
            }
            if (keyboard.IsKeyDown(Keys.Enter))
            {

                //ScreenManager.Instance.ChangeScreen("InstructionsScreen");
            }
            //if (keyboard.IsKeyDown(Keys.H))
            //{
            //    ScreenManager.Instance.ChangeScreen("HighscoreScreen");
            //}

            objectManager.Update(gameTime);
            bakcground.Update(gameTime);
            base.Update(gameTime);
        }

        public override void Draw(SpriteBatch spriteBatch)
        {
            bakcground.Draw(spriteBatch);
            objectManager.Draw(spriteBatch);
            base.Draw(spriteBatch);
        }
    }
}