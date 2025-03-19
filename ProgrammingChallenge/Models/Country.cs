namespace ProgrammingChallenge.Models
{
	public class Country
	{
		/// <summary>
		/// Name of country
		/// </summary>
		public string Name { get; }

		/// <summary>
		/// Population of country
		/// </summary>
		public int Population { get; }

		/// <summary>
		/// Area of country in km²
		/// </summary>
		public int Area { get; }

		/// <summary>
		/// Constructor for the Country class with validation of the parameters, initializes properties
		/// </summary>
		/// <param name="name">Name of country</param>
		/// <param name="population">Population of country</param>
		/// <param name="area">Area of country in km²</param>
		/// <exception cref="ArgumentException"></exception>
		/// <exception cref="ArgumentOutOfRangeException"></exception>
		public Country(string name, int population, int area)
		{
			if (string.IsNullOrWhiteSpace(name)) throw new ArgumentException(Resources.Resources.errorNameEmpty, nameof(name));
			if (population < 0) throw new ArgumentOutOfRangeException(nameof(population), Resources.Resources.errorPopulationNegative);
			if (area <= 0) throw new ArgumentOutOfRangeException(nameof(area), Resources.Resources.errorAreaInvalid);

			Name = name;
			Population = population;
			Area = area;
		}

		/// <summary>
		/// Calculates the population density of the country
		/// </summary>
		/// <returns></returns>
		public double CalculatePopulationDensity()
		{
			return (double)Population / Area;
		}
	}
}