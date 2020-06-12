using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using AnimalShelter.Models;


namespace AnimalShelter.Controllers
{
  [Authorize]
  [Produces("application/json")]
  [Route("api/[controller]")]
  [ApiController]
  public class PlacesController : ControllerBase
  {
    private AnimalShelterContext _db;

    public PlacesController(AnimalShelterContext db)
    {
      _db = db;
    }

    // GET api/places
    [HttpGet]
    public ActionResult<IEnumerable<Place>> Get(int age, string name, string species) // binds query parameter to this string description
    {
      Console.WriteLine("We are inside places controller");
      var query = _db.Places.AsQueryable(); // returns all Places in database as a queryable LINQ object
      if (name == null && species == null && age == 0)
      {
        return _db.Places.ToList();
      }

      if (age > 0)
      {
        query = query.Where(entry => entry.age == age);
        // Console.WriteLine("we are in ages");
      }
      
      if (name != null)
      {
        query = query.Where(entry => entry.name == name);
        // Console.WriteLine("we are in name");
      }

      if (species != null)
      {
        query = query.Where(entry => entry.species == species);
        // Console.WriteLine("we are in species");
      }

      return query.ToList(); 
    }