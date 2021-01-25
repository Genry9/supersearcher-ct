using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Identity;

using SuperSearcher.BAWeb.Models;
using SuperSearcher.BLL.Models.Statistics;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SuperSearcher.BAWeb.VM
{
	public class SearchVM : BaseDriveVM
	{

		const int _limit = 5;

		[Inject]
		SignInManager<SuperSearcher.DAL.Entities.User> SignInManager { get; set; }

		[Inject]
		UserManager<SuperSearcher.DAL.Entities.User> UserManager { get; set; }

		[Inject]
		protected SuperSearcher.BLL.Interfaces.IWebSearcher webSearcher { get; set; }
		[Inject]
		protected SuperSearcher.BLL.Interfaces.IHistoryService historyService { get; set; }

		[Inject]
		protected SuperSearcher.BLL.Interfaces.IStatisticsService statisticsService { get; set; }

		[Parameter]
		public string q { get; set; }

		public List<SearchResult> searchResults { get; set; }

		public SearchConditionStatisticResult StatisticsPreloaded { get; set; }


		protected override void OnInitialized()
		{

			StatisticsPreloaded = statisticsService.GetStatistics(SignInManager.Context.User.Identity.Name);

			base.OnInitialized();
		}

		public async Task Search()
		{
			if (string.IsNullOrWhiteSpace(q) || busy)
			{
				return;
			}

			SetBusy(true);

			searchResults = new List<SearchResult>();
			historyService.AddRecord(new DAL.Entities.SearchRequest("All drives", q)
			{
				UserId = SignInManager.Context.User.Identity.Name
			});
			LoadFilesResults(q);
			LoadWebResults(q);

			SetBusy(false);
		}


		public void LoadFilesResults(string query)
		{
			try
			{
				searchResults.AddRange(
					driveSearcher.GetResults(query)
					.Select(
						x => new SearchResult()
						{
							Title = x.title,
							Description = x.description,
							Link = x.link,
							isLocal = true
						}).Take(_limit));
			}
			catch (Exception ex)
			{
				Error = ex.Message;
			}

		}

		public void LoadWebResults(string query)
		{
			try
			{
				searchResults.AddRange(webSearcher.GetResults(query)
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

		public void SetBusy(bool val)
		{
			busy = val;
			ShouldRender();
		}
	}
}
