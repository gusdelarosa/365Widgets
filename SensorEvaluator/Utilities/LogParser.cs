using SensorEvaluator.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SensorEvaluator.Utilities
{
    public class LogParser : ILogContentParser
    {
        private IControlledEnvironment _controlRoom;
        private List<Device> _devices;
        public LogParser(string logContent, IDeviceFactory deviceFactory)
        {

            _devices = new List<Device>();
            var lines = logContent.Split(Environment.NewLine);

            Device currentDevice = null;
            foreach (var line in lines)
            {
                var lineSplit = line.Split(' ');
                bool isReading = DateTime.TryParseExact(lineSplit[0], "yyyy-MM-ddTHHmm", null, System.Globalization.DateTimeStyles.None, out DateTime parsedDate);

                if (lineSplit[0].Contains("reference"))
                {
                    var temp = decimal.Parse(lineSplit[1]);
                    var hum = decimal.Parse(lineSplit[2]);
                    var co = decimal.Parse(lineSplit[3]);
                    _controlRoom = new ControlledRoom(temp, hum, co);
                }
                else if (isReading)
                {
                    var reading = decimal.Parse(lineSplit[1]);
                    currentDevice.AddReading(reading);
                }
                else //if (split[0].Contains("thermometer") || split[0].Contains("humidity") || split[0].Contains("monoxide"))
                {
                    var name = lineSplit[1];
                    currentDevice = deviceFactory.CreateDevice(lineSplit[0], name);
                    if (currentDevice != null)
                    {
                        _devices.Add(currentDevice);
                    }

                }
            }

        }

        public IControlledEnvironment GetControlRoom()
        {
            return _controlRoom;
        }

        public ICollection<Device> GetDevices()
        {
            return _devices;
        }
    }
}
