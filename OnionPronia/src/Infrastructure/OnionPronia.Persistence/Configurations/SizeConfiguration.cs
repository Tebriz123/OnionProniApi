using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using OnionPronia.Domain.Entities;
namespace OnionPronia.Persistence.Configurations
{
    internal class SizeConfiguration : IEntityTypeConfiguration<Size>
    {
        public void Configure(EntityTypeBuilder<Size> builder)
        {
            builder
                .Property(s => s.Name)
                .IsRequired()
                .HasColumnType("varchar(50)");
            builder
                .HasIndex(s => s.Name)
                    .IsUnique();
        }
    }
}
