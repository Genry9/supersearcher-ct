using SuperSearcher.BLL.Models.Search;

using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace SuperSearcher.BLL.Interfaces
{
	public interface IWebSearcher:ISearchService
	{
		
		
		Task<IEnumerable<ISearchResult>> GetResultsAsync(string term);
	}
}
