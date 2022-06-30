using ESchool.Domain.AccountAgg;
using ESchool.Domain.SchoolAgg;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ESchool.Infrastructure.Mapping
{
    public class SchoolsMapping : IEntityTypeConfiguration<School>
    {
        public void Configure(EntityTypeBuilder<School> builder)
        {
            builder.ToTable("School");
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Name).HasMaxLength(255).IsRequired();
            builder.Property(x => x.Code).HasMaxLength(10).IsRequired();
            builder.Property(x => x.Description).HasMaxLength(500);
            builder.HasMany(x => x.ClassRooms)
               .WithOne(x => x.School)
               .HasForeignKey(x => x.SchoolId);
            
        }
    }
}
