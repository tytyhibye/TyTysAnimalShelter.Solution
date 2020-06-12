using Microsoft.EntityFrameworkCore;

namespace AnimalShelter.Models
{
  public class AnimalShelterContext : DbContext
  {
    public AnimalShelterContext(DbContextOptions<AnimalShelterContext> options)
        : base(options)
    {
    }

    public DbSet<Animal> Animals { get; set; }
    public DbSet<User> Users { get; set; }

    protected override void OnModelCreating(ModelBuilder builder)
    {
      builder.Entity<Animal>()
        .HasData(
          new Animal { AnimalId = 1, Name = "Herman", Species = "Cat", Description = "Very boop-able. Loves bellyrubs.", Age = 5, ImageUrl = ""},
          new Animal { AnimalId = 2, Name = "Chanteclaire", Species = "Dog", Description = "A prince among floofs. He only eats organic free-range waygu beef. Requires nightly brushing", Age = 3, ImageUrl = ""},
          new Animal { AnimalId = 3, Name = "Garfield", Species = "Cat", Description = "Yes THAT Garfield. Retired hollywood cat looking for a fresh start. Loves Lazagna, hates mondays and requires diabetic medication.", Age = 42, ImageUrl = ""}
        );

        builder.Entity<User>()
      .HasData(
        new User { Id = 1,  Username = "Tyler", Password = "test" },
        new User { Id = 2,  Username = "MyFavoriteInstructor", Password = "itsyou" }
      );
    }
  }
}