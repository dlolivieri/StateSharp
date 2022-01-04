using StateSharp;

namespace StateSharp.Demo.Vehicle
{
    public class VehicleCommand : Enumeration, ICommand
    {
        public static VehicleCommand Start = new VehicleCommand(nameof(Start), 0);
        public static VehicleCommand Accelerate = new VehicleCommand(nameof(Accelerate), 1);
        public static VehicleCommand Brake = new VehicleCommand(nameof(Brake), 3);
        public static VehicleCommand TurnOff = new VehicleCommand(nameof(TurnOff), 4);
        
        public VehicleCommand(string name, int id)
            : base(name, id)
        {

        }
    }
}
