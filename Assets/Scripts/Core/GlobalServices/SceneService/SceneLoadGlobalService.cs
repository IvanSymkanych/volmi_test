using Core.GlobalServices.LogService;
using Cysharp.Threading.Tasks;
using UnityEngine.AddressableAssets;

namespace Core.GlobalServices.SceneService
{
    public sealed class SceneLoadGlobalService : ISceneLoadGlobalService
    {
        private readonly ILogGlobalService _logGlobalService;

        public SceneLoadGlobalService(ILogGlobalService logGlobalService) => _logGlobalService = logGlobalService;

        public async UniTask Load(string sceneName)
        {
            var handler = Addressables.LoadSceneAsync(sceneName);
            await handler.ToUniTask();
            await handler.Result.ActivateAsync().ToUniTask();
        }
    }
}