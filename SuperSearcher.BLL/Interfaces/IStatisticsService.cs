using SuperSearcher.BLL.Models.Statistics;

using System;
using System.Collections.Generic;
using System.Text;

namespace SuperSearcher.BLL.Interfaces
{
	public interface IStatisticsService
	{
		SearchConditionStatisticResult GetStatistics(string userName);
		SearchConditionStatisticResult GetStatistics(string userName, DateTime from);
		SearchConditionStatisticResult GetStatistics(string userName, DateTime from, DateTime to);

	}
}
