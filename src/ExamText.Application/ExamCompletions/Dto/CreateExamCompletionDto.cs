using Abp.AutoMapper;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace ExamText.ExamCompletions.Dto
{
    [AutoMapTo(typeof(ExamCompletion))]
    public class CreateExamCompletionDto
    {
        [Required]
        public string Question { get; set; }


        [Required]
        public string Answer { get; set; }

        public int branch { get; set; }
    }
}
