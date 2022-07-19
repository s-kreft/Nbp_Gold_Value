using Microsoft.EntityFrameworkCore;
using nbp_gold_value.Models;
namespace nbp_gold_value.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options) { }

        public DbSet<GoldValue> GoldValues { get; set; }
    }
}
