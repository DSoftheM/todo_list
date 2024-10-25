using Microsoft.AspNetCore.Mvc;
using TodoList.Domain;
using TodoList.Services;

namespace TodoList.Controllers;

[ApiController]
[Route("api/assignment")]
public class AssignmentController(AssignmentService assignmentService)
{
    [Route("/create")]
    [HttpPost]
    public string Create(AssignmentSiteDTO assignment) => assignmentService.Create(assignment);
}