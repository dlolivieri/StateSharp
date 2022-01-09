using System;

namespace StateSharp.Demo.Vehicle.Transitions
{
    public class MovingOnTransition : IStateTransition<VehicleStateMachineContext>
    {
        public IState CurrentState => VehicleState.Moving;

        public ICommand Command => VehicleCommand.Brake;

        public IState ResultingState => VehicleState.On;

        public Action<VehicleStateMachineContext> TransitionAction => (context) =>
        {
            context.VehicleMessage = "The vehicle has stopped moving.";
        };
    }
}
