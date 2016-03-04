using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SpaceWars.Core.Managers
{
    using Microsoft.Xna.Framework;

    using SpaceWars.GameObjects;
    using SpaceWars.GameObjects.AsteroidsPack;
    using SpaceWars.Interfaces;

    public class AsteroidManager
    {
        public Asteroid CreateASteroid(IPlayer player)
        {
            Random randomAsteroid = new Random();
            int index = randomAsteroid.Next(0, 3);

            switch (player.Level)
            {
                case 2:
                    switch (index)
                    {
                        case 0:
                            return new ChunkyAsteroid();
                        case 1:
                            return new RockyAsteroid();
                        case 2:
                            return new RedFartAsteroid();
                    }
                    break;

                case 1:
                    switch (index)
                    {
                        case 0:
                            var asteroid = new ChunkyAsteroid();
                            asteroid.Speed += new Vector2(2, 2);
                            return asteroid;

                        case 1:
                            var rockyAsteroid = new RockyAsteroid();
                            rockyAsteroid.Speed += new Vector2(2, 2);
                            return rockyAsteroid;
                        case 2:
                            var redFartAsteroid = new RedFartAsteroid();
                            redFartAsteroid.Speed += new Vector2(2, 2);
                            return redFartAsteroid;
                    }
                    break;

                case 3:
                    break;

                default:
                    switch (index)
                    {
                        case 0:
                            var asteroid = new ChunkyAsteroid();
                            asteroid.Speed += new Vector2(4, 4);
                            return asteroid;

                        case 1:
                            var rockyAsteroid = new RockyAsteroid();
                            rockyAsteroid.Speed += new Vector2(4, 4);
                            return rockyAsteroid;
                        case 2:
                            var redFartAsteroid = new RedFartAsteroid();
                            redFartAsteroid.Speed += new Vector2(4, 4);
                            return redFartAsteroid;
                    }
                    break;
            }

            return null;
        }
    }
}
