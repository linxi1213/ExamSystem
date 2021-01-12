using ExamSystem.WebApi.Common_Interface;
using System;
using System.Collections.Generic;
using System.Text;

namespace ExamSystem.WebApi.entities.Examinees
{
    public class ExamineeRule : IResult
    {
        public string userID { get; set; }
        public string picture { get; set; }
    }
}
