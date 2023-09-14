using Microsoft.EntityFrameworkCore;
using PersonalContactInformation.Library.Models;

namespace PersonalContactInformation.Api.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }
        public DbSet<Person> People { get; set; }
        public DbSet<Telefonnummer> TelNr { get; set; }
    }
}
