using Core.StateMachine.Base;
using Core.StateMachine.StateFactory;

namespace Core.StateMachine.Global
{
    public sealed class GlobalStateMachine : StateMachineBase
    {
        public GlobalStateMachine(IStateFactory stateFactory) : base(stateFactory)
        {
            States.Add(typeof(BootState), stateFactory.Create<BootState>());
            States.Add(typeof(LobbyState), stateFactory.Create<LobbyState>());
            States.Add(typeof(GameState), stateFactory.Create<GameState>());
        }
    }
}