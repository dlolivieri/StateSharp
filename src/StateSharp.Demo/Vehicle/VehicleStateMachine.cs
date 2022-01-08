using StateSharp.Demo.Vehicle.Transitions;
using System;

namespace StateSharp.Demo.Vehicle
{
    public class VehicleStateMachine : StateMachine<VehicleStateMachineContext>
    {
        public VehicleStateMachine(VehicleStateMachineContext context)
            : base(context)
        {
            CurrentState = VehicleState.Off;

            AddTransition(new OffOnTransition());
            AddTransition(new OnOffTransition());
            AddTransition(new OnMovingTransition());
            AddTransition(new MovingOnTransition());
        }

        public override bool ExecuteTransition(ICommand command)
        {
            bool result = base.ExecuteTransition(command);

            if(!result)
                throw new InvalidOperationException($"Vehicle State Machine has no transition defined for Current State {CurrentState} with Command {command}");

            return result;
        }
    }
}
