using SuperSearcher.BLL.Interfaces;
using SuperSearcher.DAL.Entities;
using SuperSearcher.DAL.Interfaces;

using System;
using System.IO;
using System.Linq;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace SuperSearcher.BLL.Services
{
	public class SearchService : ISearchService
	{
		private readonly IGenericRepository<SearchRequest> _searchRepo;
		private readonly int _limit = 10;
		private readonly List<string> _found = new List<string>();
		public SearchService(IGenericRepository<SearchRequest> searchRepo)
		{
			this._searchRepo = searchRepo;

		}
		public IEnumerable<string> GetDirectories(string inFolder)
		{
			return Directory.GetDirectories(inFolder);
		}

		public IEnumerable<string> GetDrives()
		{
			return DriveInfo.GetDrives().Select(x => x.Name);
		}

		public IEnumerable<string> GetFiles(string inFolder)
		{
			return Directory.GetFiles(inFolder);
		}

		public IEnumerable<string> Search(string inFolder, string searchTerm)
		{
			_searchRepo.Create(new SearchRequest(inFolder, searchTerm));
			_found.Clear();

			var awaiter = RecursiveSearch(inFolder, searchTerm).ConfigureAwait(true).GetAwaiter();

			while (!awaiter.IsCompleted)
			{
				Thread.Sleep(500);
			}
			return _found;
		}

		public async Task RecursiveSearch(string inFolder, string searchTerm)
		{
			lock (_found)
			{
				_found.AddRange(Directory.GetFiles(inFolder).Where(x => Path.GetFileName(x).Contains(searchTerm)));
			}

			if (_found.Count < _limit)
			{
				foreach (var item in GetDirectories(inFolder))
				{
					Task.Run(async () => await RecursiveSearch(item, searchTerm));
				}
			}
			else
			{
				return;
			}
		}

	}

}
