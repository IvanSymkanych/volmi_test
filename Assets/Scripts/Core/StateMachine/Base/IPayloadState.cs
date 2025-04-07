using Cysharp.Threading.Tasks;

namespace Core.StateMachine.Base
{
    public interface IPayloadState<TPayload> : IBaseState
    {
        UniTask Enter(TPayload payload);
    }
}