using Microsoft.EntityFrameworkCore;
using PetShop.Models;

namespace PetShop.Data
{
    public class PetShopDbContext : DbContext
    {
        public virtual DbSet<Animal> Animals { get; set; }
        public virtual DbSet<Category> Categories { get; set; }
        public virtual DbSet<Comment> Comments { get; set; }
        
        public PetShopDbContext(DbContextOptions<PetShopDbContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Categories
            modelBuilder.Entity<Category>().HasData(
                new Category { CategoryId = 1, Name = "Mammals" },
                new Category { CategoryId = 2, Name = "Birds" },
                new Category { CategoryId = 3, Name = "Fish" }
            );

            string defaultUserName = "default";
            // Comments
            modelBuilder.Entity<Comment>().HasData(
                // Golden Retriever
                new Comment
                {
                    Id = 2,
                    AnimalId = 1,
                    Content = "Golden Retrievers are the best!",
                    UserName = defaultUserName
                },
                new Comment
                {
                    Id = 3,
                    AnimalId = 1,
                    Content = "Great with kids and so friendly!",
                    UserName = defaultUserName
                },
                // Persian Cat
                new Comment
                {
                    Id = 4,
                    AnimalId = 2,
                    Content = "Elegant and graceful cat!",
                    UserName = defaultUserName
                },
                new Comment
                {
                    Id = 5,
                    AnimalId = 2,
                    Content = "Persians are so majestic!",
                    UserName = defaultUserName
                },
                // Colorful Macaw
                new Comment
                {
                    Id = 6,
                    AnimalId = 3,
                    Content = "So vibrant and full of life!",
                    UserName = defaultUserName
                },
                new Comment
                {
                    Id = 7,
                    AnimalId = 3,
                    Content = "Macaws are incredibly smart!",
                    UserName = defaultUserName
                },
                // Siamese Fighting Fish
                new Comment
                {
                    Id = 8,
                    AnimalId = 4,
                    Content = "Stunning colors and grace!",
                    UserName = defaultUserName
                },
                new Comment
                {
                    Id = 9,
                    AnimalId = 4,
                    Content = "A real beauty in the water!",
                    UserName = defaultUserName
                },
                // Dwarf Hamster
                new Comment
                {
                    Id = 10,
                    AnimalId = 5,
                    Content = "So tiny and adorable!",
                    UserName = defaultUserName
                },
                new Comment
                {
                    Id = 11,
                    AnimalId = 5,
                    Content = "Perfect pet for small spaces.",
                    UserName = defaultUserName
                },
                // Maine Coon Cat
                new Comment
                {
                    Id = 12,
                    AnimalId = 6,
                    Content = "Maine Coons are so fluffy!",
                    UserName = defaultUserName
                },
                new Comment
                {
                    Id = 13,
                    AnimalId = 6,
                    Content = "Gentle giants of the cat world.",
                    UserName = defaultUserName
                },
                // Shetland Pony
                new Comment
                {
                    Id = 16,
                    AnimalId = 8,
                    Content = "Perfect pony for kids!",
                    UserName = defaultUserName
                },
                new Comment
                {
                    Id = 17,
                    AnimalId = 8,
                    Content = "Shetlands are so sturdy!",
                    UserName = defaultUserName
                },
                // Border Collie 
                new Comment
                {
                    Id = 18,
                    AnimalId = 9,
                    Content = "Smartest dogs ever!",
                    UserName = defaultUserName
                },
                new Comment
                {
                    Id = 19,
                    AnimalId = 9,
                    Content = "Energetic and fun-loving.",
                    UserName = defaultUserName
                },
                // Holland Lop Rabbit
                new Comment
                {
                    Id = 20,
                    AnimalId = 10,
                    Content = "So cuddly and cute!",
                    UserName = defaultUserName
                },
                new Comment
                {
                    Id = 21,
                    AnimalId = 10,
                    Content = "Lops have the best ears!",
                    UserName = defaultUserName
                },
                // African Grey Parrot
                new Comment
                {
                    Id = 22,
                    AnimalId = 11,
                    Content = "Incredible talkers!",
                    UserName = defaultUserName
                },
                new Comment
                {
                    Id = 23,
                    AnimalId = 11,
                    Content = "So intelligent and witty.",
                    UserName = defaultUserName
                },
                // Cockatiel
                new Comment
                {
                    Id = 24,
                    AnimalId = 12,
                    Content = "Adorable and friendly birds.",
                    UserName = defaultUserName
                },
                new Comment
                {
                    Id = 25,
                    AnimalId = 12,
                    Content = "Love their chirps and songs!",
                    UserName = defaultUserName
                },
                // Goldfish
                new Comment
                {
                    Id = 26,
                    AnimalId = 13,
                    Content = "Classic and charming fish.",
                    UserName = defaultUserName
                },
                new Comment
                {
                    Id = 27,
                    AnimalId = 13,
                    Content = "Goldfish bring so much joy!",
                    UserName = defaultUserName
                },
                // Angelfish
                new Comment
                {
                    Id = 28,
                    AnimalId = 14,
                    Content = "Elegant and beautiful fish.",
                    UserName = defaultUserName
                },
                new Comment
                {
                    Id = 29,
                    AnimalId = 14,
                    Content = "Angelfish are truly majestic!",
                    UserName = defaultUserName
                },
                // Pygmy Goat
                new Comment
                {
                    Id = 30,
                    AnimalId = 15,
                    Content = "Pygmy goats are so playful!",
                    UserName = defaultUserName
                },
                new Comment
                {
                    Id = 31,
                    AnimalId = 15,
                    Content = "Perfect for small farms.",
                    UserName = defaultUserName
                },
                new Comment
                {
                    Id = 32,
                    AnimalId = 15,
                    Content = "Adorable and great with kids!",
                    UserName = defaultUserName
                },
                new Comment
                {
                    Id = 33,
                    AnimalId = 1,
                    Content = "The Golden Retriever is not just a dog; it's a bundle of joy and loyalty! Its friendly nature and playful demeanor make it the perfect family companion. I can't imagine a better furry friend!",
                    UserName = defaultUserName
                }, 
                new Comment
                {
                    Id = 34,
                    AnimalId = 1,
                    Content = "Our Golden Retriever is more than a pet; it's a member of the family. Its loyalty is unmatched, and its friendly disposition warms our hearts every day. Truly, a golden addition to any home!",
                    UserName = defaultUserName

                }
            );

            // Animals
            modelBuilder.Entity<Animal>().HasData(
                new Animal
                {
                    AnimalId = 1,
                    Name = "Golden Retriever",
                    Age = 3,
                    PictureName = "golden_retriever.jpg",
                    Description = "A loyal and friendly Golden Retriever.",
                    CategoryId = 1, // Mammals
                },
                new Animal
                {
                    AnimalId = 2,
                    Name = "Persian Cat",
                    Age = 2,
                    PictureName = "persian_cat.jpg",
                    Description = "An elegant Persian cat.",
                    CategoryId = 1, // Mammals
                },
                new Animal
                {
                    AnimalId = 3,
                    Name = "Colorful Macaw",
                    Age = 5,
                    PictureName = "macaw.jpg",
                    Description = "A vibrant and colorful Macaw.",
                    CategoryId = 2, // Birds
                },
                new Animal
                {
                    AnimalId = 4,
                    Name = "Siamese Fighting Fish",
                    Age = 1,
                    PictureName = "betta_fish.jpg",
                    Description = "A beautiful Siamese Fighting Fish.",
                    CategoryId = 3, // Fish
                },
                new Animal
                {
                    AnimalId = 5,
                    Name = "Dwarf Hamster",
                    Age = 1,
                    PictureName = "dwarf_hamster.jpg",
                    Description = "A tiny and cute Dwarf Hamster.",
                    CategoryId = 1, // Mammals
                }, 
                new Animal
                {
                    AnimalId = 6,
                    Name = "Maine Coon Cat",
                    Age = 3,
                    PictureName = "maine_coon.jpg",
                    Description = "A large and sociable Maine Coon Cat with a majestic appearance.",
                    CategoryId = 1, // Mammals
                },
                new Animal
                {
                    AnimalId = 7,
                    Name = "Labrador Retriever",
                    Age = 3,
                    PictureName = "labrador_retriever.jpg",
                    Description = "A friendly and active Labrador Retriever, great as a family pet.",
                    CategoryId = 1, // Mammals
                },
                new Animal
                {
                    AnimalId = 8,
                    Name = "Shetland Pony",
                    Age = 5,
                    PictureName = "shetland_pony.jpg",
                    Description = "A small but strong Shetland Pony, perfect for young riders.",
                    CategoryId = 1, // Mammals
                },
                new Animal
                {
                    AnimalId = 9,
                    Name = "Border Collie",
                    Age = 3,
                    PictureName = "border_collie.jpg",
                    Description = "An intelligent and energetic Border Collie, excellent for agility.",
                    CategoryId = 1, // Mammals
                },
                new Animal
                {
                    AnimalId = 10,
                    Name = "Holland Lop Rabbit",
                    Age = 1,
                    PictureName = "holland_lop.jpg",
                    Description = "A cute and fluffy Holland Lop Rabbit with droopy ears.",
                    CategoryId = 1, // Mammals
                },
                new Animal
                {
                    AnimalId = 11,
                    Name = "African Grey Parrot",
                    Age = 4,
                    PictureName = "african_grey.jpg",
                    Description = "An intelligent African Grey Parrot, known for its impressive talking abilities.",
                    CategoryId = 2, // Birds
                },
                new Animal
                {
                    AnimalId = 12,
                    Name = "Cockatiel",
                    Age = 2,
                    PictureName = "cockatiel.jpg",
                    Description = "A charming Cockatiel, known for its crest and melodic chirping.",
                    CategoryId = 2, // Birds
                },
                new Animal
                {
                    AnimalId = 13,
                    Name = "Goldfish",
                    Age = 1,
                    PictureName = "goldfish.jpg",
                    Description = "A popular and easy-to-care-for Goldfish.",
                    CategoryId = 3, // Fish
                },
                new Animal
                {
                    AnimalId = 14,
                    Name = "Angelfish",
                    Age = 2,
                    PictureName = "angelfish.jpg",
                    Description = "A striking Angelfish, known for its unique shape and colors.",
                    CategoryId = 3, // Fish
                },
                new Animal
                {
                    AnimalId = 15,
                    Name = "Pygmy Goat",
                    Age = 1,
                    PictureName = "pygmy_goat.jpg",
                    Description = "A playful and charming Pygmy Goat, great for small farms and families.",
                    CategoryId = 1, // Mammals
                }
            );
        }
    }
}
