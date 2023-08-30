using DarkLegacy.Core.Models;
using Microsoft.EntityFrameworkCore;

namespace DarkLegacy.Core.Data
{
    public class DarkLegacyContext : DbContext
    {
        public DarkLegacyContext(DbContextOptions<DarkLegacyContext> options) : base(options) { }

        public DbSet<Genre> Genre { get; set; }

        public DbSet<Game> Game { get; set; }
    }
}