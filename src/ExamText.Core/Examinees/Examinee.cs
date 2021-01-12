using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Abp.Domain.Entities;
using Abp.Domain.Entities.Auditing;
using Abp.Timing;
using ExamText.Authorization.Users;

namespace ExamText.Examinees
{
    [Table("Examinees")]
     public class Examinee :Entity<long>, IHasCreationTime
    {


        public DateTime CreationTime { get; set; }

        public String PicturePath { get; set; }

        public TaskState State { get; set; }

        [ForeignKey(nameof(UserID))]
        public User user { get; set; }
        [Required]
        public long UserID { get; set; }

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
