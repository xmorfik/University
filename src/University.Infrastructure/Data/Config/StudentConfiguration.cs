using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using University.ApplicationCore.Entities;

namespace University.Infrastructure.Data.Config;

public class StudentConfiguration : IEntityTypeConfiguration<Student>
{
    public void Configure(EntityTypeBuilder<Student> builder)
    {
        builder.HasKey(s => s.Id);
        builder.Property(s => s.FirstName).IsRequired().HasMaxLength(25);
        builder.Property(s => s.LastName).IsRequired().HasMaxLength(25);
    }
}
