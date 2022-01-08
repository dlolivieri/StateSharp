using System;
using System.Collections.Generic;

namespace StateSharp
{
    public abstract class StateMachine<T> : IStateMachine<T>
    {
        internal Dictionary<IComparable, IStateTransition<T>> Transitions = new Dictionary<IComparable, IStateTransition<T>>();

        protected abstract bool ThrowOnInvalidTransition { get; }

        public IState CurrentState { get; protected set; }

        public T Context { get; protected set; }

        public StateMachine(T context)
        {
            _ = context ?? throw new ArgumentNullException(nameof(context));

            Context = context;
        }

        public void AddTransition(IStateTransition<T> transition)
        {
            _ = transition ?? throw new ArgumentNullException(nameof(transition));

            IComparable key = GetStateTransitionKey(transition.CurrentState, transition.Command);

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
            return Transitions.ContainsKey(GetStateTransitionKey(currentState, command));
        }

        public bool ExecuteTransition(ICommand command)
        {
            IStateTransition<T> transition;

            //TryGetValue is faster than a ContainsKey(key) check followed by a transition = Transitions[key]
            if (Transitions.TryGetValue(GetStateTransitionKey(CurrentState, command), out transition))
            {
                transition.TransitionAction(Context);
                CurrentState = transition.ResultingState;
                return true;
            }

            if(ThrowOnInvalidTransition)
                throw new InvalidOperationException($"State Machine has no transition defined for Current State {CurrentState} with Command {command}");

            return false;
        }

        protected IComparable GetStateTransitionKey(IState state, ICommand command)
        {
            return new StateTransitionKey(state, command);
        }
    }
}
