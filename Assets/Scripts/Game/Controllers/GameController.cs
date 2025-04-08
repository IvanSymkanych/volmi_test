using Core.GlobalServices.ConfigService;
using Game.ChunkSystem;
using Game.Factory;
using VContainer.Unity;

namespace Game.Controllers
{
    public class GameController : IGameController ,IStartable
    {
        private readonly GameConfigsSO _gameConfigs;
        private readonly IGameFactory _gameFactory;
        private readonly ILevelController _levelController;

        public GameController(GameConfigsSO gameConfigs, IGameFactory gameFactory, ILevelController levelController)
        {
            _gameConfigs = gameConfigs;
            _gameFactory = gameFactory;
            _levelController = levelController;
        }

        public void Start()
        {
            var player = _gameFactory.CreatePlayer(); 
            player.Initialize();
            
            _levelController.Initialize(player.transform); 
        }

        private void Dispose()
        {
            _levelController.Dispose();
        }
    }
}