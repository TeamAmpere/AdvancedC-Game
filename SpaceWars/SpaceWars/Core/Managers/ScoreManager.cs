namespace SpaceWars.Core.Managers
{
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq.Expressions;

    public class ScoreManager
    {
        private int totalScore = 0;

        public ScoreManager()
        {
            this.TotalScore = this.totalScore;
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

