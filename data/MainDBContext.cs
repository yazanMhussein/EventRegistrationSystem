using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Event_Registration_System.Models;

namespace Event_Registration_System.data
{
    public class MainDBContext : IdentityDbContext<UserAuth>
    {

        public MainDBContext(DbContextOptions options) : base(options)
        {

        }
        public DbSet<Event> Events { get; set; }
        public DbSet<Registration> Registrations { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Seed some events if you choose Option 2
            modelBuilder.Entity<Event>().HasData(
                new Event { Id = 1, Title = "Tech Conference", Date = new DateTime(2024, 11, 15), Description = "A conference about tech", Capacity = 200 },
                new Event { Id = 2, Title = "Music Festival", Date = new DateTime(2024, 12, 25), Description = "A large outdoor music festival", Capacity = 5000 }
            );
        }
    }
}