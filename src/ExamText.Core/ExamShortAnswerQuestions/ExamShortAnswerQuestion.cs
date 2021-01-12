
using System.Text;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Abp.Domain.Entities;
using ExamText.ExamTestPapers;
using System.Collections.Generic;

namespace ExamText.ExamShortAnswerQuestions
{
    [Table("ExamShortAnswerQuestion")]
    public class ExamShortAnswerQuestion : Entity
    {
        [Required]
        public string Question { get; set; }

        [Required]
        public string Answer { get; set; }

        public int branch { get; set; }

        public ICollection<ExamTestPaper> ExamTestPapers;
    }
}
