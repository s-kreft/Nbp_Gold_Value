using nbp_gold_value.Models;
using Newtonsoft.Json;

namespace nbp_gold_value.Services
{
    public class NbpService : INbpService
    {
        static readonly HttpClient client = new HttpClient();
        public NbpService()
        {

        }
        public String writeText()
        {
            return "Test serwisu NBP";
        }

        public async Task<GoldValue> ReturnGoldValueAsync()
        {
            var response = await client.GetStringAsync("http://api.nbp.pl/api/cenyzlota/?format=json");
            var goldValue =  JsonConvert.DeserializeObject<GoldValue[]>(response);
            return goldValue.FirstOrDefault() ?? new GoldValue();
        }
    }
}
