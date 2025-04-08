using Core.GlobalServices.CurtainService;
using Core.StateMachine.Base;
using Core.StateMachine.Global;
using Cysharp.Threading.Tasks;
using Game.ChunkSystem;
using Game.Factory;
using Game.Player;
using Game.UI;
using VContainer.Unity;

namespace Game.Controllers
{
    public class GameController : IGameController ,IStartable
    {
        private readonly IGameFactory _gameFactory;
        private readonly ILevelController _levelController;
        private readonly IStateMachine _globalStateMachine;
        private readonly IScoreController _scoreController;
        private readonly IGameUIMediator _gameUIMediator;
        private readonly ICurtainGlobalService _curtainGlobalService;
        
        private PlayerController _player;

        public GameController(IGameFactory gameFactory, ILevelController levelController, GlobalStateMachine globalStateMachine, 
            IScoreController scoreController, IGameUIMediator gameUIMediator, ICurtainGlobalService curtainGlobalService)
        {
            _gameFactory = gameFactory;
            _levelController = levelController;
            _globalStateMachine = globalStateMachine;
            _scoreController = scoreController;
            _gameUIMediator = gameUIMediator;
            _curtainGlobalService = curtainGlobalService;
        }

        public void Start()
        {
            _player = _gameFactory.CreatePlayer(); 
            _player.Initialize();
            
            _levelController.Initialize(_player.transform); 
            _gameUIMediator.Initialize();
            _gameUIMediator.ShowStartGamePage();
            
            Subscribe();
            
            _curtainGlobalService.Hide();
        }

        public void StartGame()
        {
            _player.StartGame();
            _levelController.StartGame();
            _gameUIMediator.ShowGamePage();
        }

        public void GameOver()
        {
            _levelController.GameOver();
            _scoreController.GameOver();
            _gameUIMediator.ShowGameOverPage();
        }

        public void GoToLobby()
        {
            Unsubscribe();
            _globalStateMachine.Enter<LobbyState>().Forget();
        }

        private void Subscribe() => _player.OnGameOver += GameOver;
        private void Unsubscribe() => _player.OnGameOver -= GameOver;
    }
}