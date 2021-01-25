using SuperSearcher.BLL.Models.Statistics.Extensions;
using SuperSearcher.DAL.Entities;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SuperSearcher.BLL.Models.Statistics
{
	public class StatisticsBuilder
	{
		private SearchConditionStatisticResult _result;
		private IEnumerable<SearchRequest> _logs;
		private string[] _terms;

		/// <summary>
		/// 
		/// </summary>
		/// <param name="logs"></param>
		/// <exception cref="ArgumentException">When no logs provided</exception>
		public StatisticsBuilder(IEnumerable<SearchRequest> logs)
		{
			if (logs.Count() == 0) 
				throw new ArgumentException("No logs availeble");
			_logs = logs;
			_result = new SearchConditionStatisticResult();
			_terms = _logs.Select(x => x.Term)?.ToArray();
		}



		public StatisticsBuilder AddTotalLetters()
		{
			
			string totalSTR = string.Join(string.Empty, _terms);

			var totals = totalSTR.CalculateSplit();

			_result.totalLetters = totalSTR.Length;
			_result.totalAlpha = totals.totalAlp;
			_result.totalNumerical = totals.totalNum;
			_result.totalSpecific = totals.totalSpec;


			_result.charPercent = totals.totalAlp * 100 / totalSTR.Length;

			return this;
		}

		public StatisticsBuilder AddLenthCalculations()
		{
			
			var longest = _terms.Aggregate(string.Empty, (seed, f) => f?.Length > seed.Length ? f : seed);
			var shortest = _terms.Aggregate(_terms.First(), (seed, f) => f?.Length < seed.Length ? f : seed);


			_result.termLenMax = longest.Length;
			_result.termLenMin = shortest.Length;
			_result.termLenAvg = (decimal)_terms.Average(x => x?.Length);

			return this;
		}

		public StatisticsBuilder FindFirstTrendRequest()
		{
			
			_result.TrendRequest = _terms.GroupBy(v => v)
				.OrderByDescending(g => g.Count())
				.First()
				.Key;

			return this;
		}

		public StatisticsBuilder FindMostUsedChar()
		{
			
			_result.MostUsed = string.Join(string.Empty, _terms).ToCharArray().GroupBy(v => v)
				.OrderByDescending(g => g.Count())
				.First()
				.Key;

			return this;
		}


		public StatisticsBuilder AddAvgByDay()
		{
			
			var groupedByDate = _logs.GroupBy(x => x.At.Date);
			_result.ReqPerDayAvg = (decimal)groupedByDate.Average(x => x.Count());

			return this;

		}

		public SearchConditionStatisticResult Build()
		{
			return _result;
		}
	}
}
