namespace SpaceWars.Models.Enemies.Bosses.Behaviours
{
    using Microsoft.Xna.Framework;

    using SpaceWars.GameObjects;
    using SpaceWars.Interfaces;
    using SpaceWars.Models.Bullets;

    public class PurpleAlienBehaviour
    {
        public PurpleAlienBehaviour(PurpleAlien alien)
        {
            this.Alien = alien;
        }

        public PurpleAlien Alien { get; set; }

        public IGameObject ManageBehaviour(int health)
        {
            IGameObject bullet;

            if(health < 50 && !Alien.IsLaserLaunched)

            {
                if (Player.GetPlayerPosition.X > 400)
                {
                    bullet = new BossLaser(new Vector2(0, this.Alien.Position.Y), new Vector2(+5, 0));
                    this.Alien.IsLaserLaunched = true;
                }

                else
                {
                    bullet = new BossLaser(new Vector2(800, this.Alien.Position.Y), new Vector2(-5, 0));
                    this.Alien.IsLaserLaunched = true;
                }
            }

            else
            {
                bullet = new AlienRocket(new Vector2(this.Alien.Position.X, this.Alien.Position.Y));
            }

            return bullet;
        }
    }
}
