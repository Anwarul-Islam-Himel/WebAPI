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
            builder.ApplyConfiguration(new IncomeConfiguration());
            builder.ApplyConfiguration(new ExpenditureConfiguration());
            builder.ApplyConfiguration(new TypeConfiguration());
            base.OnModelCreating(builder);
        }

        public DbSet<Income> Incomes { get; set; }
        public DbSet<Expenditure> Expenditures { get; set; }
        public DbSet<IncomeOrExpenditureType> IncomeOrExpenditureTypes { get; set; }
    }
}
