using HR.LeaveManagement.Application.Contracts.Identity;
using HR.LeaveManagement.Application.Models.Identity;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HR.LeaveManagement.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IAuthService _authenticationService;
        private readonly IUserService _userService;

        public AuthController(IAuthService authenticationService, IUserService userService)
        {
            this._authenticationService = authenticationService;
            this._userService = userService;
        }

        [HttpPost("login")]
        public async Task<ActionResult<AuthResponse>> Login(AuthRequest request)
        {
            return Ok(await _authenticationService.Login(request));
        }

        [HttpPost("register")]
        public async Task<ActionResult<RegistrationResponse>> Register(RegistrationRequest request)
        {
            return Ok(await _authenticationService.Register(request));
        }

        [HttpGet("employees")]
        public async Task<ActionResult<IEnumerable<Employee>>> GetEmployees()
        {
            var employees = await _userService.GetEmployees();
            return Ok(employees);
        }

        [HttpGet("employee/{id}")]
        public async Task<ActionResult<Employee>> GetEmployee(string id)
        {
            var employee = await _userService.GetEmployee(id);
            if (employee == null)
            {
                return NotFound(); 
            }
            return Ok(employee);
        }
    }
}