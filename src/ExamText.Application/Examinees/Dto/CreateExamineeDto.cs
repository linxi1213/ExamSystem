using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Drawing;
using System.Text;
using Abp.Application.Services.Dto;
using Abp.AutoMapper;
using ExamText.Authorization.Users;
using static ExamText.Examinees.Examinee;

namespace ExamText.Examinees.Dto
{
    //[AutoMapTo(typeof(Examinee))]
    public class CreateExamineeDto
    {

        public DateTime CreationTime { get; set; }
        [Required]
        public String Picture { get; set; }

        public TaskState State { get; set; }
        [Required]
        public long UserID { get; set; }

    }
}
