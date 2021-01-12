using Abp.AspNetCore;
using Abp.AspNetCore.TestBase;
using Abp.Modules;
using Abp.Reflection.Extensions;
using ExamText.EntityFrameworkCore;
using ExamText.Web.Startup;
using Microsoft.AspNetCore.Mvc.ApplicationParts;

namespace ExamText.Web.Tests
{
    [DependsOn(
        typeof(ExamTextWebMvcModule),
        typeof(AbpAspNetCoreTestBaseModule)
    )]
    public class ExamTextWebTestModule : AbpModule
    {
        public ExamTextWebTestModule(ExamTextEntityFrameworkModule abpProjectNameEntityFrameworkModule)
        {
            abpProjectNameEntityFrameworkModule.SkipDbContextRegistration = true;
        } 
        
        public override void PreInitialize()
        {
            Configuration.UnitOfWork.IsTransactional = false; //EF Core InMemory DB does not support transactions.
        }

        public override void Initialize()
        {
            IocManager.RegisterAssemblyByConvention(typeof(ExamTextWebTestModule).GetAssembly());
        }
        
        public override void PostInitialize()
        {
            IocManager.Resolve<ApplicationPartManager>()
                .AddApplicationPartsIfNotAddedBefore(typeof(ExamTextWebMvcModule).Assembly);
        }
    }
}