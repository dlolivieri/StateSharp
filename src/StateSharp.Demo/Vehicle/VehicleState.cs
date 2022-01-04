using StateSharp;

namespace StateSharp.Demo.Vehicle
{
    public class VehicleState : Enumeration, IState
    {
        public static VehicleState Off = new VehicleState(nameof(Off), 0);
        public static VehicleState On = new VehicleState(nameof(On), 1);
        public static VehicleState Moving = new VehicleState(nameof(Moving), 2);
        

        public VehicleState(string name, int value) 
            : base(name, value)
        {

        }
    }
}
