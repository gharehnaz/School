using ESchool.Domain.AccountAgg;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ESchool.Infrastructure.Mapping
{
    public class StudentsMapping : IEntityTypeConfiguration<Student>
    {
        public void Configure(EntityTypeBuilder<Student> builder)
        {
            builder.ToTable("Students");
            builder.HasKey(x => x.Id);

            builder.Property(x => x.Name).HasMaxLength(100).IsRequired();
            builder.Property(x => x.Family).HasMaxLength(100).IsRequired();
            builder.Property(x => x.NationalCode).HasMaxLength(10).IsRequired();
            builder.Property(x => x.Username).HasMaxLength(100);
            builder.Property(x => x.Password).HasMaxLength(1000);
            builder.Property(x => x.Mobile).HasMaxLength(20);
            builder.Property(x => x.ProfilePhoto).HasMaxLength(500);
            builder.HasOne(x => x.ClassRoom)
             .WithMany(x => x.Students)
             .HasForeignKey(x => x.ClassRoomId);
        }
    }
}
