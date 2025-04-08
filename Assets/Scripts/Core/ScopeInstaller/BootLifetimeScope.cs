using Core.StateMachine.Global;
using VContainer;
using VContainer.Unity;

namespace Core.ScopeInstaller
{
    public class BootLifetimeScope : LifetimeScope
    {
        protected override void Configure(IContainerBuilder builder)
        {
            builder.RegisterEntryPoint<Bootstrapper>(Lifetime.Scoped);
        }
    }
}