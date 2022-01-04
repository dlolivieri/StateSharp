namespace StateSharp
{
    public interface IStateTransitionKey
    {
        IState CurrentState { get; }

        ICommand TransitionCommand { get; }

        bool Equals(object obj);

        int GetHashCode();

        string ToString();
    }
}