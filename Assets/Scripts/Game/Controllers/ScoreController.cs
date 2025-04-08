using Core.GlobalServices.SaveLoadService;

namespace Game.Controllers
{
    public class ScoreController : IScoreController
    {
        public int Score { get; private set; }
        
        private readonly ISaveLoadService _saveLoadService;

        public ScoreController(ISaveLoadService saveLoadService) => _saveLoadService = saveLoadService;

        public void AddScore(int score) => Score += score;

        public void GameOver() => _saveLoadService.GameSaveModel.scoreList.Add(Score);
    }
}