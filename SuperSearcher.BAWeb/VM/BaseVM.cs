using Microsoft.AspNetCore.Components;

namespace SuperSearcher.BAWeb.VM
{
	public class BaseVM:ComponentBase
	{

		public string Error { get; set; }

		public bool busy { get; set; } = false;
	}
}
