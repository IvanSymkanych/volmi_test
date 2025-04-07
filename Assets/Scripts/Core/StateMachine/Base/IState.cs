using Cysharp.Threading.Tasks;

namespace Core.StateMachine.Base
{
    public interface IState : IBaseState
    {
        UniTask Enter();
    }
}