using StateSharp.Demo.Vehicle;
using System;

namespace StateSharp.Demo
{
    class Program
    {
        static void Main(string[] args)
        {
            VehicleStateMachineContext context = new VehicleStateMachineContext();
            VehicleStateMachine stateMachine = new VehicleStateMachine(context);

            stateMachine.ExecuteTransition(VehicleCommand.Start);
            Console.Out.WriteLine(context.VehicleMessage);

            stateMachine.ExecuteTransition(VehicleCommand.Accelerate);
            Console.Out.WriteLine(context.VehicleMessage);

            stateMachine.ExecuteTransition(VehicleCommand.Brake);
            Console.Out.WriteLine(context.VehicleMessage);

            stateMachine.ExecuteTransition(VehicleCommand.TurnOff);
            Console.Out.WriteLine(context.VehicleMessage);
        }
    }
}
