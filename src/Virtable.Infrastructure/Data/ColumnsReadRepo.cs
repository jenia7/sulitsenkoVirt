using Ardalis.Specification.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Virtable.Core.GridAggregate;
using Virtable.Core.GridAggregate.Columns;

namespace Virtable.Infrastructure.Data;

internal class ColumnsReadRepo : IColumnsReadRepo
{
    private readonly AppDbContext _db;

    public ColumnsReadRepo(AppDbContext db)
    {
        _db = db;
    }

    public Task<List<Column>> GetColumnsByGridIdAsync(int gridId)
    {
        return _db.Columns.ToListAsync();
    }
}
