using System;
using System.Collections.Generic;
using System.Text;

namespace SuperSearcher.BLL.Interfaces
{
	interface IHistoryService
	{

		IEnumerable<string> GetHistory(int lastXRecords);

		void AddRecord(string record);
	}
}
