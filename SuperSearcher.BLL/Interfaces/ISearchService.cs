using System;
using System.Collections.Generic;
using System.Text;

namespace SuperSearcher.BLL.Interfaces
{
	interface ISearchService
	{

		IEnumerable<string> GetDrives();
		IEnumerable<string> GetDirectories(string inFolder);
		IEnumerable<string> GetFiles(string inFolder);
		IEnumerable<string> Search(string inFolder, string searchTerm);
	}
}
