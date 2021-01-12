using Microsoft.EntityFrameworkCore;
using Abp.Zero.EntityFrameworkCore;
using MyProject6.Authorization.Roles;
using MyProject6.Authorization.Users;
using MyProject6.MultiTenancy;
using MyProject6.Examinees;

namespace MyProject6.EntityFrameworkCore
{
    public class MyProject6DbContext : AbpZeroDbContext<Tenant, Role, User, MyProject6DbContext>
    {
        /* Define a DbSet for each entity of the application */

        public DbSet<TestDocument> TDocs { get; set; }

        public DbSet<Examinee> Examinees { get; set; }

        public MyProject6DbContext(DbContextOptions<MyProject6DbContext> options)
            : base(options)
        {
        }
    }
}
