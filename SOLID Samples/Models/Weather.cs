namespace SOLID_Samples.Models
{
    public class Weather
    {
        public DateTime Date { get; set; }

        public int TempCelcius { get; set; }

        public int TempFahrenheit { get; set; }

        public string? WeatherSummary { get; set; }
    }
}