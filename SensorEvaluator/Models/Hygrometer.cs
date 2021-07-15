using System;

namespace SensorEvaluator.Models
{
    public class Hygrometer : Device
    {
        public Hygrometer(string name) : base(name, DeviceType.Hygrometer) { }

        public override string GetClassification(IControlledEnvironment controlEnv)
        {
            var controlHumidity = controlEnv.GetHumidity();
            foreach (var reading in Readings)
            {
                var abs = Math.Abs(controlHumidity - reading);
                if (abs >= 1)
                {
                    return "discard";
                }
            }

            return "keep";
        }
    }
}