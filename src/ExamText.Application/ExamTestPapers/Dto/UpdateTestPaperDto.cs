using Abp.Application.Services.Dto;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace ExamText.ExamTestPapers.Dto
{
    
    public class UpdateTestPaperDto : EntityDto
    {
        [StringLength(60)]
        public string ExamTestPaperName { get; set; }

        public int[] ExamQuestionIDs { get; set; }

        public int[] ExamCompletionIDs { get; set; }

        public int[] ExamShortAnswerQuestionIDs { get; set; }

        public int branch { get; set; }

        public bool isActive { get; set; }
    }
}
