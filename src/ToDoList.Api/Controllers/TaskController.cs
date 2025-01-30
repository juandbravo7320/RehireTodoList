using MediatR;
using Microsoft.AspNetCore.Mvc;
using ToDoList.Application.Tasks.Commands.CreateTask;
using ToDoList.Application.Tasks.Commands.UpdateTask;

namespace ToDoList.Api.Controllers;

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
}