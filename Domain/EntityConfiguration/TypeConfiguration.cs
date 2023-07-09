using Domain.EntityModel;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Domain.EntityConfiguration
{
    public class TypeConfiguration : IEntityTypeConfiguration<IncomeOrExpenditureType>
    {
        public void Configure(EntityTypeBuilder<IncomeOrExpenditureType> builder)
        {
            builder.ToTable(nameof(IncomeOrExpenditureType));
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).HasColumnType("int");
            builder.Property(x => x.Name).HasColumnType("nvarchar(50)");
            builder.Property(x => x.Description).HasColumnType("nvarchar(256)");

           
        }
    }
}
