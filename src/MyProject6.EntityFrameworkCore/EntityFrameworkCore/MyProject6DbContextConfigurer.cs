using System.Data.Common;
using Microsoft.EntityFrameworkCore;

namespace MyProject6.EntityFrameworkCore
{
    public static class MyProject6DbContextConfigurer
    {
        public static void Configure(DbContextOptionsBuilder<MyProject6DbContext> builder, string connectionString)
        {
            builder.UseSqlServer(connectionString);
        }

        public static void Configure(DbContextOptionsBuilder<MyProject6DbContext> builder, DbConnection connection)
        {
            builder.UseSqlServer(connection);
        }
    }
}
