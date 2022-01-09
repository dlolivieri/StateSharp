using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StateSharp
{
    public class StateTransition<T> : IStateTransition<T> where T : class
    {
        public IState CurrentState { get; protected set; }

        public ICommand Command { get; protected set; }

        public IState ResultingState { get; protected set; }

        public Action<T> TransitionAction { get; protected set; }

        public StateTransition<T> InState(IState currentState)
        {
            _ = currentState ?? throw new ArgumentNullException(nameof(currentState));

            CurrentState = currentState;

            return this;
        }

        public StateTransition<T> When(ICommand command)
        {
            _ = command ?? throw new ArgumentNullException(nameof(command));

            Command = command;

            return this;
        }

        public StateTransition<T> Do(Action<T> action)
        {
            _ = action ?? throw new ArgumentNullException(nameof(action));
            
            TransitionAction = action;

            return this;
        }

        public StateTransition<T> ToState(IState state)
        {
            _ = state ?? throw new ArgumentNullException(nameof(state));

            ResultingState = state;

            return this;
        }
    }
}
