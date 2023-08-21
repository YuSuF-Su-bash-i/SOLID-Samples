using SOLID_Samples.Helpers;
using SOLID_Samples.Interfaces;
using SOLID_Samples.Models;
using System.Text.Json;

namespace SOLID_Samples.Repositories
{
    public class WeatherRepository : IWeatherRepository
    {
        private readonly string _dataFilePath = "WeatherDb.json";

        public async Task<IEnumerable<Weather>> GetAllAsync()
        {
            if (!File.Exists(_dataFilePath))
                throw new FileNotFoundException("Weather data file not found.");

            WeatherMapper mapper = new WeatherMapper();

            var jsonData = await File.ReadAllTextAsync(_dataFilePath);
            var weatherEntities = JsonSerializer.Deserialize<IEnumerable<WeatherEntity>>(jsonData);

            var result = weatherEntities.Select(entity => mapper.ToDomainModel(entity)).ToList();

            return result;
        }

        public async Task AddAsync(Weather weather)
        {
            var weatherData = (await GetAllAsync()).ToList();
            weatherData.Add(weather);

            var updatedData = JsonSerializer.Serialize(weatherData);
            await File.WriteAllTextAsync(_dataFilePath, updatedData);
        }
    }
    /*
     * Right now we do violate all the SOLID principles in return of short term benefits. Which is mostly just pushing the code out the door quick.
     *      
     * 
     ****** SOLID Principles are;
     * 
     *** Single responsibility (SRP):
     *  Every class should have a single responsibility.
     *  A class should have only one reason to change.
       
     *** Open-Closed Principle (OCP):
     *  Software entities should be open for extension but closed for modification.
     *  This means that the behavior of a module can be extended without modifying its source code. So you should be able to add new features without modifying the existing code.
       
     *** Liskov Substitution Principle (LSP):
     *  Subtypes must be substitutable for their base types.
     *  If a program is using a base class, it should be able to use any of its subclasses without knowing it.
       
     *** Interface Segregation Principle (ISP):
     *  Clients should not be forced to depend upon interfaces they do not use.
     *  It's better to have several specific interfaces than a single all-encompassing one.
       
     *** Dependency Inversion Principle (DIP):
     *  High-level modules should not depend on low-level modules. Both should depend on abstractions.
     *  Abstractions should not depend on details. Details should depend on abstractions.
     * 
     * 
     * 
     *** Issues in our approach:
     * SRP: 
     * Repo is handling reading/writing files and also JSON serialization/deserialization. This violates the Single Responsibility Principle as it's managing multiple concerns.
     *
     * OCP: 
     * If we want to change the storage mechanism (e.g., move from JSON file storage to a database or utilize different api to reach database), we'd have to modify WeatherRepository. This goes against the Open/Closed Principle.
     * 
     * LSP: 
     * There isn't much context in our given code for this principle. However, if we had base classes and derived classes, we'd need to ensure substitutability.
     * 
     * ISP:
     * We use WeatherMapper here and since that mapper's interface includes way more than just weather mapping, we had to return throws in some of those interfaces as we don't need them.
     * 
     * DIP:
     * We use tightly coupled concrete classes (WeatherMapper.cs).
     */
}
