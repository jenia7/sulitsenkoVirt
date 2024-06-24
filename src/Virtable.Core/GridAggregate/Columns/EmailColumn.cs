using System.Text.RegularExpressions;
using Virtable.Core.GridAggregate.Columns;

namespace Virtable.Core.ColumnAggregate;

public partial class EmailColumn : ValidatedStringColumn
{
    [GeneratedRegex(EmailPattern, RegexOptions.Compiled)]
    private static partial Regex EmailRegex();
    private const string EmailPattern = @"@mail\.";

    public EmailColumn() : base(EmailPattern)
    {
    }

    public override ColumnType Discriminator { get; protected set; } = ColumnType.Email;

    public override bool CanStore(string email)
    {
        return EmailRegex().IsMatch(email);
    }

    public override bool CannotStore(string email)
    {
        return !CanStore(email);
    }

}
