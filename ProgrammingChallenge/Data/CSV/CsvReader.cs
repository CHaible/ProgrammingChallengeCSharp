using ProgrammingChallenge.Data.Interfaces;
using ProgrammingChallenge.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProgrammingChallenge.Data.CSV
{
	public class CsvReader : DataReader
	{
		/// <summary>
		/// Separator used in CSV-Files
		/// </summary>
		public Char Separator { get; private set; }

		/// <summary>
		/// Constructor for the CsvReader class, initializes properties
		/// </summary>
		/// <param name="separator">Separator used in CSV-Files</param>
		public CsvReader(char separator)
		{
			Separator = separator;
		}

		/// <summary>
		/// Reads CSV-File and returns List of Dictionaries with header as key and value as value
		/// </summary>
		/// <param name="path"></param>
		/// <returns></returns>
		public List<Dictionary<string, string>> ReadData(string path)
		{
			var data = new List<Dictionary<string, string>>();
			try
			{
				using (var reader = new StreamReader(path))
				{
					var headers = reader.ReadLine()?.Split(Separator);
					if (headers == null) return data;

					string? line;
					while ((line = reader.ReadLine()) != null)
					{
						var values = line.Split(Separator);
						var row = new Dictionary<string, string>();
						for (int i = 0; i < headers.Length; i++)
						{
							row[headers[i]] = values[i];
						}
						data.Add(row);
					}
				}
			}
			catch (Exception e)
			{
				Console.WriteLine($"Error reading file {path}: {e.Message}");
			}
			return data;
		}
	}
}

