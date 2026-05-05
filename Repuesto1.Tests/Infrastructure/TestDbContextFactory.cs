using Microsoft.EntityFrameworkCore;
using Repuesto1.Data.Context;

namespace Repuesto1.Tests.Infrastructure;

public static class TestDbContextFactory
{
    public static string NewDatabaseName() => $"Repuesto1Tests_{Guid.NewGuid()}";

    public static RepuestoContext CreateContext(string databaseName)
    {
        var options = new DbContextOptionsBuilder<RepuestoContext>()
            .UseInMemoryDatabase(databaseName)
            .Options;

        return new InMemoryRepuestoContext(options);
    }

    private sealed class InMemoryRepuestoContext(DbContextOptions<RepuestoContext> options)
        : RepuestoContext(options)
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            // Intentionally empty: tests provide InMemory provider through options.
        }
    }
}