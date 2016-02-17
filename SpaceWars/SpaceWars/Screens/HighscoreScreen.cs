using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Input;
using SpaceWars.Core;
using SpaceWars.GameObjects;
using SpaceWars.Screens.ScreenManagement;

namespace SpaceWars.Screens
{
    public class HighscoreScreen : GameScreen
    {
        Starfield background = new Starfield();
        Image highScoreStats = new Image("Highscore");
        Stringer highscoreWriter = new Stringer(new Vector2(300, 300));

        public override void LoadContent(ContentManager Content)
        {
            highscoreWriter.Text = Data.GetHighScore();
            highscoreWriter.Color = Color.LightGray;
            highscoreWriter.ScoreLoadContent(Content);
            background.LoadContent(Content);
            highScoreStats.LoadConent(Content);
            base.LoadContent(Content);
        }

        public override void UnloadContent()
        {
            background.UnloadContet();
            highScoreStats.UnloadContent();
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
            if (keyboard.IsKeyDown(Keys.Enter))
            {
                ScreenManager.Instance.ChangeScreen("MainScreen");
            }
      
            background.Update(gameTime);
            base.Update(gameTime);
        }

        public override void Draw(Microsoft.Xna.Framework.Graphics.SpriteBatch spriteBatch)
        {
            background.Draw(spriteBatch);
            highScoreStats.Draw(spriteBatch);
            highscoreWriter.Draw(spriteBatch);
            base.Draw(spriteBatch);
        }

    }
}
