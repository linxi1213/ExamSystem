using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using ExamText.Configuration;
using ExamText.Web;

namespace ExamText.EntityFrameworkCore
{
    /* This class is needed to run "dotnet ef ..." commands from command line on development. Not used anywhere else */
    public class ExamTextDbContextFactory : IDesignTimeDbContextFactory<ExamTextDbContext>
    {
        public ExamTextDbContext CreateDbContext(string[] args)
        {
            var builder = new DbContextOptionsBuilder<ExamTextDbContext>();
            var configuration = AppConfigurations.Get(WebContentDirectoryFinder.CalculateContentRootFolder());

            ExamTextDbContextConfigurer.Configure(builder, configuration.GetConnectionString(ExamTextConsts.ConnectionStringName));

            return new ExamTextDbContext(builder.Options);
        }
    }
}
