using System;

namespace StateSharp.Demo.Vehicle.Transitions
{
    public class OnOffTransition : IStateTransition
    {
        public IState CurrentState => VehicleState.On;

        public ICommand Command => VehicleCommand.TurnOff;

        public IState ResultingState => VehicleState.Off;

        public void TransitionAction()
        {
            Console.Out.WriteLine("The Vehicle is turning off.");
        }
    }
}
