using Newtonsoft.Json;

namespace OrlandoCodeCampApi.Models.Responses
{
    public class SponsorLevel
    {
        public int SponsorLevelId { get; set; }

        [JsonProperty("description")]
        public string SponsorLevelName { get; set; }
    }
}
