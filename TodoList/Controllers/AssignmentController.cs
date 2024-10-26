using Microsoft.AspNetCore.Mvc;
using TodoList.DTOs.dtos;
using TodoList.Services;

namespace TodoList.Controllers;

[ApiController]
[Route("api/assignment")]
public class AssignmentController(AssignmentService assignmentService) : Controller
{
    [Route("create")]
    [HttpPost]
    public async Task Create(AssignmentSiteDTO assignment) => await assignmentService.Create(assignment);

    [Route("json-placeholder")]
    [HttpGet]
    public async Task<Todo[]> GetMockAssignmentsFromJsonPlaceholder() =>
        await assignmentService.GetFromJsonPlaceholder();
}