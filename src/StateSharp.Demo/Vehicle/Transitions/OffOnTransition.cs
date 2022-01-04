using StateSharp;
using System;

namespace StateSharp.Demo.Vehicle.Transitions
{
    public class OffOnTransition : IStateTransition
    {
        public IState CurrentState => VehicleState.Off;

        public ICommand Command => VehicleCommand.Start;

        public IState ResultingState => VehicleState.On;

        public void TransitionAction()
        {
            Console.Out.WriteLine("The Vehicle is turning on.");
        }
    }
}
