namespace SpaceWars.Core
{
    using System;
    using System.IO;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using Microsoft.Xna.Framework.Graphics;

    public static class Data
    {
        private static readonly List<int> score = new List<int>();
        private static string path = "Core/highscore.txt";
        private static SpriteBatch spriteBatch;


        //public static Stringer OutputWriter { get; set; }
        public static ICollection<int> Score { get; set; }

        public static void AddScore(int score)
        {
            bool scoreExists = false;
            string[] readText = File.ReadAllLines(path);

            using (StreamReader reader = new StreamReader(path))
            {
                int smallestResult = 0;
                int index = 0;

                for (int i = 0; i < readText.Length; i++)
                {
                    if (int.Parse(readText[i]) < smallestResult)
                    {
                        smallestResult = int.Parse(readText[i]);
                        index = i;
                    }
                }

                if (score > smallestResult)
                {
                    if (readText.Length > 0)
                    {
                        readText[index] = score.ToString();
                    }
                    else
                    {
                        File.WriteAllLines(path, new string[] { score.ToString()});
                    }
                }
            }


            using (StreamWriter writer = new StreamWriter(path, true))
            {
                writer.WriteLine("{0}", score);
            }



        }

        //this method loads all the scores from a file to a List, it is called internally in PrintScores method

        private static void LoadScore()
        {
            Score = new List<int>();
            StreamReader reader = new StreamReader(path);
            using (reader)
            {
                string currentScore = reader.ReadLine();
                while (currentScore != null)
                {
                    Score.Add(int.Parse(currentScore));
                    currentScore = reader.ReadLine();
                }
            }
        }
        //this method is called in HighScoreScreen class to show the top ten scores
        public static string GetHighScore()
        {
            LoadScore();
            StringBuilder output = new StringBuilder();
            if (Score.Any())
            {
                var sortedScores = Score.OrderByDescending(x => x).Take(10);

                int index = 1;
                foreach (int score in sortedScores.Distinct())
                {
                    output.AppendFormat("{0,2}.{1,6}{2}", index, score, Environment.NewLine);
                    index++;
                }
            }
            return output.ToString();
        }


        public static int GetLastScore()
        {
            LoadScore();
            int lastScore = Score.Last();
            return lastScore;
        }
    }
}
