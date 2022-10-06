using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using University.ApplicationCore.Entities;

namespace University.Infrastructure.Data.Config;

public class CourseConfiguration : IEntityTypeConfiguration<Course>
{
    public void Configure(EntityTypeBuilder<Course> builder)
    {
        builder.HasKey(c => c.Id);
        builder.Property(c => c.Name).IsRequired().HasMaxLength(25);
        builder.Property(c => c.Description).IsRequired().HasMaxLength(50);
        builder.HasMany(c => c.Groups).WithOne(g => g.Course).OnDelete(DeleteBehavior.Restrict);
    }
}
