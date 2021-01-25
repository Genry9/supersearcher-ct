using System;
using System.Collections.Generic;
using System.Text;

using Microsoft.Extensions.DependencyInjection;

using SuperSearcher.BLL.Interfaces;
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
			services.AddScoped<IWebSearcher, GoogleSearcher>();
			services.AddScoped<IHistoryService, HistoryService>();
			services.AddScoped<IStatisticsService, StatisticsService>();
			return services;
		}
	}
}
