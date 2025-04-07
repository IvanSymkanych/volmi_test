using Cysharp.Threading.Tasks;

namespace Core.StateMachine.Base
{
    public interface IStateMachine
    {
        UniTask Enter<TState>() where TState : class, IState;
        UniTask Enter<TState, TPayload>(TPayload payload) where TState : class, IPayloadState<TPayload>;
    }
}