using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ToDoList.Application.Users.Commands.RegisterUser;

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
}