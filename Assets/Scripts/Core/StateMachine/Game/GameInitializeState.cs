using Core.GlobalServices.AssetService;
using Core.GlobalServices.CurtainService;
using Core.GlobalServices.LogService;
using Core.StateMachine.Base;
using Core.StateMachine.Global;
using Cysharp.Threading.Tasks;

namespace Core.StateMachine.Game
{
    public sealed class GameInitializeState : IState
    {
        private readonly IAssetProviderGlobalService _assetProviderGlobalService;
        private readonly ILogGlobalService _logGlobalService;
        private readonly ICurtainGlobalService _curtainGlobalService;
        private readonly GlobalStateMachine _globalStateMachine;

        public GameInitializeState(
            IAssetProviderGlobalService assetProviderGlobalService,
            ILogGlobalService logGlobalService,
            ICurtainGlobalService curtainGlobalService)
        {
            _assetProviderGlobalService = assetProviderGlobalService;
            _logGlobalService = logGlobalService;
            _curtainGlobalService = curtainGlobalService;
        }

        public async UniTask Enter()
        {
            _logGlobalService.Log("GameInitializeState Enter)");
        }

        public async UniTask Exit()
        {
            _logGlobalService.Log("GameInitializeState Exit)");
        }
    }
}