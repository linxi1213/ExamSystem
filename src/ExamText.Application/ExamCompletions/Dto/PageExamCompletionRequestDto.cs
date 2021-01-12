using Abp.Application.Services.Dto;
using System;
using System.Collections.Generic;
using System.Text;

namespace ExamText.ExamCompletions.Dto
{
    public class PageExamCompletionRequestDto : PagedResultRequestDto
    {
        public string Keyword { get; set; }
    }
}
