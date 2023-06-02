using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using ReceiptApp.API.Security.Domain.Models;
using ReceiptApp.API.Security.Domain.Services;
using ReceiptApp.API.Security.Domain.Services.Communication.Request;
using ReceiptApp.API.Security.Resources.Create;
using Swashbuckle.AspNetCore.Annotations;

namespace ReceiptApp.API.Security.Interface.Rest;

[ApiController]
[Route("/api/v0/[controller]")]
public class UserController : ControllerBase
{
    private readonly IUserService _userService;
    private readonly IMapper _mapper;

    public UserController(IUserService userService, IMapper mapper)
    {
        _userService = userService;
        _mapper = mapper;
    }

    [HttpGet("all")]
    public async Task<IEnumerable<User>> GetAll()
    {
        return await _userService.ListAsync();
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetById(Guid userId)
    {
        var result = await _userService.FindAsync(userId);
        if (result == null)
            return BadRequest("Not found");
        return Ok(result);
    }

    [HttpPost("sign-in")]
    public async Task<IActionResult> AuthenticateUser([FromBody, SwaggerRequestBody("")] AuthRequest authRequest)
    {
        var result = await _userService.AuthenticateAsync(authRequest);
        if (!result.Success)
            return BadRequest(result.Message);
        return Ok(new { message = "Successfully authenticated", resource = result.Resource });
    }


    [HttpPost("sign-up")]
    public async Task<IActionResult> RegisterUser([FromBody, SwaggerRequestBody("")] RegisterRequest registerRequest)
    {
        await _userService.RegisterAsync(registerRequest);
        return Ok(new { message = "Successfully registered." });
    }
}