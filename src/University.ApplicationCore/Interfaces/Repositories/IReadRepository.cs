using Ardalis.Specification;

namespace University.ApplicationCore.Interfaces.Repositories;

public interface IReadRepository<T> : IReadRepositoryBase<T> where T : class, IAggregateRoot
{
}
