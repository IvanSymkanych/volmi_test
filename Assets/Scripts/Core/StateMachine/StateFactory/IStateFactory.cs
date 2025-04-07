using Core.StateMachine.Base;

namespace Core.StateMachine.StateFactory
{
    public interface IStateFactory
    {
        TState Create<TState>() where TState : IBaseState;
    }
}