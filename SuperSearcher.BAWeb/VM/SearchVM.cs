using Microsoft.AspNetCore.Components;

using SuperSearcher.BAWeb.Models;
using SuperSearcher.BLL.Models.Statistics;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SuperSearcher.BAWeb.VM
{
	public class SearchVM : ComponentBase
	{

		const int _limit = 5;

		[Inject]
		protected SuperSearcher.BLL.Services.SearchService driveSearcher { get; set; }

		[Inject]
		protected SuperSearcher.BLL.Interfaces.IWebSearcher webSearcher { get; set; }
		[Inject]
		protected SuperSearcher.BLL.Interfaces.IHistoryService historyService { get; set; }

		[Inject]
		protected SuperSearcher.BLL.Interfaces.IStatisticsService statisticsService { get; set; }

		[Parameter]
		public string q { get; set; }
		[Parameter]
		public string d { get; set; }
		public List<SearchResult> searchResults { get; set; }

		public SearchConditionStatisticResult StatisticsPreloaded { get; set; }

		public string[] drives { get; set; }

		public string Error { get; set; }

		public bool busy { get; set; } = false;
		protected override void OnInitialized()
		{
			drives = driveSearcher.GetDrives().ToArray();
			StatisticsPreloaded = statisticsService.GetStatistics();

			base.OnInitialized();
		}

		public async Task Search()
		{
			SetBusy(true);
			searchResults = new List<SearchResult>();
			if (!string.IsNullOrWhiteSpace(q))
			{
				historyService.AddRecord(new DAL.Entities.SearchRequest("All drives", q));
				try
				{
					searchResults.AddRange(
						driveSearcher.GetResults(q)
						.Select(
							x => new SearchResult()
							{
								Title = x.title,
								Description = x.description,
								Link = x.link,
								isLocal = true
							}).Take(_limit));

					searchResults.AddRange(webSearcher.GetResults(q)
						.Select(x => new SearchResult()
						{
							Title = x.title,
							Description = x.description,
							Link = x.link
						}).Take(_limit));
				}
				catch (Exception ex)
				{
					Error = ex.Message;
				}
			}
			SetBusy(false);
		}

		public void SetBusy(bool val)
		{
			busy = val;
			ShouldRender();
		}
	}
}
