using Xunit;
using ProgrammingChallenge.Data.CSV;

namespace ProgrammingChallenge.Test
{
	public class CsvReaderTest
	{
		[Fact]
		public void ReadDataTest()
		{
			CsvReader reader = new CsvReader(',');
			List<Dictionary<string, string>> result = reader.ReadData("TestData/weather.csv");
			Assert.Equal(3, result.Count);
			Assert.Equal("73", result[0]["MnT"]);
		}

		[Fact]
		public void ConstructorTest()
		{
			CsvReader reader = new CsvReader('z');
			Assert.Equal('z', reader.Separator);
		}
	}
}