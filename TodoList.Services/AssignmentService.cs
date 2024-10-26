using System.Net.Http.Json;
using Microsoft.EntityFrameworkCore;
using TodoList.DAL;
using TodoList.Domain;
using TodoList.DTOs.dtos;

namespace TodoList.Services;

public class AssignmentService(AppDbContext dbContext)
{
    public async Task Create(AssignmentSiteDTO siteDto)
    {
        var assignment = new Assignment()
        {
            Title = siteDto.Title, Description = siteDto.Description, Priority = siteDto.Priority,
            Created = DateTime.Now
        };

        await dbContext.Assignments.AddAsync(assignment);
        await dbContext.SaveChangesAsync();
    }


    public async Task<Assignment?> GetById(int id)
    {
        return await dbContext.Assignments.AsNoTracking().FirstOrDefaultAsync(x => x.Id == id);
    }

    public async Task<Todo[]> GetFromJsonPlaceholder()
    {
        var httpClient = new HttpClient();
        var json = await httpClient.GetFromJsonAsync<Todo[]>("https://jsonplaceholder.typicode.com/todos");
        return json ?? [];
    }
}

public class Todo
{
    public int Id { get; set; }
    public int UserId { get; set; }
    public bool Completed { get; set; }
    public string Title { get; set; }
}