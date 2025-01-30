using Microsoft.AspNetCore.Mvc;
using ria.smc.associates.DataAccessLayer.Interfaces.Users;
using ria.smc.associates.UI.Models.Login;

namespace ria.smc.associates.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUsersRepository _usersRepository;

        public UserController(IUsersRepository usersRepository)
        {
            _usersRepository = usersRepository;
        }
        [HttpPost]
        [Route("GetUserInformation")]
        public async Task<IActionResult> GetUserInformation([FromBody] LoginRequest request)
        {
            LoginResponse loginResponse = new LoginResponse();
            if (request == null || string.IsNullOrEmpty(request.UserName) || string.IsNullOrEmpty(request.Password))
            {
                return BadRequest("Invalid login request.");
            }
            try
            {
                loginResponse = await _usersRepository.GetUserInformation(request);
                return Ok(loginResponse);
            }
            catch (Exception ex)
            {
                return StatusCode(500, "An unexpected error occurred. Please try again later.");
            }
        }
    }
}
