using System;
using System.Collections.Generic;
using System.Text;

namespace SuperSearcher.BLL.Interfaces
{
	public interface ISearchService
	{

		
		IEnumerable<ISearchResult> GetResults(string searchTerm);
	}
}
