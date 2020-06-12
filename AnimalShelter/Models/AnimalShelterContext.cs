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
          new Animal { AnimalId = 1, Name = "Jennifur", Species = "Cat", Gender = "Female", Description = "Very boop-able. Loves bellyrubs.", Age = 5, ImageUrl = "https://www.rover.com/blog/wp-content/uploads/2019/09/funny-cat-960x540.jpg"},
          new Animal { AnimalId = 2, Name = "Chanteclaire", Species = "Dog", Gender = "Male", Description = "A prince among floofs. He only eats organic free-range waygu beef. Requires nightly brushing", Age = 3, ImageUrl = "https://www.wallpaperflare.com/static/98/704/904/white-brown-teacup-pomeranian-wallpaper-preview.jpg"},
          new Animal { AnimalId = 3, Name = "Garfield", Species = "Cat", Gender = "Male", Description = "Yes THAT Garfield. Retired hollywood cat looking for a fresh start. Loves Lazagna, hates mondays and requires diabetic medication.", Age = 42, ImageUrl = "https://i.redd.it/hq4is2vxe4y21.jpg"},
          new Animal { AnimalId = 4, Name = "Mr.Grump", Species = "Cat", Gender = "Male", Description = "Looks like a butthead but he's a big ol' softy once you get to know him.", Age = 14, ImageUrl = "https://i.imgur.com/x9K5JYo.jpg"},
          new Animal { AnimalId = 5, Name = "Smiley", Species = "Dog", Gender = "Female", Description = "True to her name this gal literally can't stop smiling. Gluten Free", Age = 5, ImageUrl = "https://encrypted-tbn0.gstatic.com/images?q=tbn%3AANd9GcQKbCHEc_uRla-QRmnDse9ktweLdkE1C8c2_hD_rD_9MFTKQJKT&usqp=CAU"}
        );

        builder.Entity<User>()
      .HasData(
        new User { Id = 1,  Username = "Tyler", Password = "test" },
        new User { Id = 2,  Username = "MyFavoriteInstructor", Password = "itsyou" }
      );
    }
  }
}