using Microsoft.EntityFrameworkCore;

namespace DartPlusAPI.DBContext
{
    public class PlusDbContext : DbContext
    {
        public PlusDbContext(DbContextOptions<PlusDbContext> options) : base(options)
        {
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            //optionsBuilder.UseSqlServer("OurConnectionString");
        }

        public DbSet<Tenants> Tenants { get; set; } = default!;
        public DbSet<Users> Users { get; set; } = default!;
        public DbSet<Roles> Roles { get; set; } = default!;
        public DbSet<UserRoles> UserRoles { get; set; } = default!;
        public DbSet<Patients> Patients { get; set; } = default!;
        public DbSet<AppLOV> AppLOV { get; set; } = default!;

    }
}
