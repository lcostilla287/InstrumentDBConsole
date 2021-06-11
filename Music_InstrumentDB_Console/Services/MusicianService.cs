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
        //private readonly HttpClient _httpClient = new HttpClient();

        public async Task<Musician> GetMusicianAsync(HttpClient client, int id)
        {
            HttpResponseMessage response = await client.GetAsync($"https://localhost:44363/api/Musician/{id}");

            if (response.IsSuccessStatusCode)
            {
                Musician musician = await response.Content.ReadAsAsync<Musician>();
                return musician;
            }
            return null;
        }

        public async Task<Musician> GetAllMusicianAsnc(HttpClient client)
        {
            HttpResponseMessage response = await client.GetAsync($"https://localhost:44363/api/Musician");

            if (response.IsSuccessStatusCode)
            {
                Musician musician = await response.Content.ReadAsAsync<Musician>();
                return musician;
            }
            return null;
        }

        public async Task<bool> PostMusicianAsync (HttpClient client, Musician newMusician)
        {
            HttpResponseMessage response = await client.PostAsJsonAsync($"https://localhost:44363/api/Musician", newMusician);

            if (response.IsSuccessStatusCode)
            {
                return true;
            }
            return false;
        }

        public async Task<bool> PutMusicianAsync(HttpClient client, int id, Musician updatedMusician)
        {
            HttpResponseMessage response = await client.PostAsJsonAsync($"https://localhost:44363/api/Musician", updatedMusician);

            if (response.IsSuccessStatusCode)
            {
                return true;
            }
            return false;
        }

        public async Task<bool> DeleteMusicianAsync(HttpClient client, int id)
        {
            HttpResponseMessage response = await client.DeleteAsync($"https://localhost:44363/api/Musician/{id}");

            if (response.IsSuccessStatusCode)
            {
                return response.IsSuccessStatusCode;
            }
            return false;
        }
    }
}
