using System.Collections.Generic;

namespace SensorEvaluator.Models
{
    public abstract class Device
    {
        public string Name { get; set; }
        public DeviceType Type { get; private set; }

        public List<decimal> Readings { get; set; }

        public abstract string GetClassification(IControlledEnvironment controlEnv);


        public Device(string name, DeviceType type)
        {
            Name = name;
            Type = Type;
            Readings = new List<decimal>();
        }
        public void AddReading(decimal reading)
        {
            Readings.Add(reading);
        }


    }

    public enum DeviceType
    {
        Thermometer,
        Hygrometer,
        CO2Detector,
    }
}