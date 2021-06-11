using Music_InstrumentDB_Console.POCO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Music_InstrumentDB_Console.Services
{
    public class FamilyService
    {
        private readonly HttpClient _httpClient = new HttpClient();
        public async Task<InstrumentFamily> GetFamilyAsync(int id)
        {
            HttpResponseMessage response = await _httpClient.GetAsync($"api/InstrumentFamily/{id}");

            if (response.IsSuccessStatusCode)
            {
                InstrumentFamily family = await response.Content.ReadAsAsync<InstrumentFamily>();
                return family;
            }

            return null;
        }

        public async Task<T> GetAsync<T>(string url)
        {
            HttpResponseMessage response = await _httpClient.GetAsync(url);

            if (response.IsSuccessStatusCode)
            {
                return await response.Content.ReadAsAsync<T>();
            }
            return default;
        }

        public async Task<SearchResult<InstrumentFamily>> GetFamilySearchAsync(string query)
        {
            HttpResponseMessage response = await _httpClient.GetAsync("https://localhost:44363/api/InstrumentFamily?search=" + query);

            if (response.IsSuccessStatusCode)
            {
                return await response.Content.ReadAsAsync<SearchResult<InstrumentFamily>>();
            }

            return null;

        }

        public async Task<SearchResult<T>> GetSearchAsync<T>(string category, string query)
        {
            HttpResponseMessage response = await _httpClient.GetAsync($"https://localhost:44363/api/{category}/?search={query}");

            if (response.IsSuccessStatusCode)
            {
                return await response.Content.ReadAsAsync<SearchResult<T>>();
            }
            return null;
        }
    }
}
