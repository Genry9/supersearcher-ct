using System;
using System.Collections.Generic;
using System.Text;

namespace SuperSearcher.BLL.Models.Statistics
{
	public class SearchConditionStatisticResult
	{
		public int termLenMax { get; set; }
		public decimal termLenAvg { get; set; }
		public int termLenMin { get; set; }

		public long totalLetters { get; set; }
		public long totalNumerical { get; set; }
		public long totalAlpha { get; set; }
		public long totalSpecific { get; set; }


		public decimal charPercent { get; set; }

		public char MostUsed { get; set; }
		public string TrendRequest { get; set; }

		public decimal ReqPerDayAvg { get; set; }






	}
}
