using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using System.IO;

namespace Enceja.Infrastructure
{
    public class ApplicationDbContextFactory : IDesignTimeDbContextFactory<ApplicationDbContext>
    {
        public ApplicationDbContext CreateDbContext(string[] args)
        {
            var basePath = Path.Combine(Directory.GetParent(Directory.GetCurrentDirectory()).FullName, "Escola.API");
            var dbFolder = Path.Combine(basePath, "Database");
            var dbPath = Path.Combine(dbFolder, "databaseDev.db");

            if (!Directory.Exists(dbFolder))
            {
                Directory.CreateDirectory(dbFolder);
            }

            var optionsBuilder = new DbContextOptionsBuilder<ApplicationDbContext>();
            optionsBuilder.UseSqlite($"Data Source={dbPath}");

            return new ApplicationDbContext(optionsBuilder.Options);
        }
    }

}
