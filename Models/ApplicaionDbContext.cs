using Microsoft.EntityFrameworkCore;

namespace ASP.NetCoreWebApiProject.Models
{
    public class ApplicaionDbContext : DbContext
    {
        public DbSet<Product> Products { get; set; }

        public ApplicaionDbContext(DbContextOptions<ApplicaionDbContext> options) : base(options) { }
    }
}
