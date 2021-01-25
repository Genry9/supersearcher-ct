using System.Collections.Generic;

namespace SuperSearcher.BLL.Interfaces
{
	public interface ISearchService
	{

		
		IEnumerable<ISearchResult> GetResults(string searchTerm);
	}
}
