using Microsoft.AspNetCore.Components;
using Microsoft.IdentityModel.Tokens;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SuperSearcher.BAWeb.VM
{
	public class FileSystemVM : BaseDriveVM
	{
        [Inject]
        protected SuperSearcher.BLL.Services.SearchService searcher { get; set; }

        [Parameter]
        public string path { get; set; }

        public List<string> folders { get; set; } = new List<string>();
        public List<string> files { get; set; } = new List<string>();

		protected override void OnInitialized()
		{
			base.OnInitialized();
		}

		protected override void OnParametersSet()
		{
			if (string.IsNullOrWhiteSpace(path))
			{
				folders = searcher.GetDrives().ToList();
			}
			else
			{
				var decodedPath = Base64UrlEncoder.Decode(path);
				folders = searcher.GetDirectories(decodedPath).ToList();
				files = searcher.GetFiles(decodedPath).ToList();
			}
			base.OnParametersSet();
		}


	}
}
