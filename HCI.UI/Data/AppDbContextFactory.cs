using HCI.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace Maintaineer.UI.Data
{
    public class AppDbContextFactory : IDesignTimeDbContextFactory<AppDbContext>
    {

        public AppDbContext CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<AppDbContext>();
            optionsBuilder.UseMySql(System.Configuration.ConfigurationManager.
    ConnectionStrings["MySQL"].ConnectionString,
                b => b.MigrationsAssembly("HCI.UI"));

            return new AppDbContext(optionsBuilder.Options);
        }
    }
}
