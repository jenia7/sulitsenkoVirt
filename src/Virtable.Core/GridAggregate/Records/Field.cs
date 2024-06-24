using System.Text.Json.Serialization;
using Virtable.Core.GridAggregate.Columns;

namespace Virtable.Core.GridAggregate.Records;

[JsonDerivedType(typeof(NumericField))]
[JsonDerivedType(typeof(StringField))]
public abstract class Field
{
    public long Id { get; set; }
    public abstract FieldType Discriminator { get; protected set; }

    public long ColumnId { get; set; }
    public Column Column { get; set; } = null!;

    public abstract Field makeCopyWithDefaultValue();
}
