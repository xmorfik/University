using Microsoft.EntityFrameworkCore;
using System.Reflection;
using University.ApplicationCore.Entities;

namespace University.Infrastructure.Data;

public class UniversityDbContext : DbContext
{
    public DbSet<Student> Students { get; set; }
    public DbSet<Course> Courses { get; set; }
    public DbSet<Group> Groups { get; set; }

    public UniversityDbContext(DbContextOptions<UniversityDbContext> options) : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);
        builder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
    }
}
