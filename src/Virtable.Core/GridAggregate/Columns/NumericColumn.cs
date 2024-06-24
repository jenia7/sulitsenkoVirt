namespace Virtable.Core.GridAggregate.Columns;

public class NumericColumn : Column
{
    public override ColumnType Discriminator { get; protected set; } = ColumnType.Numeric;
}
