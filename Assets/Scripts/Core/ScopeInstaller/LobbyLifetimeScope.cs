using Lobby.Controller;
using Lobby.Factory;
using VContainer;
using VContainer.Unity;

namespace Core.ScopeInstaller
{
    public class LobbyLifetimeScope : LifetimeScope
    {
        protected override void Configure(IContainerBuilder builder)
        {
            builder.RegisterEntryPoint<LobbyController>(Lifetime.Scoped);

            builder.Register<ILobbyFactory, LobbyFactory>(Lifetime.Scoped);
        }
    }
}