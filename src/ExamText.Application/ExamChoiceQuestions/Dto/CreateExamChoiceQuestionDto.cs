using Abp.AutoMapper;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace ExamText.ExamChoiceQuestions.Dto
{
    [AutoMapTo(typeof(ExamChoiceQuestion))]
    public class CreateExamChoiceQuestionDto
    {
        [Required]
        public string Question { get; set; }

        [Required]
        public string TrueAnswer { get; set; }

        [Required]
        public string OrtherAnswerOne { get; set; }

        [Required]
        public string OrtherAnswerTwo { get; set; }

        [Required]
        public string OrtherAnswerThree { get; set; }

        public int branch { get; set; }

    }
}
