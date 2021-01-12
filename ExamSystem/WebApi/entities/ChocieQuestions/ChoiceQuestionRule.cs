using ExamSystem.WebApi.Common_Interface;
using System;
using System.Collections.Generic;
using System.Text;

namespace ExamSystem.WebApi.entities.ChocieQuestions
{
    public class ChoiceQuestionRule : IResult
    {

        public string Question { get; set; }

        public string TrueAnswer { get; set; }

        public string OrtherAnswerOne { get; set; }

        public string OrtherAnswerTwo { get; set; }

        public string OrtherAnswerThree { get; set; }

        public int branch { get; set; }
           
    }
}
