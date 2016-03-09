namespace SpaceWars.Core.Managers
{
    using System.Collections.Generic;

    using Microsoft.Xna.Framework.Audio;
    using Microsoft.Xna.Framework.Graphics;

    public class ResourceManager
    {

        private Dictionary<string, Texture2D> resources = new Dictionary<string, Texture2D>();
        private Dictionary<string, SpriteFont> fontResources = new Dictionary<string, SpriteFont>();
        Dictionary<string,SoundEffect> sounds = new Dictionary<string, SoundEffect>(); 

        public void LoadContent(Microsoft.Xna.Framework.Content.ContentManager content)
        {
            //Asteroids
            this.resources["asteroid"] = content.Load<Texture2D>("asteroids/asteroid");
            this.resources["rocky"] = content.Load<Texture2D>("asteroids/rocky");
            this.resources["redfart"] = content.Load<Texture2D>("asteroids/redfart");

            //Bonuses
            this.resources["ShieldBonus"] = content.Load<Texture2D>("bonuses/ShieldBonus");
            this.resources["HealthBonus"] = content.Load<Texture2D>("bonuses/HealthBonus");

            //Bullets
            this.resources["laser"] = content.Load<Texture2D>("bullets/laser");
            this.resources["smallEnemyBullet"] = content.Load<Texture2D>("bullets/smallEnemyBullet");
            this.resources["bigEnemyBullet"] = content.Load<Texture2D>("bullets/bigEnemyBullet");
            this.resources["alienRocket"] = content.Load<Texture2D>("bullets/alienRocket");
            this.resources["bossLaser"] = content.Load<Texture2D>("bullets/bossLaser");
            this.resources["purpleBullet"] = content.Load<Texture2D>("bullets/purpleBullet");

            //Ships
            this.resources["ship"] = content.Load<Texture2D>("Ships/ship");
            this.resources["bigEnemy"] = content.Load<Texture2D>("Ships/bigEnemy");
            this.resources["littleEnemy"] = content.Load<Texture2D>("Ships/littleEnemy");
            this.resources["purpleAlien"] = content.Load<Texture2D>("Ships/purpleAlien");

            //Effects
            this.resources["explosion3"] = content.Load<Texture2D>("sprites/explosion3");
            this.resources["healthBar"] = content.Load<Texture2D>("sprites/HealthBar");
            this.resources["playerHealthbar"] = content.Load<Texture2D>("sprites/playerHealthbar");
            this.resources["shieldBar"] = content.Load<Texture2D>("sprites/shieldBar");
            this.resources["dash"] = content.Load<Texture2D>("sprites/dash");

            //Sounds
            this.sounds["explosion"] = content.Load<SoundEffect>("sounds/explosion");

            //Texts
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

        public SoundEffect GetSound(string soundName)
        {
            return this.sounds[soundName];
        }
    }
}
