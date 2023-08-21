using SOLID_Samples.Helpers;
using SOLID_Samples.Interfaces;
using SOLID_Samples.Repositories;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//Repositories
builder.Services.AddTransient<IWeatherRepository, WeatherRepository>();
builder.Services.AddTransient<IWeatherRepositorySolid, WeatherRepositorySolid>();

//Helpers
builder.Services.AddSingleton<IWeatherMapper, WeatherMapper>();
builder.Services.AddSingleton<IWeatherMapperSolid, WeatherMapperSolid>();
builder.Services.AddSingleton<IDatabaseAccess, DatabaseAccess>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
