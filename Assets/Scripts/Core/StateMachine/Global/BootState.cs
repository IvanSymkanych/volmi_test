using Core.GlobalServices.CurtainService;
using Core.GlobalServices.LogService;
using Core.StateMachine.Base;
using Cysharp.Threading.Tasks;

namespace Core.StateMachine.Global
{
    public sealed class BootState : IState
    {
        private readonly ILogGlobalService _logGlobalService;
        private readonly ICurtainGlobalService _curtainGlobalService;
        private readonly GlobalStateMachine _globalStateMachine;

        public BootState(
            ILogGlobalService logGlobalService,
            ICurtainGlobalService curtainGlobalService)
        {
            _logGlobalService = logGlobalService;
            _curtainGlobalService = curtainGlobalService;
        }

        public async UniTask Enter()
        {
            _logGlobalService.Log("BootState Entered)");
            _curtainGlobalService.Initialize();
            _curtainGlobalService.Show(false);
        }

        public async UniTask Exit() => _logGlobalService.Log("BootState Exited)");
    }
}