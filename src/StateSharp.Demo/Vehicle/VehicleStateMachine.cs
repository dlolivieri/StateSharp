using StateSharp;
using StateSharp.Demo.Vehicle.Transitions;

namespace StateSharp.Demo.Vehicle
{
    public class VehicleStateMachine : StateMachine
    {
        protected override bool ThrowOnInvalidTransition => false;

        public VehicleStateMachine()
        {
            CurrentState = VehicleState.Off;

            AddTransition(new OffOnTransition());
            AddTransition(new OnOffTransition());
            AddTransition(new OnMovingTransition());
            AddTransition(new MovingOnTransition());
        }


    }
}
