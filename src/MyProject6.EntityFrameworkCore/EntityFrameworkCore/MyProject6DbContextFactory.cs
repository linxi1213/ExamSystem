using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using MyProject6.Configuration;
using MyProject6.Web;

namespace MyProject6.EntityFrameworkCore
{
    /* This class is needed to run "dotnet ef ..." commands from command line on development. Not used anywhere else */
    public class MyProject6DbContextFactory : IDesignTimeDbContextFactory<MyProject6DbContext>
    {
        public MyProject6DbContext CreateDbContext(string[] args)
        {
            var builder = new DbContextOptionsBuilder<MyProject6DbContext>();
            var configuration = AppConfigurations.Get(WebContentDirectoryFinder.CalculateContentRootFolder());

            MyProject6DbContextConfigurer.Configure(builder, configuration.GetConnectionString(MyProject6Consts.ConnectionStringName));

            return new MyProject6DbContext(builder.Options);
        }
    }
}
