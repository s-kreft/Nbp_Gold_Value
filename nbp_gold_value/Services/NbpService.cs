
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
            var goldValues =  JsonConvert.DeserializeObject<Nbp_Response[]>(response);
            var data = goldValues?.FirstOrDefault() ?? new Nbp_Response();
            GoldValue goldValue = new GoldValue(data);
            _dataContext.GoldValues.Add(goldValue);
            _dataContext.SaveChanges();
            return goldValue;
        }

        public List<GoldValue> ReturnDataFromDatabase()
        {
            var goldValueList = new List<GoldValue>();
               goldValueList = _dataContext.GoldValues.ToList();

            //foreach (var goldValue in goldValueList)
            //{
            //    Console.WriteLine(goldValue);
            //}
            return goldValueList;
        }

    }
}
