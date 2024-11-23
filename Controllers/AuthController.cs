//using Microsoft.AspNetCore.Http;
//using Microsoft.AspNetCore.Identity.Data;
//using Microsoft.AspNetCore.Mvc;
//using NexCart.Repositories;
//using NexCart.Models;
//using Microsoft.IdentityModel.Tokens;
//using System.IdentityModel.Tokens.Jwt;
//using System.Security.Claims;
//using System.Text;

//namespace NexCart.Controllers
//{
//    [Route("api/[controller]")]
//    [ApiController]
//    public class UsersController : ControllerBase
//    {
//        IServiceUsers _userService;
//        public UsersController(IServiceUsers employeeService)
//        {
//            _userService = employeeService;
//        }
//        [Route("GetAll")]
//        [HttpGet]
//        public IActionResult GetAll()
//        {
//            try
//            {
//                var emp = _userService.Get();
//                if (emp == null)
//                {
//                    return NotFound();
//                }
//                return Ok(emp);
//            }
//            catch (Exception ex)
//            {
//                return BadRequest(ex.Message);
//            }

//        }

//        [Route("GetById")]
//        [HttpPost]
//        public IActionResult GetByID([FromBody] int id)
//        {
//            try
//            {
//                if (id <= 0)
//                {
//                    return BadRequest("Invalid ID provided.");
//                }
//                var emp = _userService.GetById(id);
//                if (emp == null)
//                {
//                    return NotFound();
//                }
//                return Ok(emp);
//            }
//            catch (Exception ex)
//            {
//                return BadRequest(ex.Message);
//            }

//        }

//        [Route("Login")]
//        [HttpPost]
//        public IActionResult Login([FromBody] LoginRequestByUser loginRequest)
//        {
//            try
//            {
//                if (loginRequest == null || string.IsNullOrEmpty(loginRequest.Name) || string.IsNullOrEmpty(loginRequest.Password))
//                {
//                    return BadRequest("Invalid login request. Please provide username and password.");
//                }

//                // Authenticate the user
//                var user = _userService.Authenticate(loginRequest.Name, loginRequest.Password);

//                if (user == null)
//                {
//                    return Unauthorized("Invalid username or password.");
//                }

//                return Ok(new
//                {
//                    Message = "Login successful",
//                    UserDetails = user
//                });
//            }
//            catch (Exception ex)
//            {
//                return StatusCode(500, "An error occurred: " + ex.Message);
//            }
//        }

//    }
//}
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using NexCart.Models;
using NexCart.Repositories;
using System;
using System.ComponentModel.DataAnnotations;
using System.IdentityModel.Tokens.Jwt;
using System.Reflection.Metadata;
using System.Security.Claims;
using System.Text;

[Route("api/[controller]")]
[ApiController]
public class AuthController : ControllerBase
{
    private readonly IUserRepository _userRepository;
    private readonly string _jwtKey;

    public AuthController(IUserRepository userRepository, IConfiguration configuration)
    {
        _userRepository = userRepository;
        _jwtKey = configuration["Jwt:Key"];
    }

    // POST: api/auth/signup
    [HttpPost("signup")]
    public IActionResult Signup([FromBody] SignUpModel user)
    {
        if (user == null || string.IsNullOrWhiteSpace(user.Email) || string.IsNullOrWhiteSpace(user.Password))
        {
            return BadRequest("Invalid user data.");
        }

        // Hash the password before saving the user
        
        var PasswordHash = HashPassword(user.Password);
        var newUser = new User(){ FirstName =user.FirstName  , LastName = user.LastName , Email = user.Email , PasswordHash =  PasswordHash , ContactNumber=user.ContactNumber};
        _userRepository.AddUser(newUser); // Save the user to the database
        
        return Ok(newUser);
    }

    // POST: api/auth/login
    [HttpPost("login")]
    public IActionResult Login([FromBody] LoginModel loginModel)
    {
        if (loginModel == null || string.IsNullOrWhiteSpace(loginModel.Email) || string.IsNullOrWhiteSpace(loginModel.Password))
        {
            return BadRequest("Invalid login data.");
        }

        var user = _userRepository.GetUserByUsername(loginModel.Email);
        //Console.WriteLine(user.FirstName);
        if (user == null)
        {
            return BadRequest("no user");
        }
        if (!VerifyPassword(loginModel.Password, user.PasswordHash))
        {
            return Unauthorized("Invalid  password.");
        }

        var token = GenerateJwtToken(user);
        return Ok(new { Token = token });
    }

    private string HashPassword(string password)
    {
        // Automatically generates a salt and hashes the password
        return BCrypt.Net.BCrypt.HashPassword(password);
    }

    private bool VerifyPassword(string password, string storedHash)
    {
        // Compares the plain-text password with the stored hash
        return BCrypt.Net.BCrypt.Verify(password, storedHash);
    }


    private string GenerateJwtToken(User user)
    {
        var claims = new[]
        {
            new Claim(JwtRegisteredClaimNames.Sub, user.Email),
            new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
            //new Claim(ClaimTypes.Role, user.UserType.ToString())
        };

        var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_jwtKey));
        var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

        var token = new JwtSecurityToken(
            issuer: "Nexcart", // Optional
            audience: "YourAppUsers", // Optional
            claims: claims,
            expires: DateTime.Now.AddDays(10),
            signingCredentials: creds);

        return new JwtSecurityTokenHandler().WriteToken(token);
    }
}

public class LoginModel
{
    public string Email { get; set; }
    public string Password { get; set; }

}
public class SignUpModel
{
    [Required]
    public string FirstName { get; set; }
    [Required]
    public string LastName { get; set; }
    [Required]
    public string Password { get; set; }
    [Required]
    public string Email { get; set; }

    [Required]
    public string ContactNumber { get; set; }

}