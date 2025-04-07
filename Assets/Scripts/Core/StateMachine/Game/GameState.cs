using Core.GlobalServices.LogService;
using Core.StateMachine.Base;
using Cysharp.Threading.Tasks;

namespace Core.StateMachine.Game
{
    public sealed class GameState : IState
    {
        private ILogGlobalService _logGlobalService;

        public GameState(ILogGlobalService logGlobalService)
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