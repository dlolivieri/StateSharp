using System;

namespace StateSharp.Demo.Vehicle.Transitions
{
    public class MovingOnTransition : IStateTransition
    {
        public IState CurrentState => VehicleState.Moving;

        public ICommand Command => VehicleCommand.Brake;

        public IState ResultingState => VehicleState.On;

        public void TransitionAction()
        {
            Console.Out.WriteLine("The vehicle has stopped moving.");
        }
    }
}
