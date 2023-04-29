using Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DataAccess.Configurations
{
    public class ProductConfiguration : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
           builder.HasKey(x => x.Id); //primary key
           builder.Property(x=> x.Name).HasMaxLength(100).IsRequired();
           builder.Property(x=> x.Stock).IsRequired();
           builder.Property(x=> x.UserId).IsRequired();
           builder.Property(x=> x.Price).IsRequired().HasColumnType("decimal(18,2)");
        }
    }
}
