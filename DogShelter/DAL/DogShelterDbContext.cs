using DogShelter.Model;
using Microsoft.EntityFrameworkCore;

namespace DogShelter.DAL
{
    public class DogShelterDbContext : DbContext
    {
        public DbSet<Dog> Dogs { get; set; }
        public DbSet<Shelter> Shelters { get; set; }
        public DbSet<User> Users { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseMySQL("server=localhost;port=3306;database=dogshelter;user=root;password=123456");
        }

        public DogShelterDbContext(DbContextOptions options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            var userList = new[]
            {
                new User {Id = 1, Name = "Ákos", Phonenumber = "030134231"},
                new User {Id = 2, Name = "Dani", Phonenumber = "244234234"},
                new User {Id = 3, Name = "Virág", Phonenumber = "244232334"}
            };

            var shelterList = new[]
            {
                new Shelter {Id = 1, Name = "Gödöllői menhely", Address = "Gödöllő", OwnerId = 1 },
                new Shelter {Id = 2, Name = "Lelenc menhely", Address = "Szada", OwnerId = 3 }
            };

            var dogList = new[]
            {
                new Dog { Id = 1, Name = "Zsuli", Age = 1, Breed = "Jack Russel Terrier", ShelterId = 1 },
                new Dog { Id = 2, Name = "Lulu", Age = 14, Breed = "Beagle", OwnerId = 1 },
                new Dog { Id = 3, Name = "Füge", Age = 1, Breed = "Cuki", ShelterId = 2 },
                new Dog { Id = 4, Name = "Guszti", Age = 15, Breed = "Valami", OwnerId = 2 }
            };

            modelBuilder.Entity<Dog>(entity =>
            {
                entity.ToTable("Dog");
                entity.HasKey(e => e.Id);
                entity.Property(e => e.Name).IsRequired();
                entity.Property(e => e.Age).HasDefaultValue(0);
                entity.Property(e => e.Breed).IsRequired();
            });


            modelBuilder.Entity<Shelter>(entity =>
            {
                entity.ToTable("Shelter");
                entity.HasKey(e => e.Id);
                entity.Property(e => e.Name).IsRequired();
                entity.Property(e => e.Address).IsRequired();
                entity.HasMany(e => e.Dogs)
                    .WithOne(e => e.Shelter)
                    .HasForeignKey(e => e.ShelterId);
            });


            modelBuilder.Entity<User>(entity =>
            {
                entity.ToTable("User");
                entity.HasKey(e => e.Id);
                entity.Property(e => e.Name);
                entity.Property(e => e.Phonenumber);
                entity.HasMany(e => e.Dogs)
                    .WithOne(e => e.Owner)
                    .HasForeignKey(e => e.OwnerId);
                entity.HasMany(e => e.Shelters)
                    .WithOne(e => e.Owner)
                    .HasForeignKey(e => e.OwnerId);
            });

            modelBuilder.Entity<User>().HasData(userList);
            modelBuilder.Entity<Shelter>().HasData(shelterList);
            modelBuilder.Entity<Dog>().HasData(dogList);

            base.OnModelCreating(modelBuilder);
        }
    }
}
