namespace StateSharp
{
    public interface IStateTransition<T> where T : class
    {
        /// <summary>
        /// The Current State that the IStateMachine has to be in
        /// </summary>
        IState CurrentState { get; }

        /// <summary>
        /// Command which transitions from the CurrentState to the ResultingState
        /// </summary>
        ICommand Command { get; }

        /// <summary>
        /// The action that occurs when transitioning
        /// </summary>
        void TransitionAction(T context);

        /// <summary>
        /// The State that the IStateMachine will be in after TransitionAction() is called
        /// </summary>
        IState ResultingState { get; }
    }
}
