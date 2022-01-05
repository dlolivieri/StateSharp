using System;

namespace StateSharp.Demo.Vehicle.Transitions
{
    public class OffOnTransition : IStateTransition<VehicleStateMachineContext>
    {
        public IState CurrentState => VehicleState.Off;

        public ICommand Command => VehicleCommand.Start;

        public IState ResultingState => VehicleState.On;

        public void TransitionAction(VehicleStateMachineContext context)
        {
            context.VehicleMessage = "The Vehicle is turning on.";
        }
    }
}
