﻿using System;

namespace StateSharp
{
    public interface IStateTransition
    {
        /// <summary>
        /// The Current State that the IStateMachine has to be in
        /// </summary>
        IState InState { get; }

        /// <summary>
        /// Command which transitions from the InState to the ToState
        /// </summary>
        ICommand Command { get; }

        /// <summary>
        /// The action that occurs when transitioning
        /// </summary>
        void TransitionAction();

        /// <summary>
        /// The State that the IStateMachine will be in after TransitionAction() is called
        /// </summary>
        IState ToState { get; }
    }
}
