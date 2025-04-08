using Core.GlobalServices.LogService;
using Cysharp.Threading.Tasks;
using UnityEngine.SceneManagement;

namespace Core.GlobalServices.SceneService
{
    public sealed class SceneLoadGlobalService : ISceneLoadGlobalService
    {
        private readonly ILogGlobalService _logGlobalService;

        public SceneLoadGlobalService(ILogGlobalService logGlobalService) => _logGlobalService = logGlobalService;
        
        public async UniTask Load(string sceneName)
        {
            _logGlobalService.Log($"[SceneLoad] Loading scene: {sceneName}");

            var operation = SceneManager.LoadSceneAsync(sceneName);
            
            await operation.ToUniTask();

            _logGlobalService.Log($"[SceneLoad] Scene loaded: {sceneName}");
        }
    }
}