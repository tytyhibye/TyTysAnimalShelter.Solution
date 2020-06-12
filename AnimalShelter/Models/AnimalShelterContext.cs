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
          new Animal { AnimalId = 1, Name = "Herman", Species = "Cat", Description = "Very boop-able. Loves bellyrubs.", Age = 5, ImageUrl = "https://www.themediterraneantraveller.com/wp-content/uploads/2018/11/greece-heraklion-00032.jpg"},
          new Animal { AnimalId = 2, Name = "Chanteclaire", Species = "Dog", Description = "A prince among floofs. He only eats organic free-range waygu beef. Requires nightly brushing", Age = 3, ImageUrl = "https://cdn.travelpulse.com/images/65aaedf4-a957-df11-b491-006073e71405/c8f899f1-a4af-4ea3-b5dd-447ebbaeb40e/630x355.jpg"},
          new Animal { AnimalId = 3, Name = "Garfield", Species = "Cat", Description = "Yes THAT Garfield. Retired hollywood cat looking for a fresh start. Loves Lazagna, hates mondays and requires diabetic medication.", Age = 42, ImageUrl = "https://www.toursbylocals.com/images/guides/46/46460/202027064423775.jpg"}
        );

        builder.Entity<User>()
      .HasData(
        new User { Id = 1,  Username = "Tyler", Password = "test" },
        new User { Id = 2,  Username = "MyFavoriteInstructor", Password = "itsyou" }
      );
    }
  }
}