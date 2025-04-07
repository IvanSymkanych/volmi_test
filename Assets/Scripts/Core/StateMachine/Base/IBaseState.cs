
using Cysharp.Threading.Tasks;

namespace Core.StateMachine.Base
{
    public interface IBaseState
    {
        UniTask Exit();
    }
}