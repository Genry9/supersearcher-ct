using SuperSearcher.BLL.Interfaces;
using SuperSearcher.DAL.Entities;
using SuperSearcher.DAL.Interfaces;

using System;
using System.IO;
using System.Linq;
using System.Collections.Generic;
using System.Text;

namespace SuperSearcher.BLL.Services
{
	public class SearchService : ISearchService
	{
		private readonly IGenericRepository<SearchRequest> _searchRepo;


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
			return DriveInfo.GetDrives().Select(x=>x.Name);
		}

		public IEnumerable<string> GetFiles(string inFolder)
		{
			return Directory.GetFiles(inFolder);
		}

		public IEnumerable<string> Search(string inFolder, string searchTerm)
		{
			_searchRepo.Create(new SearchRequest(inFolder, searchTerm));
			return Directory.GetFiles(inFolder).Where(x => Path.GetFileName(x).Contains(searchTerm));
		}
	}

}
