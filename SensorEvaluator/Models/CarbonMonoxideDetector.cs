using System;

namespace SensorEvaluator.Models
{
    public class CarbonMonoxideDetector : Device
    {
        public CarbonMonoxideDetector(string name) : base(name, DeviceType.CO2Detector) { }

        public override string GetClassification(IControlledEnvironment controlEnv)
        {
            var controlCOValue = controlEnv.GetCOValue();
            foreach (var reading in Readings)
            {
                var abs = Math.Abs(controlCOValue - reading);
                if (abs > 3)
                {
                    return "discard";
                }
            }

            return "keep";
        }
    }
}