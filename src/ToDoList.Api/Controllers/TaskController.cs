using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ToDoList.Application.Tasks.Commands.CreateTask;
using ToDoList.Application.Tasks.Commands.UpdateTask;
using ToDoList.Application.Tasks.Queries.ListTasks;
using ToDoList.Domain.Abstractions;
using TaskStatus = ToDoList.Domain.Tasks.TaskStatus;

namespace ToDoList.Api.Controllers;

[Authorize]
[ApiController]
[Route("api/[controller]")]
public class TaskController(ISender sender) : ControllerBase
{
    [HttpPost]
    public async Task<IActionResult> CreateTask([FromBody] CreateTaskCommand request)
    {
        var result = await sender.Send(request);
        if (result.IsFailure) return BadRequest(result.Error);
        return Ok(result.Value);
    }
    
    [HttpPut]
    public async Task<IActionResult> CreateTask([FromBody] UpdateTaskCommand request)
    {
        var result = await sender.Send(request);
        if (result.IsFailure) return BadRequest(result.Error);
        return Ok();
    }
    
    [HttpGet]
    public async Task<IActionResult> CreateTask(
        [FromQuery] int pageNumber,
        [FromQuery] int pageSize,
        [FromQuery] string? description, 
        [FromQuery] TaskStatus? status)
    {
        var request = new ListTasks(
            description, 
            status, 
            new Page(pageNumber, pageSize));
        
        var result = await sender.Send(request);
        if (result.IsFailure) return BadRequest(result.Error);
        return Ok(result.Value);
    }
}