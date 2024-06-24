using System.Text.Json.Serialization;
using Virtable.Core.ColumnAggregate;
using Virtable.Core.SharedKernel;

namespace Virtable.Core.GridAggregate.Columns;

[JsonDerivedType(typeof(StringColumn))]
[JsonDerivedType(typeof(NumericColumn))]
[JsonDerivedType(typeof(EmailColumn))]
[JsonDerivedType(typeof(ValidatedStringColumn))]
[JsonDerivedType(typeof(SelectColumn))]
[JsonDerivedType(typeof(MultiselectColumn))]
public abstract class Column : BaseEntity, IAggregateRoot
{
    public abstract ColumnType Discriminator { get; protected set; }
}
