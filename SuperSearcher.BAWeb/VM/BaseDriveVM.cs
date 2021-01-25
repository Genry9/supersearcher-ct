using Microsoft.AspNetCore.Components;

namespace SuperSearcher.BAWeb.VM
{
	public class BaseDriveVM:BaseVM
	{

		[Inject]
		protected SuperSearcher.BLL.Services.SearchService driveSearcher { get; set; }
	}
}
