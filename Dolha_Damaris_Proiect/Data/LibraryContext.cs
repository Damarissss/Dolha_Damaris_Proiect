using Dolha_Damaris_Proiect.Models;
using Microsoft.EntityFrameworkCore;

namespace Dolha_Damaris_Proiect.Data
{
    // Translator file between the C# models and the SQL code (the database)
    public class LibraryContext: DbContext
    {
        // Default constructor
        public LibraryContext(DbContextOptions<LibraryContext> options) : base(options)
        {
        }

        // Instructions for the many-to-many relationship
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Actor_Movie>().HasKey(am => new { am.ActorId, am.MovieId });

            // Define "Actor_Movie" as the joining model
            modelBuilder.Entity<Actor_Movie>().HasOne(m => m.Movie).WithMany(am => am.Actors_Movies).HasForeignKey(m => m.MovieId);
            modelBuilder.Entity<Actor_Movie>().HasOne(m => m.Actor).WithMany(am => am.Actors_Movies).HasForeignKey(m => m.ActorId);
        }

        public DbSet<Actor> Actors { get; set; }
        public DbSet<Movie> Movies { get; set; }
        public DbSet<Actor_Movie> Actors_Movies { get; set; }
        public DbSet<Cinema> Cinemas { get; set; }
        public DbSet<Producer> Producers { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Order> Orders { get; set; }
    }
}
