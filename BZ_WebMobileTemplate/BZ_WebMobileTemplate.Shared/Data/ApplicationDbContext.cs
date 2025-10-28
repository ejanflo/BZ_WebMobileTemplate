using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System.Globalization;

namespace BZ_WebMobileTemplate.Shared.Data
{
    public class ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : IdentityDbContext<ApplicationUser>(options)
    {
        public DbSet<UPRO_S_Function> Functions { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            // Configure UPRO_S_Function entity to map to the correct table name
            builder.Entity<UPRO_S_Function>().ToTable("UPRO_S_Function");
        }
    }
}
