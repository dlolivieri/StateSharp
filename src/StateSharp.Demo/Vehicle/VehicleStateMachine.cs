using StateSharp.Demo.Vehicle.Transitions;

namespace StateSharp.Demo.Vehicle
{
    public class VehicleStateMachine : StateMachine<VehicleStateMachineContext>
    {
        protected override bool ThrowOnInvalidTransition => false;

        public VehicleStateMachine(VehicleStateMachineContext context)
            : base(context)
        {
            CurrentState = VehicleState.Off;

            AddTransition(new OffOnTransition());
            AddTransition(new OnOffTransition());
            AddTransition(new OnMovingTransition());
            AddTransition(new MovingOnTransition());
        }
    }
}
