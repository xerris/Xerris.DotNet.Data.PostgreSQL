using FluentAssertions;
using Moq;
using Xerris.DotNet.Data.PostgreSQL.Tests.Context;

namespace Xerris.DotNet.Data.PostgreSQL.Tests;

public class PostgresDbContextFactoryTests : IDisposable
{  
    private readonly MockRepository mockRepository;
    private readonly TestPostgresDbContextFactory factory;

    public PostgresDbContextFactoryTests()
    {
        mockRepository = new MockRepository(MockBehavior.Strict);
        
        var connectionBuilderMock1 = mockRepository.Create<IConnectionBuilder>();
        var observerMock1 = mockRepository.Create<IDbContextObserver>();

        connectionBuilderMock1.Setup(cb => cb.AdminConnectionString).Returns("Host=localhost;Database=testdb;Username=testuser;Password=testpassword");

        factory = new TestPostgresDbContextFactory(connectionBuilderMock1.Object, observerMock1.Object);
    }

    [Fact]
    public void Create_ShouldReturnDbContextInstance()
    {
        // Act
        var context = factory.Create();

        // Assert
        context.Should().NotBeNull();
        context.Should().BeOfType<TestDbContext>();
    }

    public void Dispose() => mockRepository.VerifyAll();
}