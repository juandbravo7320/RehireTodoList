using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ToDoList.Application.Tasks.Commands.CreateTask;
using ToDoList.Application.Tasks.Commands.DeleteTask;
using ToDoList.Application.Tasks.Commands.UpdateTask;
using ToDoList.Application.Tasks.Queries.ListTasks;
using ToDoList.Domain.Abstractions;
using ToDoList.Domain.Users;
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
        if (result.IsFailure && result.Error == UserErrors.Unauthorized) return Forbid();
        if (result.IsFailure) return BadRequest(result.Error);
        return Ok(result.Value);
    }
    
    [HttpPut]
    public async Task<IActionResult> UpdateTask([FromBody] UpdateTaskCommand request)
    {
        var result = await sender.Send(request);
        if (result.IsFailure && result.Error == UserErrors.Unauthorized) return Forbid();
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
        if (result.IsFailure && result.Error == UserErrors.Unauthorized) return Forbid();
        if (result.IsFailure) return BadRequest(result.Error);
        return Ok(result.Value);
    }
    
    [HttpDelete]
    public async Task<IActionResult> DeleteTask([FromQuery] Guid id)
    {
        var request = new DeleteTaskCommand(id);
        var result = await sender.Send(request);
        if (result.IsFailure && result.Error == UserErrors.Unauthorized) return Forbid();
        if (result.IsFailure) return BadRequest(result.Error);
        return Ok();
    }
}