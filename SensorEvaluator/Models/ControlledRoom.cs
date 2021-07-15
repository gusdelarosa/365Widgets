namespace SensorEvaluator.Models
{
    public class ControlledRoom : IControlledEnvironment
    {

        private decimal _temp;
        private decimal _humidity;
        private decimal _coValue;

        public ControlledRoom(decimal temp, decimal humidity, decimal coValue)
        {
            _temp = temp;
            _humidity = humidity;
            _coValue = coValue;
        }
        public decimal GetCOValue()
        {
            return _coValue;
        }

        public decimal GetHumidity()
        {
            return _humidity;            
        }

        public decimal GetTemperature()
        {
            return _temp;            
        }
    }
}