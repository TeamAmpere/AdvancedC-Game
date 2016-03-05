namespace SpaceWars.GameObjects
{
    using Microsoft.Xna.Framework;
    using Microsoft.Xna.Framework.Graphics;
    using Microsoft.Xna.Framework.Input;

    using SpaceWars.Core;
    using SpaceWars.Core.Managers;
    using SpaceWars.Interfaces;
    using SpaceWars.Model;
    using SpaceWars.Screens.ScreenManagement;

    public class Player : GameObject, IDestructibleObject, IPlayer
    {
        private const int LeftCorner = 0;

        private const int RightCorner = 800 - 64; // Screen width - ship width

        private const int UpCorner = 0;

        private const int DownCorner = 950 - 64; // Screen height - ship height

        private const int ShootInterval = 120;

        public const int MinHealth = 0;

        private const int MaxShield = 100;

        private static readonly Vector2 UP = new Vector2(0, -10);

        private static readonly Vector2 DOWN = new Vector2(0, 10);

        private static readonly Vector2 LEFT = new Vector2(-10, 0);

        private static readonly Vector2 RIGHT = new Vector2(10, 0);

        private static readonly Vector2 ZERO = new Vector2(0, 0);

        private Vector2 downTemp;

        private int elapsedShootTime;

        private int health;

        private Texture2D shieldBar;

        private Texture2D healthBar;

        private Rectangle healthRectangle;

        private Rectangle shieldRectangle;

        private Vector2 healthBarPosition;

        private Vector2 shieldBarPosition;

        private Vector2 leftTemp;

        private Vector2 rightTemp;

        private int shield;

        private Vector2 upTemp;

        public Player()
        {
            //Texture = null;
            this.Position = new Vector2(350, 890);
            this.BoundingBox = new Rectangle(350, 890, 64, 64);
            this.Speed = new Vector2(0, 0);
            this.Health = 100;
            this.Shield = 0;
            this.Stats = new Stats(this);
        }

        //private Stringer HealthText = new Stringer(new Vector2(300, 200));
        //private Stringer ShieldText = new Stringer(new Vector2(150, 200));
        //private Stringer ScoreText = new Stringer(new Vector2(450, 200));

        public Stats Stats { get; set; }

        public int Health
        {
            get
            {
                return this.health;
            }
            set
            {
                if (value < MinHealth)
                {
                    value = MinHealth;
                }
                this.health = value;
            }
        }

        public void TakeDMG(int dmg)
        {
            int remainingDamage;

            if (this.Shield - dmg < 0)
            {
                remainingDamage = dmg - this.Shield;
                this.Shield = 0;
                this.Health -= remainingDamage;
            }
            else
            {
                this.Shield -= dmg;
            }
            if (this.Health <= MinHealth)
            {
                this.Health = 0;
                this.Destroy();
            }
            if (this.Health <= 0)
            {
                //Change the screen to GameOver screen
                ScreenManager.Instance.ChangeScreen("GameOverScreen");
            }
        }

        public void Destroy()
        {
            this.Owner.RemoveObject(this);
            int score = this.Owner.scoreManager.TotalScore;
            Data.AddScore(score);
            //TODO   when the screen is GameOver -> Show Score =>  Owner.ScoreManager.ScoringPoints;
            //End of the game
        }

        public int Shield
        {
            get
            {
                return this.shield;
            }
            set
            {
                if (value < 0)
                {
                    value = 0;
                }
                this.shield = value;
            }
        }

        public int Level
        {
            get
            {
                return this.Owner.scoreManager.TotalScore / 100;
            }
        }

        public int HealthBarPosition
        {
            get
            {
                if (this.health * 7 >= 700)
                {
                    return 700;
                }
                return this.health * 7;
            }
        }

        public int ShieldBarPosition
        {
            get
            {
                if (this.shield * 7 >= 700)
                {
                    return 700;
                }
                return this.shield * 7;
            }
        }

        public override void LoadContent(ResourceManager resourceManager)
        {
            this.Stats.HealthText.Text = "Health: " + this.Health;
            this.Stats.ShieldText.Text = "Shield: " + this.Shield;
            this.Stats.ScoreText.Text = "Score: " + this.Owner.scoreManager.TotalScore;
            this.Stats.Level.Text = "Level: " + this.Level;
            this.Stats.LoadContent(resourceManager);
            //DONT REMOVE THIS
            //HealthText.Text = "Health: " + this.Health;
            //ShieldText.Text = "Shield: " + this.Shield;
            //ScoreText.Text = "Score:" + Owner.scoreManager.TotalScore;
            this.Texture = resourceManager.GetResource("ship");
            this.healthBar = resourceManager.GetResource("playerHealthbar");
            this.shieldBar = resourceManager.GetResource("shieldBar");
        }

        public override void Think(GameTime gameTime)
        {
            //Getting the keyboardState
            KeyboardState keyboard = Keyboard.GetState();

            //Updating Texts
            this.Stats.HealthText.Text = this.Health.ToString();
            this.Stats.ShieldText.Text = this.Shield.ToString();
            this.Stats.ScoreText.Text = "Score: " + this.Owner.scoreManager.TotalScore;
            this.Stats.Level.Text = "Level: " + this.Level;

            //Updating healthbar image.
            this.healthRectangle = new Rectangle(50, 920, this.HealthBarPosition, 20);

            //Updating shieldbar image.
            this.shieldRectangle = new Rectangle(50, 890, this.ShieldBarPosition, 20);


            //Player Controls
            if (keyboard.IsKeyDown(Keys.A) && this.Position.X > LeftCorner)
            {
                this.leftTemp = LEFT;
            }
            else
            {
                this.leftTemp = ZERO;
            }

            if (keyboard.IsKeyDown(Keys.D) && this.Position.X < RightCorner)
            {
                this.rightTemp = RIGHT;
            }
            else
            {
                this.rightTemp = ZERO;
            }

            if (keyboard.IsKeyDown(Keys.W) && this.Position.Y > UpCorner)
            {
                this.upTemp = UP;
            }
            else
            {
                this.upTemp = ZERO;
            }

            if (keyboard.IsKeyDown(Keys.S) && this.Position.Y < DownCorner)
            {
                this.downTemp = DOWN;
            }
            else
            {
                this.downTemp = ZERO;
            }

            this.Speed = this.leftTemp + this.rightTemp + this.upTemp + this.downTemp;

            this.elapsedShootTime += gameTime.ElapsedGameTime.Milliseconds;

            if (keyboard.IsKeyDown(Keys.Space) && this.elapsedShootTime > ShootInterval)
            {
                this.elapsedShootTime = 0;
                this.Shoot();
            }
        }

        public override void Intersect(IGameObject obj)
        {
        }

        public void GiveHealth(int amount)
        {
            this.Health += amount;
        }

        public override void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(this.healthBar, this.healthRectangle, Color.White);
            spriteBatch.Draw(this.shieldBar, this.shieldRectangle, Color.White);
            spriteBatch.Draw(this.Texture, this.Position, Color.White);

            this.Stats.Draw(spriteBatch);
            //HealthText.Draw(spriteBatch);
            //ShieldText.Draw(spriteBatch);
            //ScoreText.Draw(spriteBatch);
        }

        public void AddShield(int amount)
        {
            if (this.Shield + amount > MaxShield)
            {
                this.Shield = MaxShield;
            }
            else
            {
                this.Shield += amount;
            }
        }

        void Shoot()
        {
            this.Owner.AddObject(new Bullet(this.Position));
        }
    }
}