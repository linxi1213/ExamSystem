using Abp.Application.Services;
using ExamText.ExamCompletions.Dto;
using System;
using System.Collections.Generic;
using System.Text;

namespace ExamText.ExamCompletions
{
     public interface IExamCompletionAppService : IAsyncCrudAppService<ExamCompletionDto, int,PageExamCompletionRequestDto,CreateExamCompletionDto, ExamCompletionDto>
    {

    }
}
