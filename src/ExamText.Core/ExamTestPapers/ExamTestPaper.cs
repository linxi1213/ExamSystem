using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Abp.Domain.Entities;
using ExamText.ExamCompletions;
using ExamText.ExamShortAnswerQuestions;
using ExamText.ExamChoiceQuestions;

namespace ExamText.ExamTestPapers
{
    [Table("ExamTestPapers")]
    public class ExamTestPaper : Entity
    {
        [StringLength(60)]
        public string ExamTestPaperName { get; set; }

        public string ExamQuestionIDs { get; set; }
        
        public string ExamCompletionIDs { get; set; }

        public string ExamShortAnswerQuestionIDs { get; set; }

        public bool isActive { get; set; }

        public int branch { get; set; }

        public ICollection<ExamCompletion> ExamCompletions { get; set; }

        public ICollection<ExamChoiceQuestion> ExamQuestions { get; set; }

        public ICollection<ExamShortAnswerQuestion> ExamShortAnswerQuestions { get; set; }


    }
}
