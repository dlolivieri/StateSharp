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
            _ = command ?? throw new ArgumentNullException(nameof(currentState.Name));
        }

        public override bool Equals(object obj)
        {
            IStateTransitionKey other = obj as IStateTransitionKey;
            return other != null && CurrentState == other.CurrentState && TransitionCommand == other.TransitionCommand;
        }

        public override int GetHashCode()
        {
            //use prime numbers to avoid collisions
            int hash = 17;
            int hashFactor = 23;

            hash = hash * hashFactor + CurrentState.Name.GetHashCode();
            hash = hash * hashFactor + TransitionCommand.Name.GetHashCode();

            return hash;
        }

        public override string ToString()
        {
            return $"CurrentState: {CurrentState.Name}, TransitionCommand: {TransitionCommand.Name}";
        }
    }
}
