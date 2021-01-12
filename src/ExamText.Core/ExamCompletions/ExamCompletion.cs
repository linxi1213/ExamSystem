using Abp.Domain.Entities;
using ExamText.ExamTestPapers;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace ExamText.ExamCompletions
{
    [Table("ExamCompletions")]
    public class ExamCompletion : Entity
    {

        [Required]
        public string Question { get; set; }


        [Required]
        public string Answer { get; set; }

        public int branch { get; set; }

        public ICollection<ExamTestPaper> ExamTestPapers;
    }
}
