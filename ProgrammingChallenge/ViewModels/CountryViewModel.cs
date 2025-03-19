using ProgrammingChallenge.Models;

namespace ProgrammingChallenge.ViewModels
{
	public class CountryViewModel
	{ 
		/// <summary>
		/// Country with data
		/// </summary>
		public Country Country { get; }

		/// <summary>
		/// Name of country
		/// </summary>
		public string Name { get; }

		/// <summary>
		/// Population density of country
		/// </summary>
		public double? PopulationDensity { get; }

		/// <summary>
		/// Constructor for the CountryViewModel class with validation of the parameter, initializes properties
		/// </summary>
		/// <param name="country">Country with data</param>
		/// <exception cref="ArgumentNullException"></exception>
		public CountryViewModel(Country? country)
		{
			Country = country ?? throw new ArgumentNullException(nameof(country));
			Name = country.Name;
			PopulationDensity = country.CalculatePopulationDensity();
		}

		/// <summary>
		/// Defines how to display the object as a string
		/// </summary>
		/// <returns></returns>
		public override string ToString()
		{
			return !string.IsNullOrWhiteSpace(Name) && PopulationDensity.HasValue
				? $"{Name}: {PopulationDensity:F2} {Resources.Resources.unitPopulationDensity}"
				: Resources.Resources.errorInvalidData;
		}
	}
}