namespace SpaceWars.Interfaces
{
    using System.Collections.Generic;

    interface IData
    {
        ICollection<int> Score { get; }
        //void AddScore(int score, int time);
        void AddScore(int score);
        void PrintScore();
    }
}
