using Microsoft.AspNetCore.Components;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SuperSearcher.BAWeb.VM
{
	public class BaseDriveVM:BaseVM
	{

		[Inject]
		protected SuperSearcher.BLL.Services.SearchService driveSearcher { get; set; }
	}
}
