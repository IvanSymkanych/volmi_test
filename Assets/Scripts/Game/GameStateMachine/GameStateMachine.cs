using Core.StateMachine.Base;
using Core.StateMachine.StateFactory;

namespace Game.GameStateMachine
{
    public sealed class GameStateMachine : StateMachineBase
    {
        public GameStateMachine(IStateFactory stateFactory) : base(stateFactory)
        {
            States.Add(typeof(GameInitializeState), stateFactory.Create<GameInitializeState>());
            States.Add(typeof(GameplayState), stateFactory.Create<GameplayState>());
        }
    }
}