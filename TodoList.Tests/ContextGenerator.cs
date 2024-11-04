using Microsoft.EntityFrameworkCore;
using TodoList.DAL;

namespace TodoList.Tests;

internal static class ContextGenerator
{
    public static AppDbContext GetContext()
    {
        var builder = new DbContextOptionsBuilder<AppDbContext>();
        builder
            .EnableSensitiveDataLogging()
            .UseInMemoryDatabase(Guid.NewGuid().ToString())
            .UseQueryTrackingBehavior(QueryTrackingBehavior.NoTracking);
        return new AppDbContext(builder.Options);
    }
}