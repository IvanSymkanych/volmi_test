using Core.GlobalServices.ConfigService;
using Game.Factory;
using UI;

namespace Game.UI
{
    public class GameUIMediator : IGameUIMediator
    {
        private BasePageView _startGamePage;
        private BasePageView _gameOverPage;
        private BasePageView _gamePage;

        private BasePageView _selectedPage;
        
        private readonly IGameFactory _gameFactory;
        private readonly GameConfigsSO _gameConfigs;

        public GameUIMediator(IGameFactory gameFactory, GameConfigsSO gameConfigs)
        {
            _gameFactory = gameFactory;
            _gameConfigs = gameConfigs;
        }

        public void Initialize()
        {
            _startGamePage = _gameFactory.CreatePage(_gameConfigs.StartGamePagePrefab);
            _gameOverPage = _gameFactory.CreatePage(_gameConfigs.GameOverPagePrefab);
            _gamePage = _gameFactory.CreatePage(_gameConfigs.GamePagePrefab);
        }

        public void ShowStartGamePage()
        {
            HideSelectedPage();
            
            _selectedPage = _startGamePage;
            _selectedPage.Initialize();
            _selectedPage.Show();
        }

        public void ShowGamePage()
        {
            HideSelectedPage();
            
            _selectedPage = _gamePage;
            _selectedPage.Initialize();
            _selectedPage.Show();
        }

        public void ShowGameOverPage()
        {
            HideSelectedPage();
            
            _selectedPage = _gameOverPage;
            _selectedPage.Initialize();
            _selectedPage.Show();
        }

        private void HideSelectedPage()
        {
            if (_selectedPage != null)
            {
                _selectedPage.Hide();
                _selectedPage.Dispose();
            }
        }
    }
}