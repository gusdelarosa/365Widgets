using SensorEvaluator.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SensorEvaluator.Utilities
{
    public interface ILogContentParser
    {
        IControlledEnvironment GetControlRoom();
        ICollection<Device> GetDevices();
    }
}
