using SensorEvaluator.Models;
using System.Collections.Generic;


namespace SensorEvaluator
{
    public class DeviceTestEnvironment
    {

        private readonly IControlledEnvironment _controlRoom;
        private readonly ICollection<Device> _devices;
        private Dictionary<string, string> _classifications;

        public DeviceTestEnvironment(IControlledEnvironment controlRoom, ICollection<Device> devices)
        {
            _controlRoom = controlRoom;
            _devices = devices;
        }

        internal Dictionary<string, string> Results()
        {
            if (_classifications != null)
            {
                return _classifications;
            }

            _classifications = new Dictionary<string, string>();
            foreach (var device in _devices)
            {

                _classifications.Add(device.Name, device.GetClassification(_controlRoom));
            }

            return _classifications;
        }
    }
}
