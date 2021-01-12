using Abp.Application.Services;
using Abp.Application.Services.Dto;
using MyProject6.TDocs.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyProject6.TDocs
{
    public interface ITDocAppService : IApplicationService
    {
        public string SayHello();


        Task<ListResultDto<TDocDto>> GetDocs(GetTDocsInfo info);

    }
}
