using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Virtable.Core.ColumnAggregate;
using Virtable.Core.GridAggregate.Columns;

namespace Virtable.Infrastructure.Data.Config;

internal class ColumnConfig : IEntityTypeConfiguration<Column>
{
    public void Configure(EntityTypeBuilder<Column> builder)
    {
        builder.HasDiscriminator(e => e.Discriminator)
            .HasValue<StringColumn>(ColumnType.String)
            .HasValue<NumericColumn>(ColumnType.Numeric)
            .HasValue<SelectColumn>(ColumnType.Select)
            .HasValue<MultiselectColumn>(ColumnType.Multiselect)
            .HasValue<EmailColumn>(ColumnType.Email)
            .HasValue<ValidatedStringColumn>(ColumnType.ValidatedString);
    }
}
