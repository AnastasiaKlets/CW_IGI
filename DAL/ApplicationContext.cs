using Microsoft.EntityFrameworkCore;
using Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace DAL
{
    public class ApplicationContext : DbContext
    {
        public ApplicationContext(DbContextOptions options)
            : base(options)
        {
            //Database.EnsureDeleted();
            //Database.EnsureCreated();
            base.ChangeTracker.QueryTrackingBehavior = QueryTrackingBehavior.NoTracking;
        }


        public virtual DbSet<Actor> Actors { get; set; }
        public virtual DbSet<AgeQualification> AgeQualifications { get; set; }
        public virtual DbSet<Genre> Genres { get; set; }
        public virtual DbSet<Hall> Halls { get; set; }
        public virtual DbSet<Performance> Performances { get; set; }
        public virtual DbSet<Place> Places { get; set; }
        public virtual DbSet<Ticket> Tickets { get; set; }
        public virtual DbSet<Session> Sessions { get; set; }
        public virtual DbSet<TypeOfSeat> TypeOfSeats { get; set; }
        public virtual DbSet<User> Users { get; set; }

        //
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // использование Fluent API
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Performance>()
                 .HasMany(c => c.Actors)
                 .WithMany(s => s.Performances);
            
            modelBuilder.Entity<Performance>()
                 .HasMany(c => c.Genres)
                 .WithMany(s => s.Performances);

            //modelBuilder.Entity<Session>()
            //    .HasOne<Performance>(e => e.Performance)
            //    .WithMany();

        }
    }
}
