using Core.GlobalServices.AssetService;
using Core.GlobalServices.CurtainService;
using Core.GlobalServices.LogService;
using Core.GlobalServices.SceneService;
using Core.StateMachine.Base;
using Cysharp.Threading.Tasks;

namespace Core.StateMachine.Global
{
    public sealed class BootStateGlobal : IState
    {
        private readonly IAssetProviderGlobalService _assetProviderGlobalService;
        private readonly ILogGlobalService _logGlobalService;
        private readonly ICurtainGlobalService _curtainGlobalService;
        private readonly GlobalStateMachine _globalStateMachine;

        public BootStateGlobal(
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
            await _assetProviderGlobalService.InitializeAsync();
            
            _curtainGlobalService.Initialize();
            _curtainGlobalService.Show(false);
            _logGlobalService.Log("BootState Entered)");
        }

        public async UniTask Exit() => _logGlobalService.Log("BootState Exited)");
    }
}