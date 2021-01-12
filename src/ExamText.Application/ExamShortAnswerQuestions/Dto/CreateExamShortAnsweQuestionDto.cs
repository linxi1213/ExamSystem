using Abp.AutoMapper;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace ExamText.ExamShortAnswerQuestions.Dto
{
    [AutoMapTo(typeof(ExamShortAnswerQuestion))]
    public class CreateExamShortAnsweQuestionDto
    {
        [Required]
        public string Question { get; set; }

        [Required]
        public string Answer { get; set; }
        public int branch { get; set; }
    }
}
