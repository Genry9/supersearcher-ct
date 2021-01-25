using SuperSearcher.BLL.Interfaces;
using SuperSearcher.BLL.Models.Search;

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace SuperSearcher.BLL.Services
{
	public class SearchService : ISearchService, IDriveSearcher
	{

		private readonly int _limit = 10;
		private readonly List<DriveSearchResult> _found = new List<DriveSearchResult>();

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

			IEnumerable<string> drives = GetDrives();

			foreach (string item in drives)
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


			if (_found.Count >= _limit)
			{
				return;
			}

			foreach (string item in GetDirectories(inFolder))
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

	}

}
