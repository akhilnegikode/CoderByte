using CoderByte.API.Model.Entities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace CoderByte.API.Data
{
    public class EmployeeDbContext : IdentityDbContext<AppUser>
    {
        public EmployeeDbContext(DbContextOptions<EmployeeDbContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Employee> Employees { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Employee>().HasKey(x => x.EmployeeNumber);

            modelBuilder.Entity<Employee>()
                .HasOne(x => x.Identity);
        }
    }
}
