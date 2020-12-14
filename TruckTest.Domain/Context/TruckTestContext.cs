using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using TruckTest.Domain.Mapping;

namespace TruckTest.Infrastructure.Context
{
    public class TruckTestContext: DbContext
    {
        public TruckTestContext(DbContextOptions<TruckTestContext> options) : base(options)
        {
            Database.EnsureCreated();
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new TruckMap());
        }
    }
}
