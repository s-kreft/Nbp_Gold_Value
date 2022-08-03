namespace nbp_gold_value.Services
{
    public interface INbpService
    {
        List<GoldValue> ReturnDataFromDatabase();
        Task<GoldValue> ReturnGoldValueAsync();
        string writeText();
    }
}