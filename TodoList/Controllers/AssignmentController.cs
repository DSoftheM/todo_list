using Microsoft.AspNetCore.Mvc;
using TodoList.DTOs.dtos;
using TodoList.Services;

namespace TodoList.Controllers;

[ApiController]
[Route("api/assignment")]
public class AssignmentController(AssignmentService assignmentService) : Controller
{
    [Route("")]
    [HttpPost]
    public async Task Create([FromBody] AssignmentSiteDTO assignment) => await assignmentService.Create(assignment);

    [Route("")]
    [HttpGet]
    public async Task GetById(int id) => await assignmentService.GetById(id);

    [Route("json-placeholder")]
    [HttpGet]
    public async Task<Todo[]> GetMockAssignmentsFromJsonPlaceholder() =>
        await assignmentService.GetFromJsonPlaceholder();
}