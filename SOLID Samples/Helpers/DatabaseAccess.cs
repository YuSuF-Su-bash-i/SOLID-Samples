using SOLID_Samples.Interfaces;
using SOLID_Samples.Models;
using System.Text.Json;

namespace SOLID_Samples.Helpers
{
    public class DatabaseAccess : IDatabaseAccess
    {
        private readonly string _dataFilePath;

        public DatabaseAccess(string filePath)
        {
            _dataFilePath = filePath;
        }

        public async Task<IEnumerable<WeatherEntity>> Read()
        {
            var rawData = File.ReadAllText(_dataFilePath);

            var entities = JsonSerializer.Deserialize<IEnumerable<WeatherEntity>>(rawData);

            return entities;
        }

        public async Task WriteAsync(WeatherEntity entity)
        {
            var allEntities = await Read();
            allEntities.ToList().Add(entity);
            
            foreach(var item in allEntities)
            {
                Console.WriteLine(JsonSerializer.Serialize(item));
            }
        }
    }
}
