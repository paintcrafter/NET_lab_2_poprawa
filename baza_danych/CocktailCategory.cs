using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace baza_danych
{
    internal class CocktailCategory
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public ICollection<CocktailEntity> Cocktails { get; set; }
    }

    internal class CocktailDbContext : DbContext
    {
        public CocktailDbContext()
        {
            Database.EnsureCreated();
        }
        public DbSet<CocktailEntity> Cocktails { get; set; }
        public DbSet<CocktailCategory> Categories { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            string basePath = AppDomain.CurrentDomain.BaseDirectory;
            string dbPath = Path.Combine(basePath, "cocktails.db");
            options.UseSqlite($"Data Source={dbPath}");
        }
    }
}
