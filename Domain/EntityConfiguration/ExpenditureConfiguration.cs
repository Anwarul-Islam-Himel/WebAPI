using Domain.EntityModel;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Domain.EntityConfiguration
{
    public class ExpenditureConfiguration : IEntityTypeConfiguration<Expenditure>
    {
        public void Configure(EntityTypeBuilder<Expenditure> builder)
        {
            builder.ToTable(nameof(Expenditure));
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).HasColumnType("int");
            builder.Property(x => x.IncomeOrExpenditureTypeId).HasColumnType("int");
            builder.Property(x => x.Name).HasColumnType("nvarchar(50)");
            builder.Property(x => x.Description).HasColumnType("nvarchar(256)");
            builder.Property(x => x.VoucerNumber).HasColumnType("nvarchar(256)");
            builder.Property(x => x.Amount).HasColumnType("float");
            builder.Property(x => x.CreatedAt).HasColumnType("date");
        }
    }
}
