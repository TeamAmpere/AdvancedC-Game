namespace SpaceWars.GameObjects
{
    using Microsoft.Xna.Framework;
    using SpaceWars.Interfaces;
    using SpaceWars.Model;
    using Microsoft.Xna.Framework.Graphics;
    using Microsoft.Xna.Framework.Input;
    using SpaceWars;
    using SpaceWars.Screens.ScreenManagement;
using SpaceWars.Core;
    using SpaceWars.Core.Managers;

    public class Player: GameObject, IDestructibleObject, IPlayer
    {
        private static readonly Vector2 UP = new Vector2(0, -10);
        private static readonly Vector2 DOWN = new Vector2(0, 10);
        private static readonly Vector2 LEFT = new Vector2(-10,0);
        private static readonly Vector2 RIGHT = new Vector2(10,0);
        private static readonly Vector2 ZERO = new Vector2(0, 0);
        private const int LeftCorner = 0;
        private const int RightCorner = 800 - 64; // Screen width - ship width
        private const int UpCorner = 0;
        private const int DownCorner = 950 - 64; // Screen height - ship height
        private const int ShootInterval = 120;
        public const int MinHealth = 0;

        private Vector2 upTemp;
        private Vector2 downTemp;
        private Vector2 leftTemp;
        private Vector2 rightTemp;
        private int health;
        private int shield;

        private int elapsedShootTime = 0;
        private const int MaxShield = 100;

        //private Stringer HealthText = new Stringer(new Vector2(300, 200));
        //private Stringer ShieldText = new Stringer(new Vector2(150, 200));
        //private Stringer ScoreText = new Stringer(new Vector2(450, 200));

        public Stats Stats { get; set; }
        
        public Player()
        {
            //Texture = null;
            Position = new Vector2(350, 890);
            this.BoundingBox = new Rectangle(350, 890, 64, 64);
            Speed = new Vector2(0,0);
          
            Health = 100;
            Shield = 0;
            this.Stats = new Stats(this);
        }

        public int Health
        {
            get { return this.health; }
            set
            {
                if (value < MinHealth)
                {
                    value = MinHealth;
                }
                this.health = value;
            }
        }

        public int Shield
        {
            get { return this.shield; }
            set
            {
                if (value < 0)
                {
                    value = 0;
                }
                this.shield = value;
            }
        }


        public override void LoadContent(ResourceManager resourceManager)
        {
            Stats.HealthText.Text = "Health: " + this.Health;
            Stats.ShieldText.Text = "Shield: " + this.Shield;
            Stats.ScoreText.Text = "Score: " + Owner.scoreManager.TotalScore;
            Stats.LoadContent(resourceManager);
            //DONT REMOVE THIS
            //HealthText.Text = "Health: " + this.Health;
            //ShieldText.Text = "Shield: " + this.Shield;
            //ScoreText.Text = "Score:" + Owner.scoreManager.TotalScore;
            Texture = resourceManager.GetResource("ship");
        }

        public override void Think(GameTime gameTime)
        {
            //Getting the keyboardState
            KeyboardState keyboard = Keyboard.GetState();

            //Updating Texts
            Stats.HealthText.Text =  "Health: " + this.Health;
            Stats.ShieldText.Text = "Shield: " + this.Shield;
            Stats.ScoreText.Text = "Score: " + Owner.scoreManager.TotalScore;




            //Player Controls
            if (keyboard.IsKeyDown(Keys.A) && Position.X > LeftCorner)
            {
                leftTemp = LEFT;
            }
            else
            {
                leftTemp = ZERO;
            }

            if (keyboard.IsKeyDown(Keys.D) && Position.X < RightCorner)
            {
                rightTemp = RIGHT;
            }
            else
            {
                rightTemp = ZERO;
            }

            if (keyboard.IsKeyDown(Keys.W) && Position.Y > UpCorner)
            {
                upTemp = UP;
            }
            else
            {
                upTemp = ZERO;
            }

            if (keyboard.IsKeyDown(Keys.S) && Position.Y < DownCorner)
            {
                downTemp = DOWN;
            }
            else
            {
                downTemp = ZERO;
            }

            Speed = leftTemp + rightTemp + upTemp + downTemp;

            elapsedShootTime += gameTime.ElapsedGameTime.Milliseconds;

            if (keyboard.IsKeyDown(Keys.Space) && elapsedShootTime > ShootInterval)
            {
                elapsedShootTime = 0;
                Shoot();
            }
  
        }

        public override void Intersect(IGameObject obj)
        {
            
        }

        public void TakeDMG(int dmg)
        {
            int remainingDamage;
            
                if (Shield - dmg < 0)
                {
                    remainingDamage = dmg - Shield;
                    Shield = 0;
                    Health -= remainingDamage;
                }
                else
                {
                    Shield -= dmg;
                }
                if (Health <= MinHealth)
                {
                    Health = 0;
                    Destroy();
      
            }
                if (Health <= 0)
                {
                    //Change the screen to GameOver screen
                    ScreenManager.Instance.ChangeScreen("GameOverScreen");
                }
        }

        public void GiveHealth(int amount)
        {
            Health += amount;
        }

        public  void Destroy()
        {
            Owner.RemoveObject(this);
            int score = Owner.scoreManager.TotalScore;
            Data.AddScore(score);
            //TODO   when the screen is GameOver -> Show Score =>  Owner.ScoreManager.ScoringPoints;
            //End of the game
        }

        public override void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(Texture, Position, Color.White);
            Stats.Draw(spriteBatch);
            //HealthText.Draw(spriteBatch);
            //ShieldText.Draw(spriteBatch);
            //ScoreText.Draw(spriteBatch);
        }

        void Shoot()
        {
            Owner.AddObject(new Bullet(Position));
        }

        public void AddShield(int amount)
        {
            if(Shield + amount > MaxShield)
            {
                Shield = MaxShield;
            }
            else
            {
                Shield += amount;

            }
        }
    }
    
}