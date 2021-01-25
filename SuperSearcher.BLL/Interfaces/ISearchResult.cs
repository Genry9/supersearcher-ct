using System;
using System.Collections.Generic;
using System.Text;

namespace SuperSearcher.BLL.Interfaces
{
    public interface ISearchResult
    {
        string description { get; set; }
        string link { get; set; }
        string title { get; set; }
    }
}
