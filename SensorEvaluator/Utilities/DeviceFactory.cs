using SensorEvaluator.Models;

namespace SensorEvaluator.Utilities
{
    public class DeviceFactory : IDeviceFactory
    {
        public Device CreateDevice(string type, string deviceName)
        {
            Device device = null;
            switch (type)
            {
                case "thermometer":
                    device = new Thermometer(deviceName);
                    break;
                case "humidity":
                    device = new Hygrometer(deviceName);
                    break;
                case "monoxide":
                    device = new CarbonMonoxideDetector(deviceName);
                    break;
                default:
                    break;
            }
            return device;

        }
    }
}