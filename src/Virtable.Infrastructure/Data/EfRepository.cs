using Ardalis.Specification.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Virtable.Core.SharedKernel;

namespace Virtable.Infrastructure.Data;

internal class EfRepository<T> : RepositoryBase<T>, IReadRepository<T>, IRepository<T> where T : class, IAggregateRoot
{
    private readonly DbSet<T> _entities;

    public EfRepository(AppDbContext dbContext) : base(dbContext)
    {
        _entities = dbContext.Set<T>();
    }

    public Task ExecuteDeleteAsync(CancellationToken cancellationToken = default)
    {
        return _entities.ExecuteDeleteAsync(cancellationToken);
    }
}
