using Ardalis.Specification;

namespace University.ApplicationCore.Interfaces.Repositories;

public interface IRepository<T> : IRepositoryBase<T> where T : class, IAggregateRoot
{
}
