using Virtable.Core.Exceptions;
using Virtable.Core.GridAggregate;
using Virtable.Core.GridAggregate.Columns;
using GridRecord = Virtable.Core.GridAggregate.Records.Record;

namespace Virtable.UnitTests.Core.GridAggregate;

public class GridTests
{
    private static readonly ColumnType _columnType = ColumnType.String;
    [Fact]
    public void AddRecord_GridWithoutRecords_DomainException()
    {
        Grid grid = new();

        Action action = grid.AddRecord;

        Assert.Throws<DomainException>(action);
        Assert.Empty(grid.Records);
    }

    [Fact]
    public void AddRecord_WithoutFields_DomainException()
    {
        Grid grid = new();
        grid.Records.Add(new GridRecord());

        Action action = grid.AddRecord;

        Assert.Throws<DomainException>(action);
        Assert.NotEmpty(grid.Records);
        Assert.Empty(grid.Records[0].Fields);
    }

    [Fact]
    public void AddColumn_GridWithoutRecords_DomainException()
    {
        Grid grid = new();

        Action action = () => grid.AddColumn(_columnType);

        Assert.Throws<DomainException>(action);
    }

    [Fact]
    public void AddColumn_GridWithoutFields_DomainException()
    {
        Grid grid = new();
        grid.Records.Add(new GridRecord());

        Action action = () => grid.AddColumn(_columnType);

        Assert.Throws<DomainException>(action);
    }
}
