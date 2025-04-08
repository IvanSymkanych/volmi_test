using Core.GlobalServices.AssetService;
using Core.GlobalServices.CurtainService;
using Core.GlobalServices.LogService;
using Core.GlobalServices.SceneService;
using Core.StateMachine.Global;
using Core.StateMachine.StateFactory;
using VContainer;
using VContainer.Unity;

namespace Core.ScopeInstaller
{
    public sealed class GlobalLifetimeScope : LifetimeScope
    {
        private void Start() => DontDestroyOnLoad(gameObject);
        
        protected override void Configure(IContainerBuilder builder)
        {
           RegisterGlobalService(builder); 
           RegisterStateMachine(builder);
        }

        private static void RegisterGlobalService(IContainerBuilder builder)
        {
            builder.Register<IAssetProviderGlobalService, AssetProviderGlobalService>(Lifetime.Singleton);
            builder.Register<ILogGlobalService, LogGlobalService>(Lifetime.Singleton);
            builder.Register<ISceneLoadGlobalService, SceneLoadGlobalService>(Lifetime.Singleton);
            builder.Register<ICurtainGlobalService, CurtainGlobalService>(Lifetime.Singleton);
        }
        
        private static void RegisterStateMachine(IContainerBuilder builder)
        {
            builder.Register<IStateFactory, StatesFactory>(Lifetime.Singleton);
            builder.Register<GlobalStateMachine>(Lifetime.Singleton).AsImplementedInterfaces().AsSelf();

            builder.Register<BootStateGlobal>(Lifetime.Scoped);
            builder.Register<LobbyStateGlobal>(Lifetime.Scoped);
            builder.Register<GameStateGlobal>(Lifetime.Scoped);
        }
    }
}