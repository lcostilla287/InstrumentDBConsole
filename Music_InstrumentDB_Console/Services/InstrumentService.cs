using Music_InstrumentDB_Console.POCO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace Music_InstrumentDB_Console.Services
{
    public class InstrumentService
    {
        private HttpClient _httpClient = new HttpClient();

        public void Authorization(string accesstoken)
        {
            _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", accesstoken);
        }
        //Post
        public async Task<bool> PostInstrumentAsync(Instrument newInstrument)
        {
            HttpResponseMessage response = await _httpClient.PostAsJsonAsync("https://localhost:44363/api/Instrument/", newInstrument);

            if (response.IsSuccessStatusCode)
            {
                return true;
            }
            else
            {
                return false;
            }
        }


        //Get By Id
        public async Task<Instrument> GetInstrumentAsync(int id)
        {
            HttpResponseMessage response = await _httpClient.GetAsync($"https://localhost:44363/api/Instrument/{id}");

            if (response.IsSuccessStatusCode)
            {
                Instrument instrument = await response.Content.ReadAsAsync<Instrument>();
                return instrument;
            }
            return null;
        }
        //Get All
        public async Task<List<Instrument>> GetAllInstrumentsAsync()
        {
            HttpResponseMessage response = await _httpClient.GetAsync($"https://localhost:44363/api/Instrument");

            if (response.IsSuccessStatusCode)
            {

                List<Instrument> instruments = response.Content.ReadAsAsync<List<Instrument>>().Result;
                //List<Instrument> instruments = 
                return instruments;
            }
            return null;
        }

        public async Task<List<Instrument>> GetSearchAsync(string query)
        {
            HttpResponseMessage response = await _httpClient.GetAsync($"https://localhost:44363/api/Instrument?search={query}");
            if (response.IsSuccessStatusCode)
            {
                List<Instrument> instruments = response.Content.ReadAsAsync<List<Instrument>>().Result;
                return instruments;
            }
            return null;
        }

        //Put
        public async Task<bool> PutInstrumentAsync(int id, Instrument updatedInstrument)
        {
            HttpResponseMessage response = await _httpClient.PutAsJsonAsync($"https://localhost:44363/api/Instrument/{id}", updatedInstrument);

            if (response.IsSuccessStatusCode)
            {
                return response.IsSuccessStatusCode;
            }
            return false;
        }

        //Delete
        public async Task<bool> DeleteInstrumentAsync(int id)
        {
            HttpResponseMessage response = await _httpClient.DeleteAsync($"https://localhost:44363/api/Instrument/{id}");

            if (response.IsSuccessStatusCode)
            {
                return response.IsSuccessStatusCode;
            }
            return false;
        }
    }
}
