namespace Game.Controllers
{
    public class ScoreController : IScoreController
    {
        public int Score { get; private set; }
        public void AddScore(int score) => Score += score;
    }
}