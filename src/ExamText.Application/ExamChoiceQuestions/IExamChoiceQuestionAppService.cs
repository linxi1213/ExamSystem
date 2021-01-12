using Abp.Application.Services;
using ExamText.ExamChoiceQuestions.Dto;

namespace ExamText.ExamChoiceQuestions
{
    public interface IExamChoiceQuestionAppService : IAsyncCrudAppService<ExamChoiceQuestionDto,int,PageExamChoiceQuestionsResultRequestDto,CreateExamChoiceQuestionDto,ExamChoiceQuestionDto>
    {

    }
}
