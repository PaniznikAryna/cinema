using Microsoft.EntityFrameworkCore;
using Cinema.Entity;
using System.Collections.Generic;

namespace Cinema.Infrastructure.Data
{
    public class CinemaContext : DbContext
    {
        public CinemaContext(DbContextOptions<CinemaContext> options)
            : base(options)
        {
        }

        public DbSet<Genre> Genres { get; set; }
        public DbSet<Hall> Halls { get; set; }
        public DbSet<Movie> Movies { get; set; }
        public DbSet<Participant> Participants { get; set; }
        public DbSet<Seat> Seats { get; set; }
        public DbSet<SeatType> SeatTypes { get; set; }
        public DbSet<Session> Sessions { get; set; }
        public DbSet<Ticket> Tickets { get; set; }
        public DbSet<User> Users { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Movie>()
                .HasMany(m => m.Genres)
                .WithMany(g => g.Movies)
                .UsingEntity<Dictionary<string, object>>(
                    "MovieGenre",
                    j => j.HasOne<Genre>()
                          .WithMany()
                          .HasForeignKey("GenreId"),
                    j => j.HasOne<Movie>()
                          .WithMany()
                          .HasForeignKey("MovieId"));

            base.OnModelCreating(modelBuilder);
        }
    }
}
