using Abp.AspNetCore;
using Abp.AspNetCore.TestBase;
using Abp.Modules;
using Abp.Reflection.Extensions;
using MyProject6.EntityFrameworkCore;
using MyProject6.Web.Startup;
using Microsoft.AspNetCore.Mvc.ApplicationParts;

namespace MyProject6.Web.Tests
{
    [DependsOn(
        typeof(MyProject6WebMvcModule),
        typeof(AbpAspNetCoreTestBaseModule)
    )]
    public class MyProject6WebTestModule : AbpModule
    {
        public MyProject6WebTestModule(MyProject6EntityFrameworkModule abpProjectNameEntityFrameworkModule)
        {
            abpProjectNameEntityFrameworkModule.SkipDbContextRegistration = true;
        } 
        
        public override void PreInitialize()
        {
            Configuration.UnitOfWork.IsTransactional = false; //EF Core InMemory DB does not support transactions.
        }

        public override void Initialize()
        {
            IocManager.RegisterAssemblyByConvention(typeof(MyProject6WebTestModule).GetAssembly());
        }
        
        public override void PostInitialize()
        {
            IocManager.Resolve<ApplicationPartManager>()
                .AddApplicationPartsIfNotAddedBefore(typeof(MyProject6WebMvcModule).Assembly);
        }
    }
}