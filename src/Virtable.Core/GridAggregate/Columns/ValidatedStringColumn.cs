using System.Text.Json.Serialization;
using System.Text.RegularExpressions;
using Virtable.Core.ColumnAggregate;

namespace Virtable.Core.GridAggregate.Columns;

[JsonDerivedType(typeof(EmailColumn))]
public class ValidatedStringColumn : Column
{
    public ValidatedStringColumn(string pattern)
    {
        Pattern = pattern;
    }
    public string Pattern { get; set; }
    public override ColumnType Discriminator { get; protected set; } = ColumnType.ValidatedString;

    public virtual bool CanStore(string value)
    {
        return Regex.IsMatch(value, Pattern);
    }

    public virtual bool CannotStore(string value)
    {
        return !CanStore(value);
    }
}
