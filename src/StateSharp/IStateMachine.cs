namespace StateSharp
{
    public interface IStateMachine<T> where T : class
    {
        /// <summary>
        /// The Current State of the State Machine
        /// </summary>
        public IState CurrentState { get; }

        /// <summary>
        /// Add a Transition to the State Machine's configuration
        /// </summary>
        /// <param name="transition">The Transition to add</param>
        public void AddTransition(IStateTransition<T> transition);

        /// <summary>
        /// Given an ICommand, execute the transition if it exists, and set CurrentState to ICommand.ResultingState
        /// </summary>
        /// <param name="command">The Command to attempt to execute</param>
        /// <returns>true if the command was found and executed, false otherwise</returns>
        public bool ExecuteTransition(ICommand command);
    }
}
