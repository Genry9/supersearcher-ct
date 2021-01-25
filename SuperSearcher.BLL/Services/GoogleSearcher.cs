using SuperSearcher.BLL.Interfaces;
using SuperSearcher.BLL.Models.Search;
using SuperSearcher.BLL.Models.Search.Web;

using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace SuperSearcher.BLL.Services
{
	class GoogleSearcher : IWebSearcher
	{
		public IEnumerable<ISearchResult> GetResults(string term) => 
			Task.Run(async () => await GetResultsAsync(term)).Result;

		public async Task<IEnumerable<ISearchResult>> GetResultsAsync(string term)
		{
			var client = new HttpClient();
			var request = new HttpRequestMessage
			{
				Method = HttpMethod.Get,
				RequestUri = new Uri($"https://google-search3.p.rapidapi.com/api/v1/search/q={term}&num=10"),
				Headers = {
					{ "x-rapidapi-key", "a3259bbecemsh83a33b8ac76d8aap163cc6jsn3126ecc78c62" },
					{ "x-rapidapi-host", "google-search3.p.rapidapi.com" },
				},
			};
			using (var response = await client.SendAsync(request))
			{
				response.EnsureSuccessStatusCode();
				var body = await response.Content.ReadAsStringAsync();
				

				return Newtonsoft.Json.JsonConvert.DeserializeObject<GoogleResponseModel>(body).results;
			}
		}
	}
}
