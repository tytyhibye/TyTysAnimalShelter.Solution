using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using AnimalShelter.Services;
using AnimalShelter.Models;
using System;


namespace AnimalShelter.Controllers
{
  [Authorize]
  [ApiController]
  [Produces("application/json")]
  [Route("api/[controller]")]
  public class UsersController : ControllerBase
  {
      private AnimalShelterContext _db;
      
      private IUserService _userService;

      public UsersController(AnimalShelterContext db, IUserService userService)
      {
          _db = db;
          _userService = userService;
      }

      [AllowAnonymous]
      [HttpPost("authenticate")]
      public IActionResult Authenticate([FromBody]User userParam)
      {
          // Console.WriteLine($"\n\n\n\n\n" + $"We are inside Users Controller anonymous allowed {userParam.Username} and {userParam.Password}" + "\n\n\n\n\n");
          var user = _userService.Authenticate(userParam.Username, userParam.Password);
          
          // Console.WriteLine($"\n\n\n\n\n" + $"value for the user variable is = {user}" + "\n\n\n\n\n");
          if (user == null)
              return BadRequest(new { message = "Definitely not the correct username or password" });

          return Ok(user);
      }

      [AllowAnonymous]
      [HttpGet]
      public IActionResult GetAll()
      {
          var users =  _userService.GetAll();
          return Ok(users);
      }
    }
}