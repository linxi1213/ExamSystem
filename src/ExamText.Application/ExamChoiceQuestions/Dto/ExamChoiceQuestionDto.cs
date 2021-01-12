using System.ComponentModel.DataAnnotations;
using Abp.Application.Services.Dto;
using Abp.AutoMapper;
using Abp.Domain.Entities;

namespace ExamText.ExamChoiceQuestions.Dto
{
    [AutoMap(typeof(ExamChoiceQuestion))]
    public class ExamChoiceQuestionDto : EntityDto
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
