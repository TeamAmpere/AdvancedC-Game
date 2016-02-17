namespace SpaceWars.Model.Bonuses
{

    using System;
    using Microsoft.Xna.Framework;
    using SpaceWars.GameObjects;
    using SpaceWars.Interfaces;

    class HealthBonus: Bonus
    {

        private const int UpCorner = -40; // health bonus size
        private const int RightCorner = 800 - 40; // Screen width - health bonus width
        private const int DownCorner = 950 - 40; // Screen height - health bonus height
        private const int LeftCorner = 0;


        public HealthBonus()
        {
            Random rand = new Random();

            Position = new Vector2(rand.Next(LeftCorner, RightCorner), UpCorner);
            this.Speed = new Vector2(0, 7);

            this.BoundingBox = new Rectangle((int)Position.X, (int)Position.Y, 40, 40);
            

        }

        public override void OnGetBonus(IGameObject obj)
        {
           if (obj.GetType() == typeof(Player))
           {
               Player player = (Player) obj;

               player.GiveHealth(50);

               Owner.RemoveObject(this);
           }
        }


        public override void LoadContent(ResourceManager resourceManager)
        {
            Texture = resourceManager.GetResource("HealthBonus");
        }

        public  override void Think(GameTime gameTime)
        {
            Speed = new Vector2(4*(float)Math.Cos(gameTime.TotalGameTime.Milliseconds/300), Speed.Y);
        }
    }
}
