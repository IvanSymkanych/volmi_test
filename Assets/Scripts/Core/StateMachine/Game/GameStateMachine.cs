using Core.StateMachine.Base;
using Core.StateMachine.StateFactory;

namespace Core.StateMachine.Game
{
    public sealed class GameStateMachine : StateMachineBase
    {
        public GameStateMachine(IStateFactory stateFactory) : base(stateFactory)
        {
            States.Add(typeof(GameInitializeState), stateFactory.Create<GameInitializeState>());
            States.Add(typeof(GameState), stateFactory.Create<GameState>());
        }
    }
}