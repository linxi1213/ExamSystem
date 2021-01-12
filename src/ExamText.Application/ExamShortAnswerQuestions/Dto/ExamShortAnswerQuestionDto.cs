using Abp.Application.Services.Dto;
using Abp.AutoMapper;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace ExamText.ExamShortAnswerQuestions.Dto
{
    [AutoMap(typeof(ExamShortAnswerQuestion))]
    public class ExamShortAnswerQuestionDto : EntityDto
    {
        [Required]
        public string Question { get; set; }

        [Required]
        public string Answer { get; set; }

        public int branch { get; set; }

    }
}
