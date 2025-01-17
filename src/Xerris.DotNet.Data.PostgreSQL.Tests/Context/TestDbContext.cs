using Microsoft.EntityFrameworkCore;
using Xerris.DotNet.Data.PostgreSQL.Tests.Domain;

namespace Xerris.DotNet.Data.PostgreSQL.Tests.Context;

public class TestDbContext : DbContextBase
{
    public DbSet<TestEntity> TestEntities { get; set; }

    public TestDbContext(DbContextOptions<DbContextBase> options, IDbContextObserver observer) 
        : base(options, observer)
    {
    }

    protected override void RegisterModels(ModelBuilder modelBuilder)
    {
    }
}