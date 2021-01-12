using Abp.Application.Services;
using Abp.Application.Services.Dto;
using MyProject6.Examinees.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyProject6.Examinees
{
    public interface IExamineeAppService : IAsyncCrudAppService< ExamineeDto, long, PagedExamineeResultRequestDto, CreateUpdateExamineeDto, ExamineeDto>
    {
       Task<ExamineeDto> CreateUpdateAsync(CreateUpdateExamineeDto input);

        //Task<ListResultDto<ExamineeDto> GetExaminees();

        Task<int> GetExamineesCount();
    }
}
