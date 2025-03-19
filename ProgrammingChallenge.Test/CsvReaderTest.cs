using Xunit;
using ProgrammingChallenge.Data.CSV;

namespace ProgrammingChallenge.Test
{
	public class CsvReaderTest
	{
		private const string TestFilePath = "test.csv";

		/// <summary>
		/// Erstellt eine temporäre Testdatei mit angegebenem Inhalt.
		/// </summary>
		private void CreateTestFile(string content)
		{
			File.WriteAllText(TestFilePath, content);
		}

		/// <summary>
		/// Löscht die Testdatei nach der Ausführung eines Tests.
		/// </summary>
		private void CleanupTestFile()
		{
			if (File.Exists(TestFilePath))
			{
				File.Delete(TestFilePath);
			}
		}

		[Fact]
		public void ReadData_ValidCsv_ReturnsCorrectData()
		{
			// Arrange
			var csvContent = "Day,MxT,MnT\n1,88,59\n2,79,63";
			CreateTestFile(csvContent);
			var reader = new CsvReader(',');

			// Act
			var result = reader.ReadData(TestFilePath);

			// Assert
			Assert.Equal(2, result.Count);
			Assert.Equal("88", result[0]["MxT"]);
			Assert.Equal("59", result[0]["MnT"]);
			Assert.Equal("79", result[1]["MxT"]);
			Assert.Equal("63", result[1]["MnT"]);

			CleanupTestFile();
		}

		[Fact]
		public void ReadData_EmptyFile_ReturnsEmptyList()
		{
			// Arrange
			CreateTestFile("");
			var reader = new CsvReader(',');

			// Act
			var result = reader.ReadData(TestFilePath);

			// Assert
			Assert.Empty(result);

			CleanupTestFile();
		}

		[Fact]
		public void ReadData_MissingFile_ReturnsEmptyList()
		{
			// Arrange
			var reader = new CsvReader(',');

			// Act
			var result = reader.ReadData("non_existing_file.csv");

			// Assert
			Assert.Empty(result);
		}

		[Fact]
		public void ReadData_InconsistentRowLength_IgnoresMissingValues()
		{
			// Arrange
			var csvContent = "Day,MxT,MnT\n1,88\n2,79,63";
			CreateTestFile(csvContent);
			var reader = new CsvReader(',');

			// Act
			var result = reader.ReadData(TestFilePath);

			// Assert
			Assert.Equal(2, result.Count);
			Assert.Equal("88", result[0]["MxT"]);
			Assert.False(result[0].ContainsKey("MnT")); // Fehlender Wert in der ersten Zeile
			Assert.Equal("63", result[1]["MnT"]); // Korrekte Werte für Zeile 2

			CleanupTestFile();
		}

		[Fact]
		public void ReadData_CustomSeparator_WorksCorrectly()
		{
			// Arrange
			var csvContent = "Day|MxT|MnT\n1|88|59\n2|79|63";
			CreateTestFile(csvContent);
			var reader = new CsvReader('|');

			// Act
			var result = reader.ReadData(TestFilePath);

			// Assert
			Assert.Equal(2, result.Count);
			Assert.Equal("88", result[0]["MxT"]);
			Assert.Equal("59", result[0]["MnT"]);

			CleanupTestFile();
		}
	}
}