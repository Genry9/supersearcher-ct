using Microsoft.AspNetCore.Components;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SuperSearcher.BAWeb.VM
{
	public class BaseVM:ComponentBase
	{

		public string Error { get; set; }

		public bool busy { get; set; } = false;
	}
}
