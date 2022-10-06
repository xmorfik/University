using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using University.ApplicationCore.Entities;

namespace University.Infrastructure.Data.Config;

public class GroupConfiguration : IEntityTypeConfiguration<Group>
{
    public void Configure(EntityTypeBuilder<Group> builder)
    {
        builder.HasKey(g => g.Id);
        builder.Property(g => g.Name).IsRequired().HasMaxLength(25);
        builder.HasMany(g => g.Students).WithOne(s => s.Group).OnDelete(DeleteBehavior.Restrict);
    }
}