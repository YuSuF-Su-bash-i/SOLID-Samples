using SOLID_Samples.Interfaces;
using SOLID_Samples.Models;

namespace SOLID_Samples.Helpers
{
    public class WeatherMapperSolid : IWeatherMapperSolid
    {
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
