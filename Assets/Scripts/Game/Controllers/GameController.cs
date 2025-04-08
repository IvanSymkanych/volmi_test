using Core.GlobalServices.ConfigService;
using Core.StateMachine.Base;
using Core.StateMachine.Global;
using Cysharp.Threading.Tasks;
using Game.ChunkSystem;
using Game.Factory;
using Game.Player;
using VContainer.Unity;

namespace Game.Controllers
{
    public class GameController : IGameController ,IStartable
    {
        private readonly GameConfigsSO _gameConfigs;
        private readonly IGameFactory _gameFactory;
        private readonly ILevelController _levelController;
        private readonly IStateMachine _globalStateMachine;
        private readonly IScoreController _scoreController;
        
        private PlayerController _player;

        public GameController(GameConfigsSO gameConfigs, IGameFactory gameFactory, ILevelController levelController, GlobalStateMachine globalStateMachine, IScoreController scoreController)
        {
            _gameConfigs = gameConfigs;
            _gameFactory = gameFactory;
            _levelController = levelController;
            _globalStateMachine = globalStateMachine;
            _scoreController = scoreController;
        }

        public void Start()
        {
            _player = _gameFactory.CreatePlayer(); 
            _player.Initialize();
            
            _levelController.Initialize(_player.transform); 
            StartGame();
        }

        public void StartGame()
        {
            _player.StartGame();
            _levelController.GameOver();
        }

        public void GameOver()
        {
            _levelController.GameOver();
            _scoreController.GameOver();
        }

        public void GoToLobby()
        {
            _globalStateMachine.Enter<LobbyState>().Forget();
        }
    }
}