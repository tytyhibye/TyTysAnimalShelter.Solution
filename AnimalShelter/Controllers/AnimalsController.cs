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
  public class AnimalsController : ControllerBase
  {
    private AnimalShelterContext _db;

    public AnimalsController(AnimalShelterContext db)
    {
      _db = db;
    }

    // GET api/Animals
    [HttpGet]
    public ActionResult<IEnumerable<Animal>> Get(int age, string name, string species) // binds query parameter to this string description
    {
      Console.WriteLine("We are inside Animals controller");
      var query = _db.Animals.AsQueryable(); // returns all Animals in database as a queryable LINQ object
      if (name == null && species == null && age == 0)
      {
        return _db.Animals.ToList();
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

    // GET api/Animals/5
    [HttpGet("{id}")] //returns existing api entry
    public ActionResult<Animal> Get(int id)
    {
      return _db.Animals.FirstOrDefault(entry => entry.AnimalId == id);
    }

    // POST api/Animals
    [HttpPost] // adds new api entry
    [ProducesResponseType(StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public void Post([FromBody] Animal animal)
    {
      _db.Animals.Add(animal);
      _db.SaveChanges();
    }

    // PUT api/Animals/5
    [HttpPut("{id}")] // edits existing api entry
    public void Put(int id, [FromBody] Animal animal)
    {
      Animal.AnimalId = id;
      _db.Entry(animal).State = EntityState.Modified;
      _db.SaveChanges();
    }
