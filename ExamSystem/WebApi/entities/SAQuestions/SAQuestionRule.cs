using ExamSystem.WebApi.Common_Interface;
using System;
using System.Collections.Generic;
using System.Text;

namespace ExamSystem.WebApi.entities.SAQuestions
{
    public class SAQuestionRule :IResult
    {
        public string Question { get; set; }

        public string Answer { get; set; }

        public int branch { get; set; }
    }
}
