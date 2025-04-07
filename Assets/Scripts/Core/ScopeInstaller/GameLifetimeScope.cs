using Core.StateMachine.Game;
using Core.StateMachine.StateFactory;
using UnityEngine;
using VContainer;
using VContainer.Unity;

namespace Core.ScopeInstaller
{
    public sealed class GameLifetimeScope : LifetimeScope
    {
        protected override void Configure(IContainerBuilder builder)
        {
            RegisterStateMachine(builder);
        }
        
        private static void RegisterStateMachine(IContainerBuilder builder)
        {
            builder.Register<Gamestrapper>(Lifetime.Scoped).AsImplementedInterfaces().AsSelf();

            builder.Register<IStateFactory, StatesFactory>(Lifetime.Singleton);
            builder.Register<GameStateMachine>(Lifetime.Singleton).AsImplementedInterfaces().AsSelf();

            builder.Register<GameInitializeState>(Lifetime.Scoped);
            builder.Register<GameState>(Lifetime.Scoped);
        }
    }
}