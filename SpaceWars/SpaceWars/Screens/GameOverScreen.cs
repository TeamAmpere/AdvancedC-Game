namespace SpaceWars.Screens
{
    using Microsoft.Xna.Framework;
    using Microsoft.Xna.Framework.Audio;
    using Microsoft.Xna.Framework.Input;
    using Microsoft.Xna.Framework.Media;

    using SpaceWars.Core;
    using SpaceWars.GameObjects;
    using SpaceWars.Screens.ScreenManagement;

    public class GameOverScreen : GameScreen
    {
        readonly Starfield background = new Starfield();

        private SoundEffect gameOverEffect;

        readonly Image gameOverStats = new Image("Gameover");

        readonly Stringer score = new Stringer(new Vector2(415, 481));

        public override void LoadContent(Microsoft.Xna.Framework.Content.ContentManager Content)
        {
            this.score.Text = Data.GetLastScore().ToString();
            this.score.Color = Color.LightGray;
            this.score.ScoreLoadContent(Content);
            this.background.LoadContent(Content);
            this.gameOverStats.LoadConent(Content);
            MediaPlayer.Stop();
            this.gameOverEffect = Content.Load<SoundEffect>("sounds/GameOver");
            this.gameOverEffect.Play();
            base.LoadContent(Content);
        }

        public override void UnloadContent()
        {
            this.background.UnloadContet();
            this.gameOverStats.UnloadContent();
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
                ScreenManager.Instance.ChangeScreen("MainScreen");
            }
            //if (keyboard.IsKeyDown(Keys.H))
            //{
            //    ScreenManager.Instance.ChangeScreen("HighScoreScreen");
            //}

            this.background.Update(gameTime);
            base.Update(gameTime);
        }

        public override void Draw(Microsoft.Xna.Framework.Graphics.SpriteBatch spriteBatch)
        {
            this.background.Draw(spriteBatch);
            this.gameOverStats.Draw(spriteBatch);
            this.score.Draw(spriteBatch);
            base.Draw(spriteBatch);
        }
    }
}