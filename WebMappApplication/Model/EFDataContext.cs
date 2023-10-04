using Microsoft.EntityFrameworkCore;

namespace WebMappApplication.Model
{
    public class EFDataContext : DbContext
    {
        public EFDataContext(DbContextOptions<EFDataContext> context): base(context) { }
        public DbSet<Door> Doors { get; set; }  
    }
}
