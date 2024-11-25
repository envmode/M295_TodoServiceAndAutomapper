using M295_TodoServiceAndAutomapper.Models.DTO.Requests;
using M295_TodoServiceAndAutomapper.Services.Abstract;
using Microsoft.AspNetCore.Mvc;

[Route("api/[controller]")]
[ApiController]
public class AuthManagementController : ControllerBase
{
    private readonly IAuthManagementService _authManagementService;

    public AuthManagementController(IAuthManagementService authManagementService)
    {
        _authManagementService = authManagementService;
    }

    [HttpPost]
    [Route("Register")]
    public async Task<IActionResult> Register([FromBody] UserRegistrationRequestDTO user)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(new RegistrationResponse
            {
                Success = false,
                Errors = new List<string> { "Ungültiger Payload" }
            });
        }

        var response = await _authManagementService.Register(user);
        return response.Success ? Ok(response) : BadRequest(response);
    }

    [HttpPost]
    [Route("Login")]
    public async Task<IActionResult> Login([FromBody] UserLoginRequest user)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(new RegistrationResponse
            {
                Success = false,
                Errors = new List<string> { "Ungültiger Payload" }
            });
        }

        var response = await _authManagementService.Login(user);
        return response.Success ? Ok(response) : BadRequest(response);
    }
}