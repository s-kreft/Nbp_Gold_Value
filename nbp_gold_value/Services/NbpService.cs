using nbp_gold_value.Models;
using Newtonsoft.Json;
using Microsoft.EntityFrameworkCore;


namespace nbp_gold_value.Services
{
    public class NbpService : INbpService
    {
        static readonly HttpClient client = new HttpClient();
        private readonly nbpContext _dataContext;
        public NbpService(nbpContext dataContext)
        {
            _dataContext = dataContext;
        }
        public String writeText()
        {
            return "Test serwisu NBP";
        }

        public async Task<GoldValue> ReturnGoldValueAsync()
        {
            var response = await client.GetStringAsync("http://api.nbp.pl/api/cenyzlota/?format=json");
            var goldValue =  JsonConvert.DeserializeObject<GoldValue[]>(response);
            var data = goldValue.FirstOrDefault() ?? new GoldValue();
            _dataContext.GoldValues.Add(data);
            _dataContext.SaveChanges();
            return data;
        }
    }
}
