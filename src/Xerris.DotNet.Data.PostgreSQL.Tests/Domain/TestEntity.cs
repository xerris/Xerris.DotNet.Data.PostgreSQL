using Xerris.DotNet.Data.Domain;

namespace Xerris.DotNet.Data.PostgreSQL.Tests.Domain;

public class TestEntity : AuditImmutableBase
{
    public string Name { get; set; } = string.Empty;
}