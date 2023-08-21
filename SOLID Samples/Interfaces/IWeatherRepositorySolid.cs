using SOLID_Samples.Models;

namespace SOLID_Samples.Interfaces
{
    public interface IWeatherRepositorySolid
    {
        Task<IEnumerable<Weather>> GetAllAsync();
        Task AddAsync(Weather weather);
    }
}
