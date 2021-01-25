using System;
using System.Collections.Generic;
using System.Text;

namespace SuperSearcher.DAL.Entities
{
	public class SearchRequest
	{
		public int Id { get; set; }
		public string Term { get; set; }
		public DateTime At { get; set; }

		public string UserId { get; set; }
		public string fromFolder { get; set; }

		public SearchRequest()
		{
			At = DateTime.UtcNow;
		}

		public SearchRequest(string fromFolder, string searchTerm):this()
		{
			this.fromFolder = fromFolder;
			this.Term = searchTerm;
		}
	}
}
