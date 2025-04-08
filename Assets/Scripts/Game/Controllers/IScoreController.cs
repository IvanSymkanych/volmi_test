namespace Game.Controllers
{
    public interface IScoreController
    {
        int Score { get; }
        void AddScore(int score);
        void GameOver();
    }
}