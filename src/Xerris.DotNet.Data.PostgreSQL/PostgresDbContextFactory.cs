using Microsoft.EntityFrameworkCore;

namespace Xerris.DotNet.Data.PostgreSQL;

public abstract class PostgresDbContextFactory<T> : DbContextFactory<T> where T : DbContext
{
    public PostgresDbContextFactory(IConnectionBuilder connectionBuilder, IDbContextObserver observer) 
        : base(connectionBuilder, observer )
    {
    }

    protected override DbContextOptions<DbContext> ApplyOptions(bool sensitiveDataLoggingEnabled = false)
    {
        AppContext.SetSwitch("Npgsql.EnableLegacyTimestampBehavior", true);

        return new DbContextOptionsBuilder<DbContext>().UseNpgsql(ConnectionBuilder.AdminConnectionString,
                                                          sqlOptions => { sqlOptions.EnableRetryOnFailure(); })
            .UseSnakeCaseNamingConvention()
            .EnableSensitiveDataLogging(sensitiveDataLoggingEnabled: sensitiveDataLoggingEnabled)
            .EnableDetailedErrors()
            .Options;
    }
}