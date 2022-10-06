using Ardalis.Specification.EntityFrameworkCore;
using University.ApplicationCore.Interfaces;
using University.ApplicationCore.Interfaces.Repositories;
using University.Infrastructure.Data;

namespace University.Repositories;

public class EfRepository<T> : RepositoryBase<T>, IReadRepository<T>, IRepository<T> where T : class, IAggregateRoot 
{
    public EfRepository(UniversityDbContext dbContext) : base(dbContext)
    {
    }
}