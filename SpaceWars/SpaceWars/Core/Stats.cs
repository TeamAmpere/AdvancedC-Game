using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using SpaceWars.GameObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SpaceWars.Core
{
    public class Stats
    {
        public Stringer HealthText { get; set; }
        public Stringer ShieldText { get; set; }
        public Stringer ScoreText { get; set; }

        public Player Player { get; private set; }

        public Stats(Player player)
        {
            this.Player = player;
            this.HealthText = new Stringer(new Vector2(50, 100));
            this.ShieldText = new Stringer(new Vector2(200, 100));
            this.ScoreText = new Stringer(new Vector2(650, 100));
        }

        public void LoadContent(ResourceManager resourceManager)
        {
            HealthText.LoadContent(resourceManager);
            ShieldText.LoadContent(resourceManager);
            ScoreText.LoadContent(resourceManager);
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            HealthText.Draw(spriteBatch);
            ShieldText.Draw(spriteBatch);
            ScoreText.Draw(spriteBatch);
        }
        
    }
}