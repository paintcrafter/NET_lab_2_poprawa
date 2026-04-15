using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;

namespace Maui.Data
{
    public class CocktailDbContext : DbContext
    {
        public CocktailDbContext() { }

        public CocktailDbContext(DbContextOptions<CocktailDbContext> options)
            : base(options)
        {
        }

        public DbSet<CocktailEntity> Cocktails => Set<CocktailEntity>();
        public DbSet<CocktailCategory> Categories => Set<CocktailCategory>();

        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            if (!options.IsConfigured)
            {
                var dbPath = Path.Combine(
                Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData),
                "Cocktails.db");

                options.UseSqlite($"Data Source={dbPath}");
            }
        }
    }
}
