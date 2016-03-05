﻿namespace SpaceWars.Screens
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

        private Texture2D texture2;
        private bool pause = false;

        public override void LoadContent(Microsoft.Xna.Framework.Content.ContentManager Content)
        {
            bakcground.LoadContent(Content);
            objectManager.LoadContent(Content);
            objectManager.AddObject(player);
            this.texture2 = Content.Load<Texture2D>("sprites/Pause");
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

            if (!pause)
            {

                if (keyboard.IsKeyDown(Keys.P))
                {
                    this.pause = true;
                }
                else
                {
                    objectManager.Update(gameTime, this.player);
                    bakcground.Update(gameTime);
                    base.Update(gameTime);
                }

            }
            else
            {
                if (keyboard.IsKeyDown(Keys.Enter))
                {
                    this.pause = false;
                }
            }
        }

        public override void Draw(SpriteBatch spriteBatch)
        {
            bakcground.Draw(spriteBatch);
            objectManager.Draw(spriteBatch);
            if (pause)
            {
                spriteBatch.Draw(this.texture2,new Vector2(80,400), Color.AliceBlue );
            }
            base.Draw(spriteBatch);
        }
    }
}