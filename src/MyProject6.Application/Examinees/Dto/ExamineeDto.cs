using Abp.Application.Services.Dto;
using Abp.AutoMapper;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static MyProject6.Examinees.Examinee;

namespace MyProject6.Examinees.Dto
{
    [AutoMap(typeof(Examinee))]
    public class ExamineeDto : EntityDto<long>
    {
        public DateTime CreationTime { get; set; }

        [Required]
        public String PicturePath { get; set; }     //考生照片

        public TaskState State { get; set; }

        [Required]
        public String UserName { get; set; }        //考生姓名

        [Required]
        public long UserAdmiId { get; set; }        //考生准考证号

        [Required]
        public long UserIdNum { get; set; }         //考生身份证号

        [Required]
        public int UserGrade { get; set; }
    }
}
