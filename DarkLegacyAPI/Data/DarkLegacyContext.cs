using DarkLegacyAPI.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace DarkLegacyAPI.Data
{
    public class DarkLegacyContext : DbContext
    {
        public DarkLegacyContext(DbContextOptions<DarkLegacyContext> options) : base(options)
        {
        }

        public DbSet<Generos> Generos { get; set; }
        public DbSet<Jogos> Jogos { get; set; }
    }
}
