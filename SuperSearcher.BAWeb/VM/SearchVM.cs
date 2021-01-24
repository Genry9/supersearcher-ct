using Microsoft.AspNetCore.Components;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SuperSearcher.BAWeb.VM
{
	public class SearchVM : ComponentBase
	{
		[Inject]
		protected SuperSearcher.BLL.Services.SearchService searcher { get; set; }

		[Parameter]
		public string q { get; set; }
		[Parameter]
		public string d { get; set; }
		public List<KeyValuePair<string, string>> searchResults { get; set; }

		public string[] drives { get; set; }

		public string Error { get; set; }

		public bool busy { get; set; } = false;
		protected override void OnInitialized()
		{
			drives = searcher.GetDrives().ToArray();
			base.OnInitialized();
		}


		public async Task Search()
		{
			busy = true;
			if(searchResults!=null)
				searchResults.Clear();

			if(!string.IsNullOrWhiteSpace(q) && !string.IsNullOrWhiteSpace(d))
			{
				try
				{

				searchResults = searcher.Search(d, q).Select(x=>new KeyValuePair<string,string>(System.IO.Path.GetFileName(x), x)).ToList();
				}
				catch(Exception ex)
				{
					Error = ex.Message;
				}
			}
			busy = false;
		}
	}
}
