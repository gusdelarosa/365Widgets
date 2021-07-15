namespace SensorEvaluator.Models
{
    public interface IControlledEnvironment
    {
         decimal GetTemperature();
         decimal GetHumidity();
         decimal GetCOValue();
    }
}