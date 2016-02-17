namespace SpaceWars
{
    using Microsoft.Xna.Framework.Graphics;
    using System.Collections.Generic;

    public class ResourceManager
    {

        private Dictionary<string, Texture2D> resources = new Dictionary<string, Texture2D>();
        private Dictionary<string, SpriteFont> fontResources = new Dictionary<string, SpriteFont>();


        public void LoadContent(Microsoft.Xna.Framework.Content.ContentManager content)
        {
            resources["ship"] = content.Load<Texture2D>("ship");
            resources["laser"] = content.Load<Texture2D>("laser");
            resources["asteroid"] = content.Load<Texture2D>("asteroid");
            resources["rocky"] = content.Load<Texture2D>("rocky");
            resources["redfart"] = content.Load<Texture2D>("redfart");
            resources["ShieldBonus"] = content.Load<Texture2D>("ShieldBonus");
            resources["HealthBonus"] = content.Load<Texture2D>("HealthBonus");
            resources["bigEnemy"] = content.Load<Texture2D>("bigEnemy");
            resources["littleEnemy"] = content.Load<Texture2D>("littleEnemy");
            resources["smallEnemyBullet"] = content.Load<Texture2D>("smallEnemyBullet");
            resources["bigEnemyBullet"] = content.Load<Texture2D>("bigEnemyBullet");

            fontResources["spritefont"] = content.Load<SpriteFont>("spritefont");
            fontResources["scorefont"] = content.Load<SpriteFont>("scorefont");

        }

        public SpriteFont GetSpriteFont(string spriteName)
        {
            return fontResources[spriteName];
        }

        public Texture2D GetResource(string resourceName)
        {
            return resources[resourceName];
        }
    }
}
