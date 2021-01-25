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
using SuperSearcher.BLL.Models.Search;

namespace SuperSearcher.BLL.Services
{
	public class SearchService : ISearchService, IDriveSearcher
	{

		private readonly int _limit = 10;
		private readonly List<DriveSearchResult> _found = new List<DriveSearchResult>();
		public SearchService()
		{


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

		public IEnumerable<ISearchResult> GetResults(string searchTerm, string inFolder)
		{

			_found.Clear();

			RecursiveSearch(inFolder, searchTerm);

			return _found;
		}
		public IEnumerable<ISearchResult> GetResults(string searchTerm)
		{
			_found.Clear();

			var drives = GetDrives();

			foreach (var item in drives)
			{

				RecursiveSearch(item, searchTerm);

			}



			return _found;
		}


		public void RecursiveSearch(string inFolder, string searchTerm)
		{

			_found.AddRange(
				Directory.GetFiles(inFolder)
				.Where(x => Path.GetFileName(x).Contains(searchTerm))
				.Select(x => new DriveSearchResult()
				{
					title = Path.GetFileName(x),
					description = Path.GetDirectoryName(x),
					link = x
				}));


			if (_found.Count < _limit)
			{
				foreach (var item in GetDirectories(inFolder))
				{
					try
					{
						RecursiveSearch(item, searchTerm);
					}
					catch (UnauthorizedAccessException ex)
					{
						return;
					}
				}
			}
			else
			{
				return;
			}
		}

	}

}
