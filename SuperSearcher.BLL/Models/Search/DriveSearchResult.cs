using SuperSearcher.BLL.Interfaces;

namespace SuperSearcher.BLL.Models.Search
{
	public class DriveSearchResult : ISearchResult
	{
		public string description { get; set; }
		public string link { get; set; }
		public string title { get; set; }
	}
}
