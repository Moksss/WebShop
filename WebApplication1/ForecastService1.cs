namespace WebApplication1
{
    public class ForecastService1 : IForecastService
    {
        private readonly DateTime _dateTime;

        private static readonly string[] Summaries = new[]
        {
        "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        };

        public ForecastService1()
        {
            _dateTime = DateTime.Now;
        }

        public IEnumerable<WeatherForecast> GetForecast()
        {

            return Enumerable.Range(1, 5).Select(index => new WeatherForecast
            {
                Date = _dateTime,
                TemperatureC = Random.Shared.Next(-20, 55),
                Summary = "Forecast service 1"
            })
.ToArray();
        }


    }
}
