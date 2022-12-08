using Newtonsoft.Json;

namespace TestFramework.Config
{

    [JsonObject("testSettings")]
    public class TestSettings
    {
        [JsonProperty("aut")]
        public string URL { get; set; }


        [JsonProperty("browser")]
        public string Browser { get; set; }
    }

}
