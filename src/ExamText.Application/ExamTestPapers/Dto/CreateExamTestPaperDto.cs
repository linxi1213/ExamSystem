using Abp.AutoMapper;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace ExamText.ExamTestPapers.Dto
{
    [AutoMapTo(typeof(ExamTestPaper))]
    public class CreateExamTestPaperDto
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
