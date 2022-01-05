﻿using System;

namespace StateSharp.Demo.Vehicle.Transitions
{
    public class OnMovingTransition : IStateTransition<VehicleStateMachineContext>
    {
        public IState CurrentState => VehicleState.On;

        public ICommand Command => VehicleCommand.Accelerate;

        public IState ResultingState => VehicleState.Moving;

        public void TransitionAction(VehicleStateMachineContext context)
        {
            Console.Out.WriteLine("The Vehicle is moving.");
        }
    }
}
