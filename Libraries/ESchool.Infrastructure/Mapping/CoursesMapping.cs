using ESchool.Domain.AccountAgg;
using ESchool.Domain.CourseAgg;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ESchool.Infrastructure.Mapping
{
    public class CoursesMapping : IEntityTypeConfiguration<Course>
    {
        public void Configure(EntityTypeBuilder<Course> builder)
        {
            builder.ToTable("Courses");
            builder.HasKey(x => x.Id);

            builder.Property(x => x.Name).HasMaxLength(100).IsRequired();
            builder.Property(x => x.Code).HasMaxLength(100).IsRequired();
           
            builder.HasOne(x => x.ClassRoom)
             .WithMany(x => x.Courses)
             .HasForeignKey(x => x.ClassRoomId);
            builder.HasOne(x => x.Account)
                .WithMany(x => x.Courses).HasForeignKey(x => x.AccountId);
        }
    }
}
