using System;
using System.Collections.Generic;
using System.Text;

using Microsoft.Extensions.DependencyInjection;


namespace SuperSearcher.BLL
{
	public class DependencyExtensions
	{
		public static IServiceCollection ConfigureBLL(this IServiceCollection services)
		{

			return services;
		}
	}
}
