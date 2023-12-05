using Microsoft.EntityFrameworkCore;
using WebApplication1.Models;

namespace WebApplication1.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> option) : base(option)
        {
            
        }
        public DbSet<Catergory> Categories { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Catergory>().HasData(
                new Catergory {Id = 1,Category = "Action",DisplayOrder = 2,},
                new Catergory { Id = 2, Category = "History", DisplayOrder = 5, },
                new Catergory { Id = 3, Category = "Sci-Fi", DisplayOrder = 4, }
                );
        }
    }
}
