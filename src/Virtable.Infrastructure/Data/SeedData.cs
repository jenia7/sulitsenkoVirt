using Microsoft.Extensions.DependencyInjection;

namespace Virtable.Infrastructure.Data;

public static class SeedData
{
    public static void EnsureDbPopulated(IServiceProvider serviceProvider)
    {
        using var dbContext = serviceProvider.GetRequiredService<AppDbContext>();

        if (dbContext.Grids.Any())
        {
            return;
        }

        dbContext.Grids.AddRange();

        dbContext.SaveChanges();
    }
}
