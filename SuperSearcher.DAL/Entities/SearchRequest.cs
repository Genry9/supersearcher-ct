using System;
using System.Collections.Generic;
using System.Text;

namespace SuperSearcher.DAL.Entities
{
	public class SearchRequest
	{
		
		public string Term { get; set; }
		public DateTime At { get; set; }

		public string fromFolder { get; set; }

		public SearchRequest()
		{
			At = DateTime.UtcNow;
		}

		public SearchRequest(string fromFolder, string searchTerm):this()
		{

		}
	}
}
