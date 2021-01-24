using System;
using System.Collections.Generic;
using System.Text;

using Microsoft.Extensions.DependencyInjection;

using SuperSearcher.BLL.Services;
using SuperSearcher.DAL.Interfaces;
using SuperSearcher.DAL.Repositories;

namespace SuperSearcher.BLL
{
	public static class DependencyExtensions
	{
		public static IServiceCollection ConfigureBLL(this IServiceCollection services)
		{
			services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));
			services.AddScoped<SearchService>();
			return services;
		}
	}
}
