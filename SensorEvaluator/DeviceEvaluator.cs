
using SensorEvaluator.Utilities;
using System.Text.Json;

namespace SensorEvaluator
{
    public static class DeviceEvaluator
    {
        public static string EvaluateLogFile(string logContentsStr)
        {
            ILogContentParser logParser = new LogParser(logContentsStr, new DeviceFactory());
            
            var testEnvironment = new DeviceTestEnvironment(logParser.GetControlRoom(), logParser.GetDevices());
            
            var results = testEnvironment.Results();
            var output = JsonSerializer.Serialize(results);
            return output;
        }
    }
}