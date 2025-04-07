using Core.StateMachine.Base;
using VContainer;

namespace Core.StateMachine.StateFactory
{
    public sealed class StatesFactory : IStateFactory
    {
         private readonly IObjectResolver _objectResolver;

         public StatesFactory(IObjectResolver objectResolver) => 
             _objectResolver = objectResolver;
         
         public TState Create<TState>() where TState : IBaseState => 
             _objectResolver.Resolve<TState>();
    }
}