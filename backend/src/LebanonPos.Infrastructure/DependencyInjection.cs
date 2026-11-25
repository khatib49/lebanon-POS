using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace LebanonPos.Infrastructure;

public static class DependencyInjection
{
    /// <summary>
    /// Registers the database. Supabase is used as plain PostgreSQL, so moving to another
    /// PostgreSQL host later only means changing the connection string.
    /// </summary>
    public static IServiceCollection AddPosDatabase(this IServiceCollection services, string connectionString)
    {
        services.AddDbContext<PosDbContext>(options => options
            .UseNpgsql(connectionString, npgsql => npgsql.MigrationsAssembly(typeof(PosDbContext).Assembly.FullName))
            .UseSnakeCaseNamingConvention());
        return services;
    }
}
