using System.Text.Json.Serialization;

namespace Virtable.Core.GridAggregate.Records;

[JsonConverter(typeof(JsonStringEnumConverter<FieldType>))]
public enum FieldType
{
    None,
    String = 1,
    Numeric = 2
}
