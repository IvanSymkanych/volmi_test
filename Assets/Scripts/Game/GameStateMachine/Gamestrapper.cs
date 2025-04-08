using System.Threading;
using Core.StateMachine.Base;
using Cysharp.Threading.Tasks;
using VContainer.Unity;

namespace Game.GameStateMachine
{
    public sealed class Gamestrapper : IAsyncStartable
    {
        private readonly IStateMachine _gameStateMachine;
        
        public Gamestrapper(GameStateMachine gameStateMachine) => _gameStateMachine = gameStateMachine;
        
        public async UniTask StartAsync(CancellationToken cancellation)
        {
            await _gameStateMachine.Enter<GameInitializeState>();
            await _gameStateMachine.Enter<GameplayState>();
        }
    }
}