using SensorEvaluator.Models;

namespace SensorEvaluator.Utilities
{
    public interface IDeviceFactory
    {
        Device CreateDevice(string type, string name);
    }
}