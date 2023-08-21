using SOLID_Samples.Models;

namespace SOLID_Samples.Interfaces
{
    public interface IWeatherMapper
    {
        Weather ToDomainModel(WeatherEntity entity);
        WeatherEntity ToEntity(Weather model);
        int SampleFeature(string input);
        string AnotherFeature(string input);
    }
}
