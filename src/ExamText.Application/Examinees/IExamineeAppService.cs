using System.Threading.Tasks;
using Abp.Application.Services;
using Abp.Application.Services.Dto;
using ExamText.Examinees.Dto;

namespace ExamText.Examinees
{
    public interface IExamineeAppService : IAsyncCrudAppService<ExamineeDto, long, PagedExamineeResultRequestDto,CreateExamineeDto,UpdateExamineePictureDto>
    {
        //Task<ListResultDto<ExamineeDto>> GetExaminees();

        Task<int> GetExamineesCount();

     //   void UpdataExamineesPicture(UpdateExamineePictureDto input);


    }
}
