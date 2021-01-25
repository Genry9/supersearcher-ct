using SuperSearcher.BLL.Interfaces;
using SuperSearcher.BLL.Models.Statistics;
using SuperSearcher.DAL.Entities;

using System;
using System.Collections.Generic;
using System.Linq;

namespace SuperSearcher.BLL.Services
{
	public class StatisticsService : IStatisticsService
	{
		private readonly IHistoryService _history;
		public StatisticsService(IHistoryService history)
		{
			_history = history;
		}

		public SearchConditionStatisticResult GetStatistics(string userName = "")
		{
			return Build(_history.GetHistory(userName));
		}

		public SearchConditionStatisticResult GetStatistics(string userName, DateTime from)
		{
			return Build(_history.GetHistory(userName).Where(x => x.At >= from));
		}

		public SearchConditionStatisticResult GetStatistics(string userName, DateTime from, DateTime to)
		{
			return Build(_history.GetHistory(userName).Where(x => x.At >= from && x.At <= to));
		}


		private SearchConditionStatisticResult Build(IEnumerable<SearchRequest> requests)
		{
			try
			{

				StatisticsBuilder b = new StatisticsBuilder(requests);
				b.AddTotalLetters()
					.AddLenthCalculations()
					.AddAvgByDay()
					.FindFirstTrendRequest()
					.FindMostUsedChar();
				return b.Build();
			}
			catch (ArgumentException)
			{
				return new SearchConditionStatisticResult();
			}
		}

	}
}
