using Microsoft.EntityFrameworkCore;
using RACEDAY_PART3_.Models.Entites;

namespace RACEDAY_PART3_.Data
{
    public class ApplicationDBContext : DbContext
    {
        public ApplicationDBContext(DbContextOptions<ApplicationDBContext> options) : base(options)
        {
        }

        public DbSet<Users> Users { get; set; }

    }
}
