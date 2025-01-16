using Microsoft.EntityFrameworkCore;
using Xerris.DotNet.Data.PostgreSQL.Tests.Domain;

namespace Xerris.DotNet.Data.PostgreSQL.Tests.Context;

public class TestDbContext : DbContext
{
    public DbSet<TestEntity> TestEntities { get; set; }

    public TestDbContext(DbContextOptions<DbContext> options) : base(options)
    {
    }
}

public class TestPostgresDbContextFactory : PostgresDbContextFactory<TestDbContext>
{
    public TestPostgresDbContextFactory(IConnectionBuilder connectionBuilder, IDbContextObserver observer)
        : base(connectionBuilder, observer)
    {
    }

    protected override TestDbContext Create(DbContextOptions<DbContext> applyOptions,
        IDbContextObserver dbContextObserver) =>
        new(applyOptions);
}