using Abp.Application.Services;
using System;
using System.Collections.Generic;
using System.Text;
using ExamText.ExamShortAnswerQuestions.Dto;

namespace ExamText.ExamShortAnswerQuestions
{
    public interface IExamSAQuestionAppService : IAsyncCrudAppService<ExamShortAnswerQuestionDto,int,PageExamSAQuestionResultRequestDto,CreateExamShortAnsweQuestionDto,ExamShortAnswerQuestionDto>
    {

    }
}
