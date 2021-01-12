using Abp.Application.Services;
using Abp.Authorization;
using Abp.Domain.Repositories;
using ExamText.Authorization;
using ExamText.ExamTestPapers.Dto;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ExamText.ExamTestPapers
{
    [AbpAuthorize(PermissionNames.Pages_Exam_Questions)]
    public class ExamTestPaperAppService : AsyncCrudAppService<ExamTestPaper,ExamTestPaperDto, int, PageExamTestPaperResultRequestDto, CreateExamTestPaperDto, UpdateTestPaperDto>, IExamTestPaperAppService
    {
        private readonly IRepository<ExamTestPaper> _examtestrepository;

        public ExamTestPaperAppService(IRepository<ExamTestPaper> examtestrepository) : base(examtestrepository)
        {
            _examtestrepository = examtestrepository;

        }

        public async override Task<ExamTestPaperDto> CreateAsync(CreateExamTestPaperDto input)
        {
            CheckCreatePermission();

            var test = ObjectMapper.Map<ExamTestPaper>(input);
            test.ExamCompletionIDs =string.Join(',',input.ExamCompletionIDs);
            test.ExamQuestionIDs =string.Join(',',input.ExamQuestionIDs);
            test.ExamShortAnswerQuestionIDs =string.Join(',',input.ExamShortAnswerQuestionIDs);

            await _examtestrepository.InsertAsync(test);

            return MapToEntityDto(test);
        }

        public async Task UpdataTestPageActive(int input)
        {
            
            CheckPermission();

            var test = _examtestrepository.Get(input);
            test.isActive = true;

           await  _examtestrepository.UpdateAsync(test);
        }

        private void CheckPermission()
        {
            bool canAssignTaskToOther = PermissionChecker.IsGranted(PermissionNames.Pages_Exam_Questions);
            if (!canAssignTaskToOther)
            { throw new AbpAuthorizationException("没有权限"); }
        }

        //public override Task<ExamTestPaperDto> UpdateAsync(UpdateTestPaperDto input)
        //{
        //    CheckUpdatePermission();


        //    return;
        //}

    }
}
