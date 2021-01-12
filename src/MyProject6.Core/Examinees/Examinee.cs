using Abp.Domain.Entities;
using Abp.Domain.Entities.Auditing;
using Abp.Timing;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyProject6.Examinees
{
    [Table("Examinees")]
    public class Examinee : Entity<long>, IHasCreationTime
    {
        public DateTime CreationTime { get; set ; }

        public String PicturePath { get; set; }     //考生照片

        public TaskState State { get; set; }        

        public String UserName { get; set; }        //考生姓名

        public long UserAdmiId { get; set; }        //考生准考证号

        public long UserIdNum { get; set; }         //考生身份证号

        public int UserGrade { get; set; }         //考生考生成绩

        public Examinee()
        {
            CreationTime = Clock.Now;
            State = TaskState.Untrained;
        }

        public enum TaskState : byte
        {
            Untrained = 0,
            Trained = 1
        }
    }
}
