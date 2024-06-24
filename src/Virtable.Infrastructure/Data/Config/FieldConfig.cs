using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Virtable.Core.GridAggregate.Records;

namespace Virtable.Infrastructure.Data.Config;

internal class FieldConfig : IEntityTypeConfiguration<Field>
{
    public void Configure(EntityTypeBuilder<Field> builder)
    {
        builder.HasDiscriminator(e => e.Discriminator)
            .HasValue<StringField>(FieldType.String)
            .HasValue<NumericField>(FieldType.Numeric);
    }
}
