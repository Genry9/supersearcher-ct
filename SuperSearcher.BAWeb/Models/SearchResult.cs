using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SuperSearcher.BAWeb.Models
{
	public class SearchResult
	{
		public string Title { get; set; }
		public string Description { get; set; }
		public string Link { get; set; }
		public bool isLocal { get; set; }
	}
}
