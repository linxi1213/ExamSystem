using Abp.Application.Services.Dto;
using Abp.AutoMapper;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace ExamText.ExamTestPapers.Dto
{
    [AutoMap(typeof(ExamTestPaper))]
    public class ExamTestPaperDto :EntityDto
    {
        [StringLength(60)]
        public string ExamTestPaperName { get; set; }

        public string ExamQuestionIDs { get; set; }

        public string ExamCompletionIDs { get; set; }

        public string ExamShortAnswerQuestionIDs { get; set; }

        public int branch { get; set; }

        public bool isActive { get; set; }
    }
}
