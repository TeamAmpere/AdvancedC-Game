﻿namespace SpaceWars.GameObjects
{
    using System.Linq.Expressions;

    using SpaceWars.Interfaces;
    using SpaceWars.Model;
    using Microsoft.Xna.Framework;
    using Microsoft.Xna.Framework.Audio;
    using Microsoft.Xna.Framework.Graphics;

    //using SpaceWars.Animations;
    using SpaceWars.Core.Managers;
    using SpaceWars.Models.Enemies.Bosses;

    public class Bullet: GameObject, IBullet
    {
        //Stefka: cropped the png of the laser and added TextureWidth and TextureHight = 64(the size of the png) and changed the values in the constructor, because they were 5 X 5 - the reason why asteroids were shot only from the right
        private const int TextureWidth = 64;
        private const int TextureHeight = 64; 

        private static readonly Vector2 UP = new Vector2(0, -30);
        private const int LeftCorner = 0;
        private const int RightCorner = 800;
        private const int UpCorner = 0;
        private const int DownCorner = 950;
        private SoundEffect explosion;

        private SoundEffectInstance explosionInstance;

        private Texture2D ExplosionTexture;

        public Bullet(Vector2 position)
        {
            Speed = UP;
            Position = position;
            BoundingBox = new Rectangle((int)position.X,(int)position.Y, TextureWidth, TextureHeight);
            
        }

        public override void Intersect(IGameObject obj)
        {
            var enemyTarget = obj as IGiveScore;
            if (enemyTarget != null)
            {
                Owner.scoreManager.AddPoints(enemyTarget.ScoringPoints);
            }

            if (obj is IAsteroid)
            {
                var asteroid = (Asteroid)obj;
                var explosion = new Explosion(
                    this.ExplosionTexture,
                    new Vector2(asteroid.Position.X, asteroid.Position.Y + 20));
                this.explosionInstance.Volume = 0.5f;
                this.explosionInstance.Play();
                Owner.AddObject(explosion);
                Owner.RemoveObject(asteroid);
                Owner.RemoveObject(this);
            }

            if (obj is PurpleAlien)
            {
                var boss = (PurpleAlien)obj;
                if (boss.Health <= 0)
                {
                    Owner.Explosions.Add(new Explosion(
                    this.ExplosionTexture,
                    new Vector2(boss.Position.X, boss.Position.Y + 20), 20f, 50));
                    this.explosionInstance.Volume = 1f;
                    this.explosionInstance.Play();
                }
                
            }

            if (obj is Enemy && !(obj is PurpleAlien))
            {
                this.explosionInstance.Volume = 0.3f;
                this.explosionInstance.Play();
                var enemy = (Enemy)obj;
                Owner.AddObject(new Explosion(this.ExplosionTexture, new Vector2(enemy.Position.X + 50, enemy.Position.Y + 65), 1.5f));
            }
        }

        public override void LoadContent(ResourceManager resourceManager)
        {
            this.explosion = resourceManager.GetSound("explosion");
            this.explosionInstance = this.explosion.CreateInstance();
            Texture = resourceManager.GetResource("laser");
            this.ExplosionTexture = resourceManager.GetResource("explosion3");
        }

        public override void Think(GameTime gameTime)
        {
            bool needToRemove = false;

            if (Position.X < LeftCorner)
                needToRemove = true;
            if (Position.X > RightCorner)
                needToRemove = true;
            if (Position.Y > DownCorner)
                needToRemove = true;
            if (Position.Y < UpCorner)
                needToRemove = true;
            if (needToRemove)
                Owner.RemoveObject(this);
        }
        
    }
}
