using Microsoft.AspNetCore.Mvc;
using TodoList.Domain;
using TodoList.DTOs.dtos;
using TodoList.Services;

namespace TodoList.Controllers;

[ApiController]
[Route("api/assignment")]
public class AssignmentController(IAssignmentService assignmentService) : Controller
{
    [Route("create")]
    [HttpPost]
    public async Task Create([FromBody] AssignmentSiteDTO assignment) => await assignmentService.Create(assignment);

    [Route("getAll")]
    [HttpGet]
    public async Task<List<Assignment>> GetAll() => await assignmentService.GetAll();

    [Route("{id:int}")]
    [HttpGet]
    public async Task GetById(int id) => await assignmentService.GetById(id);
    
    [Route("update")]
    [HttpPost]
    public async Task GetById(AssignmentSiteDTO assignment) => await assignmentService.Update(assignment);
    
    [Route("{id:int}")]
    [HttpPost]
    public async Task DeleteById(int id) => await assignmentService.Delete(id);
}