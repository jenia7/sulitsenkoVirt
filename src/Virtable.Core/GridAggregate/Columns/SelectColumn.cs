using System.Text.Json.Serialization;

namespace Virtable.Core.GridAggregate.Columns;

[JsonDerivedType(typeof(MultiselectColumn))]
public class SelectColumn : Column
{
    public List<string> Variants { get; set; } = [];

    public override ColumnType Discriminator { get; protected set; } = ColumnType.Select;

    public bool CanStoreInField(string variant)
    {
        return Variants.Contains(variant);
    }
}
