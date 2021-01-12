using System;
using System.Collections.Generic;
using System.Text;
using Abp.Application.Services.Dto;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Abp.AutoMapper;

namespace ExamText.ExamCompletions.Dto
{
    [AutoMap(typeof(ExamCompletion))]
    public class ExamCompletionDto : EntityDto
    {
        [Required]
        public string Question { get; set; }


        [Required]
        public string Answer { get; set; }

        public int branch { get; set; }
    }
}
