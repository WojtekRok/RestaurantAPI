namespace RestaurantAPI
{
    public interface IWeatherForecastService
    {
        public IEnumerable<WeatherForecast> GetForecasts(int count, int minTemp, int maxTemp);
    }
}