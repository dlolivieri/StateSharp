using System;

namespace StateSharp.Demo.Vehicle.Transitions
{
    public class OnMovingTransition : IStateTransition<VehicleStateMachineContext>
    {
        public IState CurrentState => VehicleState.On;

        public ICommand Command => VehicleCommand.Accelerate;

        public IState ResultingState => VehicleState.Moving;

        public Action<VehicleStateMachineContext> TransitionAction => (context) =>
        {
            context.VehicleMessage = "The Vehicle is moving.";
        };
    }
}
