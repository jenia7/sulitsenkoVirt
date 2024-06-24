namespace Virtable.Core.GridAggregate.Records;

public class StringField : Field
{
    public string Value { get; set; } = string.Empty;
    public override FieldType Discriminator { get; protected set; } = FieldType.String;

    public override Field makeCopyWithDefaultValue()
    {
        return new StringField();
    }
}
