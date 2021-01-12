using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Abp.Modules;
using Abp.Reflection.Extensions;
using ExamText.Configuration;

namespace ExamText.Web.Host.Startup
{
    [DependsOn(
       typeof(ExamTextWebCoreModule))]
    public class ExamTextWebHostModule: AbpModule
    {
        private readonly IWebHostEnvironment _env;
        private readonly IConfigurationRoot _appConfiguration;

        public ExamTextWebHostModule(IWebHostEnvironment env)
        {
            _env = env;
            _appConfiguration = env.GetAppConfiguration();
        }

        public override void Initialize()
        {
            IocManager.RegisterAssemblyByConvention(typeof(ExamTextWebHostModule).GetAssembly());
        }
    }
}
