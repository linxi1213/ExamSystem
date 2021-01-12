using Abp.AutoMapper;
using Abp.Modules;
using Abp.Reflection.Extensions;
using MyProject6.Authorization;

namespace MyProject6
{
    [DependsOn(
        typeof(MyProject6CoreModule), 
        typeof(AbpAutoMapperModule))]
    public class MyProject6ApplicationModule : AbpModule
    {
        public override void PreInitialize()
        {
            Configuration.Authorization.Providers.Add<MyProject6AuthorizationProvider>();
        }

        public override void Initialize()
        {
            var thisAssembly = typeof(MyProject6ApplicationModule).GetAssembly();

            IocManager.RegisterAssemblyByConvention(thisAssembly);

            Configuration.Modules.AbpAutoMapper().Configurators.Add(
                // Scan the assembly for classes which inherit from AutoMapper.Profile
                cfg => cfg.AddMaps(thisAssembly)
            );
        }
    }
}
