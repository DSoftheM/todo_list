using Microsoft.EntityFrameworkCore;
using TodoList.DAL;

namespace TodoList.Tests;

internal static class ContextGenerator
{
    public static AppDbContext GetContext() =>
        new(new DbContextOptionsBuilder<AppDbContext>().UseInMemoryDatabase(Guid.NewGuid().ToString()).Options);
}