using System;

namespace StateSharp
{
    /// <summary>
    /// Key to store and identify unique StateTransitions in the StateMachine
    /// </summary>
    public interface IStateTransitionKey : IComparable
    {
        //IState CurrentState { get; }

        //ICommand TransitionCommand { get; }

        bool Equals(object obj);

        int GetHashCode();

        string ToString();
    }
}