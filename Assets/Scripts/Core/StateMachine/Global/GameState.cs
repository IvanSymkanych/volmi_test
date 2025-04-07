using Core.GlobalServices.AssetService;
using Core.GlobalServices.CurtainService;
using Core.GlobalServices.LogService;
using Core.GlobalServices.SceneService;
using Core.StateMachine.Base;
using Cysharp.Threading.Tasks;

namespace Core.StateMachine.Global
{
    public sealed class GameState : IState
    {
        private readonly IAssetProviderGlobalService _assetProviderGlobalService;
        private readonly ILogGlobalService _logGlobalService;
        private readonly ICurtainGlobalService _curtainGlobalService;
        private readonly ISceneLoadGlobalService _sceneLoadGlobalService;

        public GameState(IAssetProviderGlobalService assetProviderGlobalService, ILogGlobalService logGlobalService, ICurtainGlobalService curtainGlobalService, ISceneLoadGlobalService sceneLoadGlobalService)
        {
            _assetProviderGlobalService = assetProviderGlobalService;
            _logGlobalService = logGlobalService;
            _curtainGlobalService = curtainGlobalService;
            _sceneLoadGlobalService = sceneLoadGlobalService;
        }

        public async UniTask Enter()
        {
            _curtainGlobalService.Show();            
            
            await _assetProviderGlobalService.WarmupAssetsByLabel(AssetLabels.GameLabel);
            await _sceneLoadGlobalService.Load(AssetAddress.Scene.GameScene);
            
            _curtainGlobalService.Hide();
            _logGlobalService.Log($"GameState Entered");
        }

        public async UniTask Exit()
        {
            await _assetProviderGlobalService.ReleaseAssetsByLabel(AssetLabels.GameLabel);
            _logGlobalService.Log($"GameState Exit");
        }
    }
}