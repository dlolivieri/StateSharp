using System;
using System.Collections.Generic;

namespace StateSharp
{
    public class StateMachine<T> : IStateMachine<T>
    {
        internal IDictionary<IComparable, IStateTransition<T>> Transitions;

        public IState CurrentState { get; protected set; }

        public T Context { get; protected set; }

        public StateMachine(T context)
        {
            _ = context ?? throw new ArgumentNullException(nameof(context));

            Context = context;
            Transitions = GetStateTransitionDictionary();
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

        public virtual bool ExecuteTransition(ICommand command)
        {
            IStateTransition<T> transition;

            //TryGetValue is faster than a ContainsKey(key) check followed by a transition = Transitions[key]
            if (Transitions.TryGetValue(GetStateTransitionKey(CurrentState, command), out transition))
            {
                transition.TransitionAction(Context);
                CurrentState = transition.ResultingState;
                return true;
            }

            return false;
        }

        protected virtual IComparable GetStateTransitionKey(IState state, ICommand command)
        {
            return new StateTransitionKey(state, command);
        }

        protected virtual IDictionary<IComparable, IStateTransition<T>> GetStateTransitionDictionary()
        {
            return new Dictionary<IComparable, IStateTransition<T>>();
        }
    }
}
