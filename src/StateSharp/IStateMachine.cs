namespace StateSharp
{
    public interface IStateMachine
    {
        /// <summary>
        /// The Current State of the State Machine
        /// </summary>
        public IState CurrentState { get; }

        /// <summary>
        /// Add a Transition to the State Machine's configuration
        /// </summary>
        /// <param name="transition">The Transition to add</param>
        public void AddTransition(IStateTransition transition);

        /// <summary>
        /// Given an ICommand, execute the transition if it exists, and set CurrentState to ICommand.ResultingState
        /// </summary>
        /// <param name="command">The Command to attempt to execute</param>
        public void ExecuteTransition(ICommand command);
    }
}
