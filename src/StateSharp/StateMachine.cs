using System;
using System.Collections.Generic;

namespace StateSharp
{
    public abstract class StateMachine : IStateMachine
    {
        internal Dictionary<IStateTransitionKey, IStateTransition> Transitions = new Dictionary<IStateTransitionKey, IStateTransition>();

        protected abstract bool ThrowOnInvalidTransition { get; }

        public IState CurrentState { get; protected set; }

        public void AddTransition(IStateTransition transition)
        {
            _ = transition ?? throw new ArgumentNullException(nameof(transition));

            IStateTransitionKey key = new StateTransitionKey(transition.CurrentState, transition.Command);

            //do not allow overwrites
            if (Transitions.ContainsKey(key))
                throw new ArgumentException(nameof(transition));

            Transitions.Add(key, transition);
        }

        public bool HasNextTransition(ICommand command)
        {
            return HasNextTransition(CurrentState, command);
        }

        protected bool HasNextTransition(IState currentState, ICommand command)
        {
            return Transitions.ContainsKey(new StateTransitionKey(currentState, command));
        }

        public void ExecuteTransition(ICommand command)
        {
            IStateTransition transition;

            //TryGetValue is faster than a ContainsKey(key) check followed by a transition = Transitions[key]
            if (Transitions.TryGetValue(new StateTransitionKey(CurrentState, command), out transition))
            {
                transition.TransitionAction();
                CurrentState = transition.ResultingState;
                return;
            }

            if(ThrowOnInvalidTransition)
                throw new InvalidOperationException($"State Machine has no transition defined for Current State {CurrentState} with Command {command}");
        }
    }
}
