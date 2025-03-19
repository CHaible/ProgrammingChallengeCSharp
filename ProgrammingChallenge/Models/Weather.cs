using ProgrammingChallenge.Resources;

public class Weather
{
	/// <summary>
	/// Number of day
	/// </summary>
	public int Day { get; }

	/// <summary>
	/// Maximum temperature on this day
	/// </summary>
	public int MaxTemp { get; }

	/// <summary>
	/// Minimum temperature on this day
	/// </summary>
	public int MinTemp { get; }

	/// <summary>
	/// Constructor for the Weather class with validation of the parameters, initializes properties
	/// </summary>
	/// <param name="day">Number of day</param>
	/// <param name="minTemp">Minimum temperature on this day</param>
	/// <param name="maxTemp">Maximum temperature on this day</param>
	/// <exception cref="ArgumentException"></exception>
	public Weather(int day, int minTemp, int maxTemp)
	{
		if (day < 0) throw new ArgumentOutOfRangeException(nameof(day), Resources.errorDayNegative);
		if (minTemp > maxTemp) throw new ArgumentException(Resources.errorTemperaturesInvalid);

		Day = day;
		MinTemp = minTemp;
		MaxTemp = maxTemp;
	}

	/// <summary>
	/// Calculates the temperature spread of the day
	/// </summary>
	/// <returns></returns>
	public int CalculateTemperatureSpread()
	{
		return MaxTemp - MinTemp;
	}
}