using SOLID_Samples.Interfaces;
using SOLID_Samples.Models;

namespace SOLID_Samples.Helpers
{
    public class WeatherMapper : IWeatherMapper
    {
        public string AnotherFeature(string input)
        {
            throw new NotImplementedException();
        }

        public int SampleFeature(string input)
        {
            throw new NotImplementedException();
        }

        public Weather ToDomainModel(WeatherEntity entity)
        {
            return new Weather
            {
                Date = entity.Date,
                TempCelcius = entity.TemperatureC,
                WeatherSummary = entity.Summary,
                TempFahrenheit = entity.TemperatureF
            };
        }

        public WeatherEntity ToEntity(Weather model)
        {
            return new WeatherEntity
            {
                Date = model.Date,
                TemperatureC = model.TempCelcius,
                Summary = model.WeatherSummary,
                TemperatureF = model.TempFahrenheit
            };
        }
    }
}
