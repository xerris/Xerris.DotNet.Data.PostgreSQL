using Microsoft.EntityFrameworkCore;

namespace Xerris.DotNet.Data.PostgreSQL.Tests.Context;

public class TestPostgresDbContextFactory : PostgresDbContextFactory<TestDbContext>
{
    public TestPostgresDbContextFactory(IConnectionBuilder connectionBuilder, IDbContextObserver observer)
        : base(connectionBuilder, observer)
    {
    }

    protected override TestDbContext Create(DbContextOptions<DbContextBase> options, 
        IDbContextObserver observer)
    {
        return new TestDbContext(options, observer);
    }
}