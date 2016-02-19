namespace SpaceWars.Core.Managers
{
    using System;
    using System.Collections.Generic;
    using Microsoft.Xna.Framework;
    using Microsoft.Xna.Framework.Graphics;

    using SpaceWars.Interfaces;

    using SpaceWars.Model;
    using SpaceWars.GameObjects.AsteroidsPack;
    using SpaceWars.GameObjects;
    using SpaceWars.Model.Bonuses;
    using SpaceWars.Core;
   

    public class ObjectManager
    {
        private readonly List<IGameObject> objects = new List<IGameObject>();
        private int elapsedAsteroidTime = 0;
        private const int AsteroidFieldPeriod = 80;
        private int elapsedBonusTime = 0;
        private const int BonusPeriod = 3750;
        private int elapsedEnemyTime = 0;
        private const int EnemyPeriod = 4000;
        public ScoreManager scoreManager = new ScoreManager();
        public ResourceManager ResourceMgr { get; set; }


        public ObjectManager()
        {
            ResourceMgr = new ResourceManager();
        }

        public void AddObject(IGameObject obj)
        {
            obj.Owner = this;
            obj.LoadContent(ResourceMgr);
            objects.Add(obj);
        }

        public bool RemoveObject(IGameObject obj)
        {
           obj.NeedToRemove = true;
           return true; 
        }

        bool RemoveObjectPrivate(IGameObject obj)
        {
            return objects.Remove(obj);
        }

        public void Update(GameTime gametime)
        {
            Think(gametime);
            Move();
            CheckCollision();
            RemoveGarbage();
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            foreach (var obj in objects)
            {
                obj.Draw(spriteBatch);
            }
        }

        public void CheckCollision()
        {
            foreach (var firstObject in objects)
            {
                foreach (var secondObject in objects)
                {
                    if (!Object.ReferenceEquals(firstObject, secondObject))
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
            foreach (var obj in objects)
            {
                obj.Move();
            }
        }

        public void Think(GameTime gametime)
        {
            CreateAsteroidField(gametime);

            DropBonus(gametime);

            DropEnemy(gametime);

            for (int i = 0; i < objects.Count; ++i)
            {
                objects[i].Think(gametime);
            }  
        }

        public void LoadContent(Microsoft.Xna.Framework.Content.ContentManager content)
        {
            ResourceMgr.LoadContent(content);
        }

        void CreateAsteroidField(GameTime gametime)
        {
            elapsedAsteroidTime += gametime.ElapsedGameTime.Milliseconds;

            if (elapsedAsteroidTime > AsteroidFieldPeriod)
            {
                elapsedAsteroidTime = 0;
                var asteroid = GetAsteroid();
                AddObject(asteroid);
            }
        }

        private Asteroid GetAsteroid()
        {
            Random randomAsteroid = new Random();
            int index = randomAsteroid.Next(0, 3);
            switch (index)
            {
                case 0:
                    return new ChunkyAsteroid();
                case 1:
                    return new RockyAsteroid();
                case 2:
                    return new RedFartAsteroid();
            }
            return null;
        }


        public List<IGameObject> GetEnemyBullet()
        {
            var bulletList = objects.FindAll(b => b.GetType() == typeof(Bullet));
            return bulletList;

        }


        void DropBonus(GameTime gametime)
        {
            elapsedBonusTime += gametime.ElapsedGameTime.Milliseconds;

            if (elapsedBonusTime > BonusPeriod)
            {
                elapsedBonusTime = 0;
                Random rand = new Random(gametime.TotalGameTime.Seconds);
                int choice = rand.Next(0, 5);

                switch(choice)
                {
                    case 0:
                        AddObject(new HealthBonus());
                        break;
                    case 1:
                        AddObject(new ShieldBonus());
                        break;
                    default:
                        // There is no bonus for you ... sorry
                        break;
                }
                
            }
        }

        void DropEnemy(GameTime gametime)
        {
            elapsedEnemyTime += gametime.ElapsedGameTime.Milliseconds;

            if (elapsedEnemyTime > EnemyPeriod)
            {
                elapsedEnemyTime = 0;
                Random rand = new Random(gametime.TotalGameTime.Seconds);
                int choice = rand.Next(0, 2);

                switch (choice)
                {
                    case 0:
                        AddObject(new BigEnemy());
                        break;
                    case 1:
                        AddObject(new LittleEnemy());
                        break;
                    default:
                        // There is no bonus for you ... sorry
                        break;
                }

            }
        }


        void RemoveGarbage()
        {
            for (int i = objects.Count - 1; i >= 0; i--)
            {
                if (objects[i].NeedToRemove)
                    RemoveObjectPrivate(objects[i]);
            }
        }

    }
}
