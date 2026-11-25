using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace LebanonPos.Infrastructure;

/// <summary>Used only by the "dotnet ef" command line to create migrations.</summary>
public class DesignTimeFactory : IDesignTimeDbContextFactory<PosDbContext>
{
    private sealed class NoShop : ICurrentShop { public Guid? ShopId => null; }

    public PosDbContext CreateDbContext(string[] args)
    {
        var connection = Environment.GetEnvironmentVariable("ConnectionStrings__Default")
            ?? "Host=localhost;Database=lebpos_dev;Username=lebpos;Password=lebpos";
        var options = new DbContextOptionsBuilder<PosDbContext>()
            .UseNpgsql(connection)
            .UseSnakeCaseNamingConvention()
            .Options;
        return new PosDbContext(options, new NoShop());
    }
}
