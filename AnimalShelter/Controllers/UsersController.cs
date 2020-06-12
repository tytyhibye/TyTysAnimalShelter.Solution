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

        [HttpGet]
        public IActionResult GetAll()
        {
            var users =  _userService.GetAll();
            return Ok(users);
        }
    }
}