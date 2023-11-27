using Microsoft.EntityFrameworkCore;

using CommonCode.Models;

namespace MauiBlazorApp.Models
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }
        public DbSet<PersonModel> People { get; set; }
        public DbSet<Telefonnummer> TelNr { get; set; }
    }
}
