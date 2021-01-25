using SuperSearcher.DAL.Entities;

using System.Collections.Generic;

namespace SuperSearcher.BLL.Interfaces
{
	public interface IHistoryService
	{
		IEnumerable<SearchRequest> GetHistory(string userName = "",int lastXRecords = 0);

		void AddRecord(SearchRequest record);
	}
}
