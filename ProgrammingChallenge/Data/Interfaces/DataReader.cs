using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProgrammingChallenge.Data.Interfaces
{
	public interface DataReader
	{
		/// <summary>
		/// Reads File and returns List of Dictionaries
		/// </summary>
		/// <param name="path">Path to file containing data</param>
		/// <returns></returns>
		List<Dictionary<string, string>> ReadData(string path);
	}
}
