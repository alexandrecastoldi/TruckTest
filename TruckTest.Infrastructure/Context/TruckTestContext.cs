using Microsoft.EntityFrameworkCore;
using TruckTest.Domain.Mapping;

namespace TruckTest.Domain.Context
{
    public class TruckTestContext: DbContext
    {
        public TruckTestContext(DbContextOptions<TruckTestContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new TruckMap());
        }
    }
}
