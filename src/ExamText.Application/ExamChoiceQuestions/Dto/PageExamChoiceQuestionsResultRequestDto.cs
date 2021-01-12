using Abp.Application.Services.Dto;
using System;
using System.Collections.Generic;
using System.Text;

namespace ExamText.ExamChoiceQuestions.Dto
{
    public class PageExamChoiceQuestionsResultRequestDto : PagedResultRequestDto
    {
        public string Keyword { get; set; }
    }
}
