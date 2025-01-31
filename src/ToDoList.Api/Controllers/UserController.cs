using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ToDoList.Application.Users.Commands.RegisterUser;
using ToDoList.Application.Users.Commands.UpdateUser;
using ToDoList.Application.Users.Queries.Login;

namespace ToDoList.Api.Controllers;

[Authorize]
[ApiController]
[Route("api/[controller]")]
public class UserController(ISender sender) : ControllerBase
{
    [HttpPost]
    [AllowAnonymous]
    [Route("register")]
    public async Task<IActionResult> RegisterUser([FromBody] RegisterUserCommand request)
    {
        var result = await sender.Send(request);
        if (result.IsFailure) return BadRequest(result.Error);
        return Ok(result.Value);
    }
    
    [HttpPut]
    public async Task<IActionResult> UpdateUser([FromBody] UpdateUserCommand request)
    {
        var result = await sender.Send(request);
        if (result.IsFailure) return BadRequest(result.Error);
        return Ok();
    }
    
    
    [HttpPost]
    [AllowAnonymous]
    [Route("login")]
    public async Task<IActionResult> Login([FromBody] LoginQuery request)
    {
        var result = await sender.Send(request);
        if (result.IsFailure) return BadRequest(result.Error);
        return Ok(result.Value);
    }
}