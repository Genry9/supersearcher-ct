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

		public IEnumerable<SearchRequest> GetHistory(int lastXRecords = 0)
		{
			if (lastXRecords > 0)
				return _repo.Get().OrderByDescending(x=>x.At).Take(lastXRecords);
			else
				return _repo.Get();
		}
	}
}
