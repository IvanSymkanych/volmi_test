using System;

namespace Game.Controllers
{
    public interface IScoreController
    {
        event Action<int> OnScoreChange;
        int Score { get; }
        int HighScore { get; }
        void AddScore(int score);
        void GameOver();
    }
}