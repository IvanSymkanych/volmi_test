using System.Threading;
using Core.StateMachine.Base;
using Cysharp.Threading.Tasks;
using VContainer.Unity;

namespace Core.StateMachine.Global
{
    public sealed class Bootstrapper : IAsyncStartable
    {
        private readonly IStateMachine _globalStateMachine;
        
        public Bootstrapper(GlobalStateMachine globalStateMachine) => _globalStateMachine = globalStateMachine;

        public async UniTask StartAsync(CancellationToken cancellation)
        {
            await _globalStateMachine.Enter<BootStateGlobal>();
            await _globalStateMachine.Enter<LobbyStateGlobal>();
            await _globalStateMachine.Enter<GameStateGlobal>();
        }
    }
}