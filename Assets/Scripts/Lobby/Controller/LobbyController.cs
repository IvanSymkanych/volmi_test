using Core.GlobalServices.ConfigService;
using Core.GlobalServices.CurtainService;
using Core.StateMachine.Base;
using Core.StateMachine.Global;
using Lobby.Factory;
using UI;
using VContainer.Unity;

namespace Lobby.Controller
{
    public class LobbyController : ILobbyController , IStartable
    {
        private readonly GameConfigsSO _gameConfigs;
        private readonly ILobbyFactory _lobbyFactory;
        private readonly IStateMachine _globalStateMachine;
        private readonly ICurtainGlobalService _curtainGlobalService;
        
        private BasePageView _basePageView;

        public LobbyController(GameConfigsSO gameConfigs, ILobbyFactory lobbyFactory, GlobalStateMachine globalStateMachine, ICurtainGlobalService curtainGlobalService)
        {
            _gameConfigs = gameConfigs;
            _lobbyFactory = lobbyFactory;
            _globalStateMachine = globalStateMachine;
            _curtainGlobalService = curtainGlobalService;
        }

        public void Start()
        {
            _basePageView = _lobbyFactory.CreatePage(_gameConfigs.LobbyMainPageView);
            _basePageView.Initialize();
            _basePageView.Show();
            
            _curtainGlobalService.Hide();
        }

        public void GoToGameState() => _globalStateMachine.Enter<GameState>();
    }
}