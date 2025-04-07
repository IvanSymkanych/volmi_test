using Cysharp.Threading.Tasks;

namespace Core.GlobalServices.SceneService
{
    public interface ISceneLoadGlobalService
    {
        UniTask Load(string sceneName);
    }
}