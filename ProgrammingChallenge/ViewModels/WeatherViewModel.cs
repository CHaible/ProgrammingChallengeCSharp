namespace ProgrammingChallenge.ViewModels
{
	public class WeatherViewModel
	{
		/// <summary>
		/// Number of day
		/// </summary>
		public int Day { get; }

		/// <summary>
		/// Minimal temperature of this day
		/// </summary>
		public int MinTemp { get; }

		/// <summary>
		/// Maximum temperature of this day
		/// </summary>
		public int MaxTemp { get; }

		/// <summary>
		/// Temperature spread of this day
		/// </summary>
		public int TempSpread { get; }

		/// <summary>
		/// Constructor for the WeatherViewModel class with validation of the parameter, initializes properties
		/// </summary>
		/// <param name="weather">Weather with data</param>
		/// <exception cref="ArgumentNullException"></exception>
		public WeatherViewModel(Weather weather)
		{
			if (weather == null) throw new ArgumentNullException(nameof(weather));

			Day = weather.Day;
			MinTemp = weather.MinTemp;
			MaxTemp = weather.MaxTemp;
			TempSpread = weather.CalculateTemperatureSpread();
		}
	}
}