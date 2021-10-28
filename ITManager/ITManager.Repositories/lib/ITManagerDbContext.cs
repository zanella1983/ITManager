using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ITManager.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace ITManager.Repositories.lib
{
    public class ITManagerDbContext : DbContext
    {
        public ITManagerDbContext(DbContextOptions<ITManagerDbContext> options) : base(options)
        {
            if (Database.ProviderName != "Microsoft.EntityFrameworkCore.InMemory")
                Database.Migrate();
        }

        public DbSet<User> Users { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder) 
        {
            modelBuilder.Entity<User>(entity =>
            {
                entity.HasKey(e => e.Id);
            });
        }
    }
}
