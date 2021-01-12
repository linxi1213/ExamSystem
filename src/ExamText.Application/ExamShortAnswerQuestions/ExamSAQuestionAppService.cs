using Abp.Application.Services;
using Abp.Authorization;
using Abp.Domain.Repositories;
using ExamText.Authorization;
using ExamText.ExamShortAnswerQuestions.Dto;
using System;
using System.Collections.Generic;
using System.Text;

namespace ExamText.ExamShortAnswerQuestions
{
    [AbpAuthorize(PermissionNames.Pages_Exam_Questions)]
    public class ExamSAQuestionAppService : AsyncCrudAppService<ExamShortAnswerQuestion, ExamShortAnswerQuestionDto, int, PageExamSAQuestionResultRequestDto, CreateExamShortAnsweQuestionDto, ExamShortAnswerQuestionDto>,IExamSAQuestionAppService
    {
        private readonly IRepository<ExamShortAnswerQuestion> _examquestionRepository;

        public ExamSAQuestionAppService(IRepository<ExamShortAnswerQuestion> examquestionRepository) : base(examquestionRepository)
        {
             _examquestionRepository = examquestionRepository;
        }
    }
  
}
