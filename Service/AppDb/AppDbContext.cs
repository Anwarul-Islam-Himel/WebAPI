using Domain.EntityConfiguration;
using Domain.EntityModel;
using Microsoft.EntityFrameworkCore;

namespace Service.AppDb
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        { }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.ApplyConfiguration(new ItemConfiguration());
            base.OnModelCreating(builder);
        }

        public DbSet<Item> Items { get; set; }
    }
}
