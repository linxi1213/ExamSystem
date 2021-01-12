using System.Data.Common;
using Microsoft.EntityFrameworkCore;

namespace ExamText.EntityFrameworkCore
{
    public static class ExamTextDbContextConfigurer
    {
        public static void Configure(DbContextOptionsBuilder<ExamTextDbContext> builder, string connectionString)
        {
            builder.UseSqlServer(connectionString);
        }

        public static void Configure(DbContextOptionsBuilder<ExamTextDbContext> builder, DbConnection connection)
        {
            builder.UseSqlServer(connection);
        }
    }
}
