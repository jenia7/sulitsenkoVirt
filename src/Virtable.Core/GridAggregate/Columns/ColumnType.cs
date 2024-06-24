using Ardalis.SmartEnum;
using Virtable.Core.GridAggregate.Records;

namespace Virtable.Core.GridAggregate.Columns;

public class ColumnType : SmartEnum<ColumnType>
{
    public static readonly ColumnType None = new(nameof(None), 0);
    public static readonly ColumnType String = new(nameof(String), 1);
    public static readonly ColumnType Numeric = new(nameof(Numeric), 2);


    public static readonly ColumnType Email = new(nameof(Email), 3);
    public static readonly ColumnType ValidatedString = new(nameof(ValidatedString), 4);
    public static readonly ColumnType Select = new(nameof(Select), 5);
    public static readonly ColumnType Multiselect = new(nameof(Multiselect), 6);

    public ColumnType(string name, int value) : base(name, value)
    {
    }

    public Column makeColumn()
    {
        return Value switch
        {
            1 => new StringColumn(),
            2 => new NumericColumn(),
            _ => throw new ArgumentException("unsupported enum type", nameof(Name))
        };
    }

    public Field makeField()
    {
        return Value switch
        {
            1 => new StringField(),
            2 => new NumericField(),
            _ => throw new ArgumentException("unsupported enum type", nameof(Name))
        };
    }
}
