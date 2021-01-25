using SuperSearcher.DAL.Entities;

using System;
using System.Collections.Generic;
using System.Text;

namespace SuperSearcher.BLL.Interfaces
{
	public interface IHistoryService
	{
		IEnumerable<SearchRequest> GetHistory(int lastXRecords = 0);

		void AddRecord(SearchRequest record);
	}
}
