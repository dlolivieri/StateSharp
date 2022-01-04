namespace StateSharp
{
    public interface IStateMachine
    {
        public IState CurrentState { get; }

        public void AddTransition(IStateTransition transition);

        public void ExecuteTransition(ICommand command);
    }
}
