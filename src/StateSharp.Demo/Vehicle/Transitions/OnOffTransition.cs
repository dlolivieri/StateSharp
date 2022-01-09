using System;

namespace StateSharp.Demo.Vehicle.Transitions
{
    public class OnOffTransition : IStateTransition<VehicleStateMachineContext>
    {
        public IState CurrentState => VehicleState.On;

        public ICommand Command => VehicleCommand.TurnOff;

        public IState ResultingState => VehicleState.Off;

        public Action<VehicleStateMachineContext> TransitionAction => (context) =>
        {
            context.VehicleMessage = "The Vehicle is turning off.";
        };
    }
}
