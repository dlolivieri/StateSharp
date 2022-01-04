using System;

namespace StateSharp
{
    public sealed class StateTransitionKey : Tuple<IState, ICommand>, IStateTransitionKey
    {
        public IState CurrentState => Item1;
        public ICommand TransitionCommand => Item2;

        public StateTransitionKey(IState currentState, ICommand command)
            : base(currentState, command)
        {
            _ = currentState ?? throw new ArgumentNullException(nameof(currentState));
            _ = currentState.Name ?? throw new ArgumentNullException(nameof(currentState.Name));

            _ = command ?? throw new ArgumentNullException(nameof(currentState));
            _ = command.Name ?? throw new ArgumentNullException(nameof(currentState.Name));
        }
    }
}
