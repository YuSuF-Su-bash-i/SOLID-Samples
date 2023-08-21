using SOLID_Samples.Helpers;
using SOLID_Samples.Interfaces;
using SOLID_Samples.Models;
using System.Text.Json;

namespace SOLID_Samples.Repositories
{
    public class WeatherRepositorySolid : IWeatherRepositorySolid
    {
        private readonly IDatabaseAccess _databaseAccess;
        private readonly IWeatherMapperSolid _mapper;
        public WeatherRepositorySolid(IDatabaseAccess databaseAccess, IWeatherMapperSolid mapper)
        {
            _databaseAccess = databaseAccess;
            _mapper = mapper;
        }

        public async Task AddAsync(Weather weather)
        {
            var entity = _mapper.ToEntity(weather);

            await _databaseAccess.WriteAsync(entity);
        }

        public async Task<IEnumerable<Weather>> GetAllAsync()
        {
            var allWeatherEntities = await _databaseAccess.Read();
            var result = allWeatherEntities.Select(a=> _mapper.ToDomainModel(a));
            return result;
        }
    }
}
