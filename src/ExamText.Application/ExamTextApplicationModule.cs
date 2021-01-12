using Abp.AutoMapper;
using Abp.Modules;
using Abp.Reflection.Extensions;
using ExamText.Authorization;

namespace ExamText
{
    [DependsOn(
        typeof(ExamTextCoreModule), 
        typeof(AbpAutoMapperModule))]
    public class ExamTextApplicationModule : AbpModule
    {
        public override void PreInitialize()
        {
            Configuration.Authorization.Providers.Add<ExamTextAuthorizationProvider>();

        }

        public override void Initialize()
        {
            var thisAssembly = typeof(ExamTextApplicationModule).GetAssembly();

            IocManager.RegisterAssemblyByConvention(thisAssembly);

            Configuration.Modules.AbpAutoMapper().Configurators.Add(
                // Scan the assembly for classes which inherit from AutoMapper.Profile
                cfg => cfg.AddMaps(thisAssembly)
            );
        }
    }
}
