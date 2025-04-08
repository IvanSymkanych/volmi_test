using Core.GlobalServices.ConfigService;
using Core.GlobalServices.CurtainService;
using Core.GlobalServices.LogService;
using Core.GlobalServices.SaveLoadService;
using Core.GlobalServices.SceneService;
using Core.StateMachine.Global;
using Core.StateMachine.StateFactory;
using UnityEngine;
using VContainer;
using VContainer.Unity;

namespace Core.ScopeInstaller
{
    public sealed class GlobalLifetimeScope : LifetimeScope
    {
        [SerializeField] private GameConfigsSO gameConfigs;
        
        private void Start() => DontDestroyOnLoad(gameObject);
        
        protected override void Configure(IContainerBuilder builder)
        {
           RegisterGlobalService(builder); 
           RegisterStateMachine(builder);
           builder.RegisterInstance(gameConfigs);
        }

        private static void RegisterGlobalService(IContainerBuilder builder)
        {
            builder.Register<ILogGlobalService, LogGlobalService>(Lifetime.Singleton);
            builder.Register<ISceneLoadGlobalService, SceneLoadGlobalService>(Lifetime.Singleton);
            builder.Register<ICurtainGlobalService, CurtainGlobalService>(Lifetime.Singleton);
            builder.Register<ISaveLoadService, SaveLoadService>(Lifetime.Singleton);
        }
        
        private static void RegisterStateMachine(IContainerBuilder builder)
        {
            builder.Register<IStateFactory, StatesFactory>(Lifetime.Singleton);
            builder.Register<GlobalStateMachine>(Lifetime.Singleton).AsImplementedInterfaces().AsSelf();

            builder.Register<BootState>(Lifetime.Scoped);
            builder.Register<LobbyState>(Lifetime.Scoped);
            builder.Register<GameState>(Lifetime.Scoped);
        }
    }
}