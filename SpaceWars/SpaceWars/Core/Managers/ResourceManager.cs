namespace SpaceWars.Core.Managers
{
    using System.Collections.Generic;

    using Microsoft.Xna.Framework.Graphics;

    public class ResourceManager
    {

        private Dictionary<string, Texture2D> resources = new Dictionary<string, Texture2D>();
        private Dictionary<string, SpriteFont> fontResources = new Dictionary<string, SpriteFont>();


        public void LoadContent(Microsoft.Xna.Framework.Content.ContentManager content)
        {
            this.resources["ship"] = content.Load<Texture2D>("Ships/ship");
            this.resources["laser"] = content.Load<Texture2D>("bullets/laser");
            this.resources["asteroid"] = content.Load<Texture2D>("asteroids/asteroid");
            this.resources["rocky"] = content.Load<Texture2D>("asteroids/rocky");
            this.resources["redfart"] = content.Load<Texture2D>("asteroids/redfart");
            this.resources["ShieldBonus"] = content.Load<Texture2D>("bonuses/ShieldBonus");
            this.resources["HealthBonus"] = content.Load<Texture2D>("bonuses/HealthBonus");
            this.resources["bigEnemy"] = content.Load<Texture2D>("Ships/bigEnemy");
            this.resources["littleEnemy"] = content.Load<Texture2D>("Ships/littleEnemy");
            this.resources["smallEnemyBullet"] = content.Load<Texture2D>("bullets/smallEnemyBullet");
            this.resources["bigEnemyBullet"] = content.Load<Texture2D>("bullets/bigEnemyBullet");
            this.resources["alienRocket"] = content.Load<Texture2D>("bullets/alienRocket");
            this.resources["purpleAlien"] = content.Load<Texture2D>("Ships/purpleAlien");
            this.resources["explosion3"] = content.Load<Texture2D>("sprites/explosion3");
            this.resources["healthBar"] = content.Load<Texture2D>("sprites/HealthBar");
            this.resources["playerHealthbar"] = content.Load<Texture2D>("sprites/playerHealthbar");
            this.resources["shieldBar"] = content.Load<Texture2D>("sprites/shieldBar");

            this.fontResources["spritefont"] = content.Load<SpriteFont>("sprites/spritefont");
            this.fontResources["scorefont"] = content.Load<SpriteFont>("sprites/scorefont");

        }

        public SpriteFont GetSpriteFont(string spriteName)
        {
            return this.fontResources[spriteName];
        }

        public Texture2D GetResource(string resourceName)
        {
            return this.resources[resourceName];
        }
    }
}
