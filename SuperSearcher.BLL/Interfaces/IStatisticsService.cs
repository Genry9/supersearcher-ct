using SuperSearcher.BLL.Models.Statistics;

using System;
using System.Collections.Generic;
using System.Text;

namespace SuperSearcher.BLL.Interfaces
{
	public interface IStatisticsService
	{
		SearchConditionStatisticResult GetStatistics();
		SearchConditionStatisticResult GetStatistics(DateTime from);
		SearchConditionStatisticResult GetStatistics(DateTime from, DateTime to);

	}
}
