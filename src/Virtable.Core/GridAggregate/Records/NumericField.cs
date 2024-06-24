namespace Virtable.Core.GridAggregate.Records;

public class NumericField : Field
{
    public decimal? Number { get; set; }
    public override FieldType Discriminator { get; protected set; } = FieldType.Numeric;

    public override Field makeCopyWithDefaultValue()
    {
        return new NumericField();
    }
}
