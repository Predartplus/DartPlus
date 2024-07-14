using Microsoft.EntityFrameworkCore;
using DartPlusAPI.Models;

namespace DartPlusAPI.Models
{
    public class PlusDbContext: DbContext
    {
        public PlusDbContext(DbContextOptions<PlusDbContext> options) : base(options)
        {
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            //optionsBuilder.UseSqlServer("OurConnectionString");
        }
        public DbSet<Test> Test { get; set; } = default!;
        public DbSet<Login> Login { get; set; } = default!;
    }
}
