using Microsoft.EntityFrameworkCore;
using NewSportsAcademy.Models;

namespace NewSportsAcademy.Data
{
    public class SchoolContext : DbContext
    {
        public SchoolContext(DbContextOptions<SchoolContext> options) : base(options)
        {
        }

        public DbSet<Student> Students { get; set; }
        public DbSet<Sport> Sports { get; set; }
        public DbSet<Fixture> Fixtures { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Student>().ToTable("Student");
            modelBuilder.Entity<Sport>().ToTable("Sport");
            modelBuilder.Entity<Fixture>().ToTable("Fixture");
        }
    }
}

