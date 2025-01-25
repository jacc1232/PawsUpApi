using Microsoft.EntityFrameworkCore;
using PetsManagerApi.Models;

namespace PetsManagerApi.DataAccess
{
    public class PetDbContext:DbContext
    {
        public PetDbContext(DbContextOptions<PetDbContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Users>()
                .HasKey(u => u.IdUser);  // Estableces la clave primaria
            modelBuilder.Entity<Pets>()
                .HasKey(p => p.IdPets);
        }
        public DbSet<Users> Users { get; set; }
        public DbSet<Pets> Pets { get; set; }
    }
}
