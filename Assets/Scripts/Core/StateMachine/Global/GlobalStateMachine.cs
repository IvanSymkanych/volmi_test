using Core.StateMachine.Base;
using Core.StateMachine.StateFactory;

namespace Core.StateMachine.Global
{
    public sealed class GlobalStateMachine : StateMachineBase
    {
        public GlobalStateMachine(IStateFactory stateFactory) : base(stateFactory)
        {
            States.Add(typeof(BootStateGlobal), stateFactory.Create<BootStateGlobal>());
            States.Add(typeof(LobbyStateGlobal), stateFactory.Create<LobbyStateGlobal>());
            States.Add(typeof(GameStateGlobal), stateFactory.Create<GameStateGlobal>());
        }
    }
}