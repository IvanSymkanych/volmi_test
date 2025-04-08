namespace Game.UI
{
    public interface IGameUIMediator
    {
        void Initialize();
        void ShowStartGamePage();
        void ShowGamePage();
        void ShowGameOverPage();
    }
}