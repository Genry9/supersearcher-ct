using System;
using System.Collections.Generic;
using System.Text;

namespace SuperSearcher.BLL.Interfaces
{
	public interface IDriveSearcher:ISearchService
	{
		IEnumerable<string> GetDrives();
		IEnumerable<string> GetDirectories(string inFolder);
		IEnumerable<string> GetFiles(string inFolder);
		IEnumerable<ISearchResult> GetResults(string searchTerm);
		IEnumerable<ISearchResult> GetResults(string searchTerm, string from);
	}
}
