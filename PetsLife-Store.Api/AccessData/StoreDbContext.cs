using Microsoft.EntityFrameworkCore;
using Domain.Entities;

namespace AccessData
{
    public class StoreDbContext : DbContext
    {
        public StoreDbContext(DbContextOptions<StoreDbContext> options) : base(options) { }

        public DbSet<TestAPI> API { get; set; }
    }
}
