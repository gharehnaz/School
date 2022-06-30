using ESchool.Domain.ClassRoomAgg;
using ESchool.Domain.SchoolAgg;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ESchool.Infrastructure.Mapping
{
    public class ClassRoomsMapping : IEntityTypeConfiguration<ClassRoom>
    {
        public void Configure(EntityTypeBuilder<ClassRoom> builder)
        {
            builder.ToTable("ClassRoom");
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Name).HasMaxLength(255).IsRequired();
            builder.Property(x => x.Number).HasMaxLength(10);
            builder.Property(x => x.SchoolCode).HasMaxLength(10).IsRequired();
            builder.Property(x => x.Level).HasMaxLength(255).IsRequired();
            builder.Property(x => x.Description).HasMaxLength(500);
            builder.HasOne(x => x.School)
              .WithMany(x => x.ClassRooms)
              .HasForeignKey(x => x.SchoolId);
            builder.HasMany(x => x.Students)
              .WithOne(x => x.ClassRoom)
              .HasForeignKey(x => x.ClassRoomId);
            builder.HasMany(x => x.Courses)
             .WithOne(x => x.ClassRoom)
             .HasForeignKey(x => x.ClassRoomId);
        }
    }
}
