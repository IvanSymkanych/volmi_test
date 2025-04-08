using Core.GlobalServices.LogService;
using Core.StateMachine.Base;
using Cysharp.Threading.Tasks;

namespace Game.GameStateMachine
{
    public sealed class GameplayState : IState
    {
        private readonly ILogGlobalService _logGlobalService;

        public GameplayState(ILogGlobalService logGlobalService)
        {
            _logGlobalService = logGlobalService;
        }

        public async UniTask Enter()
        {
            _logGlobalService.Log("GameState Enter)");
        }

        public async UniTask Exit()
        {
            _logGlobalService.Log("GameState Enter)");
        }
    }
}