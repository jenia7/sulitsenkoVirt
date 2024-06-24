using Ardalis.Specification;

namespace Virtable.Core.SharedKernel;

public interface IRepository<T> : IRepositoryBase<T>, IReadRepositoryBase<T> where T : class, IAggregateRoot
{
    Task ExecuteDeleteAsync(CancellationToken cancellationToken = default);
}
