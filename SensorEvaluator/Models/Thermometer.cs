using System;
using System.Linq;

namespace SensorEvaluator.Models
{
    public class Thermometer : Device
    {
        public Thermometer(string name) : base(name, DeviceType.Thermometer) { }

        public override string GetClassification(IControlledEnvironment controlledEnv)
        {
            string classification = string.Empty;
            var temp = controlledEnv.GetTemperature();
            var mean = Readings.Average();
            double stdDeviation = CalculateStdDev();
            var tempDiff = Math.Abs(temp - mean);

            if (tempDiff <= .5m)
            {
                if (stdDeviation < 3)
                {
                    return "ultra precise";
                }

                if (stdDeviation < 5)
                {
                    return "very precise";
                }
            }

            return "precise";
        }

        private double CalculateStdDev()
        {
            var mean = Readings.Average();
            double sumOfSquares = 0;

            foreach (var reading in Readings)
            {
                sumOfSquares += Math.Pow((double)(reading - mean), 2);
            }

            return Math.Sqrt(sumOfSquares / (Readings.Count - 1));
        }
    }
}