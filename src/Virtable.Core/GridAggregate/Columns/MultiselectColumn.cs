using System.ComponentModel.DataAnnotations.Schema;

namespace Virtable.Core.GridAggregate.Columns;

public class MultiselectColumn : SelectColumn
{
    [NotMapped]
    public IEnumerable<string> Vars => Variants.AsReadOnly();

    public override ColumnType Discriminator { get; protected set; } = ColumnType.Multiselect;
}
