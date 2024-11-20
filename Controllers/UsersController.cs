using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity.Data;
using Microsoft.AspNetCore.Mvc;
using NexCart.Repositories;
using NexCart.Models;

namespace NexCart.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        IServiceUsers _userService;
        public UsersController(IServiceUsers employeeService)
        {
            _userService = employeeService;
        }
        [Route("GetAll")]
        [HttpGet]
        public IActionResult GetAll()
        {
            try
            {
                var emp = _userService.Get();
                if (emp == null)
                {
                    return NotFound();
                }
                return Ok(emp);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }

        [Route("GetById")]
        [HttpPost]
        public IActionResult GetByID([FromBody] int id)
        {
            try
            {
                if (id <= 0)
                {
                    return BadRequest("Invalid ID provided.");
                }
                var emp = _userService.GetById(id);
                if (emp == null)
                {
                    return NotFound();
                }
                return Ok(emp);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }

        [Route("Login")]
        [HttpPost]
        public IActionResult Login([FromBody] LoginRequestByUser loginRequest)
        {
            try
            {
                if (loginRequest == null || string.IsNullOrEmpty(loginRequest.Name) || string.IsNullOrEmpty(loginRequest.Password))
                {
                    return BadRequest("Invalid login request. Please provide username and password.");
                }

                // Authenticate the user
                var user = _userService.Authenticate(loginRequest.Name, loginRequest.Password);

                if (user == null)
                {
                    return Unauthorized("Invalid username or password.");
                }

                return Ok(new
                {
                    Message = "Login successful",
                    Username = user
                });
            }
            catch (Exception ex)
            {
                return StatusCode(500, "An error occurred: " + ex.Message);
            }
        }

    }
}
