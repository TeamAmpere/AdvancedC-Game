namespace SpaceWars.Core.Managers
{
    using System;
    using System.Collections.Generic;

    using Microsoft.Xna.Framework;
    using Microsoft.Xna.Framework.Graphics;

    using SpaceWars.GameObjects;
    using SpaceWars.Interfaces;
    using SpaceWars.Model;
    using SpaceWars.Model.Bonuses;
    using SpaceWars.Models.Enemies.Bosses;

    public class ObjectManager
    {
        private const int AsteroidFieldPeriod = 80;

        private const int BonusPeriod = 3750;

        private const int EnemyPeriod = 4000;

        private readonly List<IGameObject> objects = new List<IGameObject>();

        private int elapsedAsteroidTime;

        private int elapsedBonusTime;

        private int elapsedEnemyTime;

        private bool IsPurpleEnemy;

        public ScoreManager scoreManager = new ScoreManager();

        private List<Explosion> explosions = new List<Explosion>(); 

        public ObjectManager()
        {
            this.ResourceMgr = new ResourceManager();
        }

        public ResourceManager ResourceMgr { get; set; }

        public void AddObject(IGameObject obj)
        {
            if (obj != null)
            {
                if (obj.GetType() != typeof(Explosion))
                {
                    obj.Owner = this;
                    obj.LoadContent(this.ResourceMgr);
                    this.objects.Add(obj);
                }

                else
                {
                    this.explosions.Add((Explosion)obj);
                }
                
            }
        }

        public bool RemoveObject(IGameObject obj)
        {
            obj.NeedToRemove = true;
            return true;
        }

        bool RemoveObjectPrivate(IGameObject obj)
        {
            return this.objects.Remove(obj);
        }

        public void Update(GameTime gametime, IPlayer player)
        {
            this.Think(gametime, player);
            this.Move();
            this.CheckCollision();
            this.RemoveGarbage();
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            foreach (Explosion explosion in this.explosions)
            {
                explosion.Draw(spriteBatch);
            }

            foreach (var obj in this.objects)
            {
                obj.Draw(spriteBatch);
            }
        }

        public void CheckCollision()
        {
            foreach (var firstObject in this.objects)
            {
                foreach (var secondObject in this.objects)
                {
                    if (!ReferenceEquals(firstObject, secondObject))
                    {
                        if (firstObject.BoundingBox.Intersects(secondObject.BoundingBox))
                        {
                            firstObject.Intersect(secondObject);
                        }
                    }
                }
            }
        }

        public void Move()
        {
            foreach (var obj in this.objects)
            {
                obj.Move();
            }
        }

        public void Think(GameTime gametime, IPlayer player)
        {
            this.CreateAsteroidField(gametime, player);

            this.DropBonus(gametime);

            this.DropEnemy(gametime, player);

            for (int i = 0; i < this.objects.Count; ++i)
            {
                this.objects[i].Think(gametime);
            }

            foreach (Explosion explosion in this.explosions)
            {
                explosion.Think(gametime);
            }
        }

        public void LoadContent(Microsoft.Xna.Framework.Content.ContentManager content)
        {
            this.ResourceMgr.LoadContent(content);
        }

        void CreateAsteroidField(GameTime gametime, IPlayer player)
        {
            this.elapsedAsteroidTime += gametime.ElapsedGameTime.Milliseconds;

            if (this.elapsedAsteroidTime > AsteroidFieldPeriod)
            {
                this.elapsedAsteroidTime = 0;
                AsteroidManager asteroidManager = new AsteroidManager();
                var asteroid = asteroidManager.CreateASteroid(player);
                this.AddObject(asteroid);
            }
        }

        public List<IGameObject> GetEnemyBullet()
        {
            var bulletList = this.objects.FindAll(b => b.GetType() == typeof(Bullet));
            return bulletList;
        }

        void DropBonus(GameTime gametime)
        {
            this.elapsedBonusTime += gametime.ElapsedGameTime.Milliseconds;

            if (this.elapsedBonusTime > BonusPeriod)
            {
                this.elapsedBonusTime = 0;
                Random rand = new Random(gametime.TotalGameTime.Seconds);
                int choice = rand.Next(0, 5);

                switch (choice)
                {
                    case 0:
                        this.AddObject(new HealthBonus());
                        break;
                    case 1:
                        this.AddObject(new ShieldBonus());
                        break;
                    default:
                        break;
                }
            }
        }

        void DropEnemy(GameTime gametime, IPlayer player)
        {
            this.elapsedEnemyTime += gametime.ElapsedGameTime.Milliseconds;

            if (this.elapsedEnemyTime > EnemyPeriod)
            {
                this.elapsedEnemyTime = 0;
                Random rand = new Random(gametime.TotalGameTime.Seconds);
                int choice = rand.Next(0, 2);

                switch (player.Level)
                {
                    //case 0:
                      //  break;
                    case 1:
                        this.AddObject(new LittleEnemy(50));
                        break;
                    case 2:
                        switch (choice)
                        {
                            case 0:
                                this.AddObject(new BigEnemy(40));
                                break;
                            case 1:
                                this.AddObject(new LittleEnemy(40));
                                break;
                        }
                        break;
                    case 0:
                        if (!this.IsPurpleEnemy)
                        {
                            this.IsPurpleEnemy = true;
                            this.AddObject(new PurpleAlien(30, player.Position));
                        }

                        break;
                    default:
                        switch (choice)
                        {
                            case 0:
                                this.AddObject(new BigEnemy(30));
                                break;
                            case 1:
                                this.AddObject(new LittleEnemy(30));
                                break;
                        }
                        break;
                }
            }
        }

        void RemoveGarbage()
        {
            for (int i = this.objects.Count - 1; i >= 0; i--)
            {
                if (this.objects[i].NeedToRemove)
                {
                    this.RemoveObjectPrivate(this.objects[i]);
                }
            }

            for (int i = this.explosions.Count - 1; i >= 0; i--)
            {
                if (this.explosions[i].NeedToRemove)
                {
                    this.explosions.Remove(this.explosions[i]);
                }
            }
        }
    }
}