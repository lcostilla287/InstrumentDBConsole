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

        public async Task<bool> PostFamilyAsync(int id, InstrumentFamily newFamily)
        {
            HttpResponseMessage response = await _httpClient.PostAsJsonAsync($"https://localhost:44363/api/InstrumentFamily/", newFamily);

            if (response.IsSuccessStatusCode)
            {
                Console.WriteLine(response.IsSuccessStatusCode);
            }

            return false;
        }

        public async Task<InstrumentFamily> GetFamilyAsync(int id)
        {
            HttpResponseMessage response = await _httpClient.GetAsync($"https://localhost:44363/api/InstrumentFamily/{id}");

            if (response.IsSuccessStatusCode)
            {
                InstrumentFamily family = await response.Content.ReadAsAsync<InstrumentFamily>();
                return family;
            }

            return null;
        }

        public async Task<InstrumentFamily> GetAllFamiliesAsync()
        {
            HttpResponseMessage response = await _httpClient.GetAsync($"https://localhost:44363/api/InstrumentFamily");

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

        public async Task<bool> PutFamilyAsync(int id, InstrumentFamily editFamily)
        {
            HttpResponseMessage response = await _httpClient.PutAsJsonAsync($"https://localhost:44363/api/InstrumentFamily/{id}", editFamily);

            if (response.IsSuccessStatusCode)
            {
                Console.WriteLine(response.IsSuccessStatusCode);
            }

            return false;
        }

        public async Task<bool> DeleteFamilyAsync(int id)
        {
            HttpResponseMessage response = await _httpClient.DeleteAsync($"https://localhost:44363/api/InstrumentFamily/{id}");

            if (response.IsSuccessStatusCode)
            {
                Console.WriteLine(response.IsSuccessStatusCode);
            }

            return false;
        }
    }
}
