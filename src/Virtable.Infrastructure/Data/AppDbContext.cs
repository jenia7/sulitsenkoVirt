using System.Reflection;
using Microsoft.EntityFrameworkCore;
using SmartEnum.EFCore;
using Virtable.Core.GridAggregate;
using Virtable.Core.GridAggregate.Columns;
using Virtable.Core.GridAggregate.Records;

namespace Virtable.Infrastructure.Data;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options)
        : base(options)
    {
    }

    public DbSet<Grid> Grids => Set<Grid>();
    public DbSet<Column> Columns => Set<Column>();
    public DbSet<Record> Records => Set<Record>();
    public DbSet<Field> Fields => Set<Field>();

    protected override void OnModelCreating(ModelBuilder builder)
    {
        Assembly asm = Assembly.GetExecutingAssembly();
        builder.ApplyConfigurationsFromAssembly(asm);

        builder.Entity<Grid>()
            .HasMany(e => e.Records)
            .WithOne().IsRequired();
        builder.Entity<Record>()
            .HasMany(e => e.Fields)
            .WithOne().IsRequired();
        builder.Entity<Field>()
            .HasOne(e => e.Column).WithMany()
            .IsRequired();

        builder.Entity<NumericField>()
            .Property(e => e.Number).HasPrecision(20, 10); // modelBuilder.ConfigureSmartEnum();
    }

    protected override void ConfigureConventions(ModelConfigurationBuilder builder)
    {
        builder.ConfigureSmartEnum();
    }
}
