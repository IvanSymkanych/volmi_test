using System;
using System.Collections.Generic;
using Core.StateMachine.StateFactory;
using Cysharp.Threading.Tasks;

namespace Core.StateMachine.Base
{
    public abstract class StateMachineBase : IStateMachine
    {
        protected readonly Dictionary<Type, IBaseState> States;
        private IBaseState _currentState;

        public StateMachineBase(IStateFactory stateFactory) => 
            States = new Dictionary<Type, IBaseState>();
        
        public async UniTask Enter<TState>() where TState : class, IState
        {
            TState newState = await ChangeState<TState>();
            await newState.Enter();
        }

        public async UniTask Enter<TState, TPayload>(TPayload payload) where TState : class, IPayloadState<TPayload>
        {
            var newState = await ChangeState<TState>();
            await newState.Enter(payload);
        }
        
        private async UniTask<TState> ChangeState<TState>() where TState : class, IBaseState
        {
            if(_currentState != null)
                await _currentState.Exit();
      
            var state = GetState<TState>();
            _currentState = state;
      
            return state;
        }
    
        private TState GetState<TState>() where TState : class, IBaseState => 
            States[typeof(TState)] as TState;
    }
}