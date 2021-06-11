using Music_InstrumentDB_Console.POCO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Music_InstrumentDB_Console.Services
{
    public class MusicianService
    {
        private readonly HttpClient _httpClient = new HttpClient();

        public async Task<Musician> GetMusicianAsync(int id)
        {
            HttpResponseMessage response = await _httpClient.GetAsync("$https://localhost:44363/api/Musician/{id}");

            if (response.IsSuccessStatusCode)
            {
                Musician musician = await response.Content.ReadAsAsync<Musician>();
                return musician;
            }
            return null;
        }

        public async Task<List<Musician>> GetAllMusicianAsnc()
        {
            HttpResponseMessage response = await _httpClient.GetAsync("$https://localhost:44363/api/Musician");

                return Task.FromResult(response);

            if (response.IsSuccessStatusCode)
            {
                Musician musician = await response.Content.ReadAsAsync<Musician>();
                return List<Musician> = JsonConvert.DeserializeObject<List<Musician>>(musician);
            }
            return null;
        }

        public async Task<bool> PostMusicianAsync (Musician newMusician)
        {
            HttpResponseMessage response = await _httpClient.PostAsync("$https://localhost:44363/api/Musician", newMusician);

            if (response.IsSuccessStatusCode)
            {
                return true;
            }
            return false;
        }

        public async Task<bool> PutMusicianAsync(int id, Musician updatedMusician)
        {
            HttpResponseMessage response = await _httpClient.PostAsync("$https://localhost:44363/api/Musician", updatedMusician);

            if (response.IsSuccessStatusCode)
            {
                return true;
            }
            return false;
        }

        public async Task<bool> DeleteMusicianAsync(int id)
        {
            HttpResponseMessage response = await _httpClient.DeleteAsync($"https://localhost:44363/api/Musician/{id}");

            if (response.IsSuccessStatusCode)
            {
                return response.IsSuccessStatusCode;
            }
            return false;
        }
    }
}
