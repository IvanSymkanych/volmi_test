using Game.ChunkSystem;
using Game.Controllers;
using Game.Factory;
using VContainer;
using VContainer.Unity;

namespace Core.ScopeInstaller
{
    public sealed class GameLifetimeScope : LifetimeScope
    {
        protected override void Configure(IContainerBuilder builder)
        {
            builder.RegisterEntryPoint<GameController>(Lifetime.Scoped);

            builder.Register<IGameFactory, GameFactory>(Lifetime.Scoped);
            builder.Register<LevelController>(Lifetime.Scoped).AsImplementedInterfaces();
            builder.Register<IScoreController, ScoreController>(Lifetime.Scoped);
        }
    }
}