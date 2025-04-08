using Core.GlobalServices.CurtainService;
using Core.GlobalServices.LogService;
using Core.GlobalServices.SceneService;
using Core.StateMachine.Base;
using Cysharp.Threading.Tasks;
using Helpers;

namespace Core.StateMachine.Global
{
    public sealed class GameState : IState
    {
        private readonly ILogGlobalService _logGlobalService;
        private readonly ICurtainGlobalService _curtainGlobalService;
        private readonly ISceneLoadGlobalService _sceneLoadGlobalService;

        public GameState(ILogGlobalService logGlobalService, ICurtainGlobalService curtainGlobalService, ISceneLoadGlobalService sceneLoadGlobalService)
        {
            _logGlobalService = logGlobalService;
            _curtainGlobalService = curtainGlobalService;
            _sceneLoadGlobalService = sceneLoadGlobalService;
        }

        public async UniTask Enter()
        {
            _curtainGlobalService.Show();            
            
            await _sceneLoadGlobalService.Load(ConstantHelper.GameSceneName);
            
            _logGlobalService.Log($"GameState Entered");
        }

        public async UniTask Exit() => _logGlobalService.Log($"GameState Exit");
    }
}