using System.ComponentModel.DataAnnotations;

namespace AnimalShelter.Models
{
  public class Animal
  {
    public int AnimalId { get; set; }
    [Required]
    [StringLength(50)]
    public string Name { get; set; }
    [Required]
    public string Gender { get; set; }
    [Required]
    public string Species { get; set; }
    [Required]
    [StringLength(500, ErrorMessage = "Description must be less than 500 characters")]
    public string Description { get; set; }
    [Required]
    public int Age { get; set; }
    public string ImageUrl { get; set; }
    
  }
}