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
            this.resources["ship"] = content.Load<Texture2D>("ship");
            this.resources["laser"] = content.Load<Texture2D>("laser");
            this.resources["asteroid"] = content.Load<Texture2D>("asteroid");
            this.resources["rocky"] = content.Load<Texture2D>("rocky");
            this.resources["redfart"] = content.Load<Texture2D>("redfart");
            this.resources["ShieldBonus"] = content.Load<Texture2D>("ShieldBonus");
            this.resources["HealthBonus"] = content.Load<Texture2D>("HealthBonus");
            this.resources["bigEnemy"] = content.Load<Texture2D>("bigEnemy");
            this.resources["littleEnemy"] = content.Load<Texture2D>("littleEnemy");
            this.resources["smallEnemyBullet"] = content.Load<Texture2D>("smallEnemyBullet");
            this.resources["bigEnemyBullet"] = content.Load<Texture2D>("bigEnemyBullet");
            this.resources["alienRocket"] = content.Load<Texture2D>("alienRocket");
            this.resources["purpleAlien"] = content.Load<Texture2D>("purpleAlien");

            this.fontResources["spritefont"] = content.Load<SpriteFont>("spritefont");
            this.fontResources["scorefont"] = content.Load<SpriteFont>("scorefont");

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
