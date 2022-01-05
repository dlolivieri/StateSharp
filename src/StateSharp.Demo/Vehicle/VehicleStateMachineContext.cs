using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StateSharp.Demo.Vehicle
{
    public class VehicleStateMachineContext : IStateMachineContext
    {
        public string VehicleMessage { get; set; } = string.Empty;
    }
}
