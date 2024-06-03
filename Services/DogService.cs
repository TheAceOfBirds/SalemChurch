using RestSharp.Authenticators;
using RestSharp;
using System.Reflection;
using System.Text;
using System.Text.Json;
using System.Net.Http;
using static System.Net.Mime.MediaTypeNames;
using BlankMVC.Models.Pets.API;
namespace BlankMVC.Services
{
    public class DogService
    {
        private List<Dog> dogs;
        IConfiguration _configuration;
        private HttpClient client;
        public DogService(IConfiguration configuration)
        {
            dogs = new List<Dog>();
            _configuration = configuration;
            client = new HttpClient();
            client.BaseAddress = new Uri(configuration["DogAPIURL"]);
        }
        public async Task<List<Dog>> getDogBreeds()
        {
            var response = await client.GetAsync("breeds").ConfigureAwait(false);
            DogModel dogs = new DogModel();
            if (response.IsSuccessStatusCode)
            {
                var stream = await response.Content.ReadAsStreamAsync();

                var serializerOptions = new JsonSerializerOptions
                {
                    PropertyNameCaseInsensitive = true
                };
                
                dogs = await JsonSerializer.DeserializeAsync<DogModel>(stream, serializerOptions);
            }
            return dogs.data;
        }
        public async Task<List<Dog>> getDogBreedById(int id)
        {
            var result = await client.GetFromJsonAsync<List<Dog>>(String.Format("breeds/{0}",id));
            return result;
        }
    }
}
