using Newtonsoft.Json;
namespace BlankMVC.Models.Pets.API
{
    public class DogModel
    {
        [JsonProperty("data")]
        public List<Dog> data { get; set; }
    }
}
