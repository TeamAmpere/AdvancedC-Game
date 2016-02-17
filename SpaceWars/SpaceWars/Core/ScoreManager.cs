namespace SpaceWars
{
    using System;

    public class ScoreManager
    {
        private int totalScore = 0;

        public ScoreManager()
        {
            this.TotalScore = totalScore;
        }
        
        public int TotalScore
        {
            get { return this.totalScore; }
            set
            {
                if (value < 0)
                {
                    throw new ArgumentException("Score cannot be negative");
                }
                this.totalScore = value;
            }
        }

        public void AddPoints(int points)
        {
            this.TotalScore += points;
        }
    }
}

