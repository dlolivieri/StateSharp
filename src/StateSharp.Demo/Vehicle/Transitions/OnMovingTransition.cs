using StateSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StateSharp.Demo.Vehicle.Transitions
{
    public class OnMovingTransition : IStateTransition
    {
        public IState CurrentState => VehicleState.On;

        public ICommand Command => VehicleCommand.Accelerate;

        public IState ResultingState => VehicleState.Moving;

        public void TransitionAction()
        {
            Console.Out.WriteLine("The Vehicle is moving.");
        }
    }
}
