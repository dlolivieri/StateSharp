using StateSharp.Demo.Vehicle;
using System;

namespace StateSharp.Demo
{
    class Program
    {
        static void Main(string[] args)
        {
            ConfiguredStateMachineDemo();

            FluentStateMachineDemo();
        }

        public static void ConfiguredStateMachineDemo()
        {
            var context = new VehicleStateMachineContext();
            var stateMachine = new VehicleStateMachine(context);
            DemoStateMachine(stateMachine, context);
        }

        public static void FluentStateMachineDemo()
        {
            Action<VehicleStateMachineContext, string> vehicleAction = (context, message) =>
            {
                context.VehicleMessage = message;
            };

            var offOnTransition = new StateTransition<VehicleStateMachineContext>()
                .InState(VehicleState.Off)
                .When(VehicleCommand.Start)
                .Do((context) => { vehicleAction(context, "The Vehicle is turning on"); })
                .ToState(VehicleState.On);

            var onOffTransition = new StateTransition<VehicleStateMachineContext>()
                .InState(VehicleState.On)
                .When(VehicleCommand.TurnOff)
                .Do((context) => { vehicleAction(context, "The Vehicle is turning off"); })
                .ToState(VehicleState.Off);

            var onMovingTransition = new StateTransition<VehicleStateMachineContext>()
                .InState(VehicleState.On)
                .When(VehicleCommand.Accelerate)
                .Do((context) => { vehicleAction(context, "The Vehicle is moving."); })
                .ToState(VehicleState.Moving);

            var movingOnTransition = new StateTransition<VehicleStateMachineContext>()
                .InState(VehicleState.Moving)
                .When(VehicleCommand.Brake)
                .Do((context) => { vehicleAction(context, "The vehicle has stopped moving."); })
                .ToState(VehicleState.On);

            var context = new VehicleStateMachineContext();
            var stateMachine = new VehicleStateMachine(context, new[] { offOnTransition, onOffTransition, onMovingTransition, movingOnTransition });

            DemoStateMachine(stateMachine, context);
        }

        public static void DemoStateMachine(VehicleStateMachine stateMachine, VehicleStateMachineContext context)
        {
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
