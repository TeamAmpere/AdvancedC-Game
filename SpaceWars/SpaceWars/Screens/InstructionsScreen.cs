namespace SpaceWars.Screens
{
    using Microsoft.Xna.Framework.Input;
    using SpaceWars.GameObjects;
    using SpaceWars.Screens.ScreenManagement;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    public class InstructionsScreen : GameScreen
    {
        Starfield background = new Starfield();
        Image gameOverStats = new Image("Instructions");
       // private int buttonDelay = 10;


        public override void LoadContent(Microsoft.Xna.Framework.Content.ContentManager Content)
        {
            background.LoadContent(Content);
            gameOverStats.LoadConent(Content);
            base.LoadContent(Content);
        }

        public override void UnloadContent()
        {
            background.UnloadContet();
            gameOverStats.UnloadContent();
            base.UnloadContent();
        }

        public override void Update(Microsoft.Xna.Framework.GameTime gameTime)
        {
            //Controls
            KeyboardState keyboard = Keyboard.GetState();

            if (keyboard.IsKeyDown(Keys.Escape))
            {
                ScreenManager.Instance.Engine.Exit();
            }

            //if (buttonDelay == 0)
            //{
                if (keyboard.IsKeyDown(Keys.Enter))
                {
                    ScreenManager.Instance.ChangeScreen("MainScreen");
                }
            //}
            //else
            //{
            //    buttonDelay--;
            //}
            
            //if (keyboard.IsKeyDown(Keys.H))
            //{
            //    ScreenManager.Instance.ChangeScreen("HighScore");
            //}

            background.Update(gameTime);
            base.Update(gameTime);
        }

        public override void Draw(Microsoft.Xna.Framework.Graphics.SpriteBatch spriteBatch)
        {
            background.Draw(spriteBatch);
            gameOverStats.Draw(spriteBatch);
            base.Draw(spriteBatch);
        }
    }
}
