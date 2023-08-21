using SOLID_Samples.Models;

namespace SOLID_Samples.Interfaces
{
    public interface IDatabaseAccess
    {
        Task<IEnumerable<WeatherEntity>> Read();
        Task WriteAsync(WeatherEntity entity);
    }
}
