using SuperSearcher.BLL.Interfaces;
using SuperSearcher.DAL.Entities;
using SuperSearcher.DAL.Interfaces;

using System;
using System.Collections.Generic;
using System.Linq;

namespace SuperSearcher.BLL.Services
{
	public class HistoryService : IHistoryService
	{
		IGenericRepository<SearchRequest> _repo;
		public HistoryService(IGenericRepository<SearchRequest> repo)
		{
			this._repo = repo;
		}

		public void AddRecord(SearchRequest record)
		{
			_repo.Create(record);
		}

		public IEnumerable<SearchRequest> GetHistory(string userName = "", int lastXRecords = 0)
		{
			var result = _repo.Get().Where(x =>x.UserId != null && x.UserId.Contains(userName));

			if (lastXRecords > 0)
				result = result.OrderByDescending(x => x.At).Take(lastXRecords);

			return result;
		}
	}
}
