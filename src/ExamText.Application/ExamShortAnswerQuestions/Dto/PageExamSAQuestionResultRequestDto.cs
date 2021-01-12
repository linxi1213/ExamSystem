using Abp.Application.Services.Dto;
using System;
using System.Collections.Generic;
using System.Text;

namespace ExamText.ExamShortAnswerQuestions.Dto
{
    public class PageExamSAQuestionResultRequestDto: PagedResultRequestDto
    {
        public string Keyword { get; set; }
    }
}
