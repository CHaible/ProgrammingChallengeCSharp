using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProgrammingChallenge.Data.Interfaces
{
	public interface DataReader
	{
		List<Dictionary<string, string>> ReadData(string path);
	}
}
