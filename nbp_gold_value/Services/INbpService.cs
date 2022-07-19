using nbp_gold_value.Models;

namespace nbp_gold_value.Services
{
    public interface INbpService
    {
        Task<GoldValue> ReturnGoldValueAsync();
        string writeText();
    }
}