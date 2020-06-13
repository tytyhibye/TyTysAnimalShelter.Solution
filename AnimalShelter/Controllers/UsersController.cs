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

      /// <summary>
    /// Allows retrieval of user authentication token.
    /// </summary>
    /// <remarks>
    /// Sample request:
    ///     
    ///     POST api/users/authenticate
    ///     {
    ///        "UserName": MyFavoriteInstructor,
    ///        "Password": "YourPassword",
    ///     }
    /// </remarks>
    /// <param name="userParam"></param>
    /// <returns>User authentication token</returns>
    /// <response code="201">Returns the users token</response>
    /// <response code="401">The username and/or password are incorrect</response>
      [AllowAnonymous]
      [HttpPost("authenticate")]
      public IActionResult Authenticate([FromBody]User userParam)
      {
          
          var user = _userService.Authenticate(userParam.Username, userParam.Password);
          
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