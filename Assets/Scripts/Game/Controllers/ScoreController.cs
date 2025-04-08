using System;
using System.Linq;
using Core.GlobalServices.SaveLoadService;

namespace Game.Controllers
{
    public class ScoreController : IScoreController
    {
        public event Action<int> OnScoreChange;
        public int Score { get; private set; }
        public int HighScore { get; private set; }

        private readonly ISaveLoadService _saveLoadService;

        public ScoreController(ISaveLoadService saveLoadService)
        {
            _saveLoadService = saveLoadService;
            HighScore = _saveLoadService.GameSaveModel.scoreList.Max();
        }

        public void AddScore(int score)
        {
            Score += score;
            OnScoreChange?.Invoke(Score);
        }

        public void GameOver()
        {
            _saveLoadService.GameSaveModel.scoreList.Add(Score);
            _saveLoadService.Save();
        }
    }
}