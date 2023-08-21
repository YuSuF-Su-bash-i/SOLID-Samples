using SOLID_Samples.Models;

namespace SOLID_Samples.Interfaces
{
    public interface IWeatherMapperSolid
    {
        Weather ToDomainModel(WeatherEntity entity);
        WeatherEntity ToEntity(Weather model);
    }
}
