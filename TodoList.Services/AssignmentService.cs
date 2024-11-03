using System.Net.Http.Json;
using Microsoft.EntityFrameworkCore;
using TodoList.DAL;
using TodoList.Domain;
using TodoList.DTOs.dtos;

namespace TodoList.Services;

public interface IAssignmentService 
{
     public Task Create(AssignmentSiteDTO siteDto);
     public Task<Assignment?> GetById(int id);
     public Task<List<Assignment>> GetAll();
     public Task Delete(int id);
     public Task<Assignment> Update(AssignmentSiteDTO assignmentSiteDto);
}

public class AssignmentService(AppDbContext dbContext): IAssignmentService
{
    public async Task Create(AssignmentSiteDTO siteDto)
    {
        var assignment = new Assignment()
        {
            Title = siteDto.Title, Description = siteDto.Description, Priority = siteDto.Priority,
            Completed = null, Created = DateTime.Now
        };

        await dbContext.Assignments.AddAsync(assignment);
        await dbContext.SaveChangesAsync();
    }

    public async Task<Assignment?> GetById(int id) =>
        await dbContext.Assignments.AsNoTracking().FirstOrDefaultAsync(x => x.Id == id);

    public async Task<List<Assignment>> GetAll() => await dbContext.Assignments.AsNoTracking().ToListAsync();

    public async Task Delete(int id)
    {
        var assignment = await GetById(id);
        if (assignment == null) return;
        dbContext.Assignments.Remove(assignment);
        await dbContext.SaveChangesAsync();
    }

    public async Task<Assignment> Update(AssignmentSiteDTO assignmentSiteDto)
    {
        var assignment = await GetById(assignmentSiteDto.Id);
        if (assignment == null) throw new Exception("Assignment not found");

        var updatedAssignment = new Assignment()
        {
            Created = assignment.Created,

            Completed = assignmentSiteDto.Completed,
            Description = assignmentSiteDto.Description,
            Priority = assignmentSiteDto.Priority,
            Title = assignmentSiteDto.Title,
            Id = assignmentSiteDto.Id
        };

        dbContext.Assignments.Update(updatedAssignment);

        await dbContext.SaveChangesAsync();
        return assignment;
    }
}