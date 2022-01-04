using StateSharp.Demo.Vehicle;

namespace StateSharp.Demo
{
    class Program
    {
        static void Main(string[] args)
        {
            IStateMachine stateMachine = new VehicleStateMachine();

            stateMachine.ExecuteTransition(VehicleCommand.Start);
            stateMachine.ExecuteTransition(VehicleCommand.Accelerate);
            stateMachine.ExecuteTransition(VehicleCommand.Brake);
            stateMachine.ExecuteTransition(VehicleCommand.TurnOff);
        }
    }
}
