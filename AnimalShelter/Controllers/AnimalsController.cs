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

    /// <summary>
    /// Returns a list of all available animals.
    /// </summary>
    /// <param name="id"></param>
    // GET api/Animals
    [HttpGet]
    public ActionResult<IEnumerable<Animal>> Get(int age, string name, string species, string gender) // binds query parameter to this string description
    {
      Console.WriteLine("We are inside Animals controller");
      var query = _db.Animals.AsQueryable(); // returns all Animals in database as a queryable LINQ object
      if (name == null && species == null && age == 0 && gender == null)
      {
        return _db.Animals.ToList();
      }

      if (age > 0)
      {
        query = query.Where(entry => entry.Age == age);
        // Console.WriteLine("we are in ages");
      }
      
      if (name != null)
      {
        query = query.Where(entry => entry.Name == name);
        // Console.WriteLine("we are in name");
      }

      if (gender != null)
      {
        query = query.Where(entry => entry.Gender == gender);
        // Console.WriteLine("we are in gender");
      }

      if (species != null)
      {
        query = query.Where(entry => entry.Species == species);
        // Console.WriteLine("we are in species");
      }

      return query.ToList(); 
    }

    /// <summary>
    /// Searches for a specific animal by Id.
    /// </summary>
    /// <param name="id"></param>
    // GET api/Animals/5
    [HttpGet("{id}")] //returns existing api entry
    public ActionResult<Animal> Get(int id)
    {
      return _db.Animals.FirstOrDefault(entry => entry.AnimalId == id);
    }

    /// <summary>
    /// Creates an animal listing.
    /// </summary>
    /// <remarks>
    /// Sample request:
    ///
    ///     POST /animals
    ///     {
    ///        "AnimalId": 1,
    ///        "Name": "Herman",
    ///        "Species": "Cat",
    ///        "Description": "Very "Boop-able", loves bellyrubs."
    ///        "Age": 5
    ///     }
    /// </remarks>
    /// <param name="Animal"></param>
    /// <returns>A newly created Animal</returns>
    /// <response code="201">Returns the newly created Animal</response>
    /// <response code="400">If the Animal is null</response>
    // POST api/Animals
    [HttpPost] // adds new api entry
    [ProducesResponseType(StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public void Post([FromBody] Animal animal)
    {
      _db.Animals.Add(animal);
      _db.SaveChanges();
    }

    /// <summary>
    /// Edits a specific animal.
    /// </summary>
    /// <param name="id"></param>
    // PUT api/Animals/5
    [HttpPut("{id}")] // edits existing api entry
    public void Put(int id, [FromBody] Animal animal)
    {
      animal.AnimalId = id;
      _db.Entry(animal).State = EntityState.Modified;
      _db.SaveChanges();
    }

    /// <summary>
    /// Deletes a specific animal.
    /// </summary>
    /// <param name="id"></param>
    [HttpDelete("{id}")] // deletes existing api entry
    public void Delete(int id)
    {
      var animalToDelete = _db.Animals.FirstOrDefault(entry => entry.AnimalId == id);
      _db.Animals.Remove(animalToDelete);
      _db.SaveChanges();
    }
  }
}
