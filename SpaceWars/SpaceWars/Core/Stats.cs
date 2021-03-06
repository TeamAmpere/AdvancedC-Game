﻿using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using SpaceWars.GameObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SpaceWars.Core
{
    using SpaceWars.Core.Managers;

    public class Stats
    {
        public Stats(Player player)
        {
            this.Player = player;
            this.HealthText = new Stringer(new Vector2(375, 920));
            this.ShieldText = new Stringer(new Vector2(375, 890));
            this.ScoreText = new Stringer(new Vector2(650, 100));
            this.Level = new Stringer(new Vector2(550, 100));
        }

        public Stringer HealthText { get; set; }
        public Stringer ShieldText { get; set; }
        public Stringer ScoreText { get; set; }
        public Stringer Level { get; set; }

        public Player Player { get; private set; }

        public void LoadContent(ResourceManager resourceManager)
        {
            HealthText.LoadContent(resourceManager);
            ShieldText.LoadContent(resourceManager);
            ScoreText.LoadContent(resourceManager);
            Level.LoadContent(resourceManager);
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            HealthText.Draw(spriteBatch);
            ShieldText.Draw(spriteBatch);
            ScoreText.Draw(spriteBatch);
            Level.Draw(spriteBatch);
        }
        
    }
}