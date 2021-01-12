using ExamSystem.WebApi.Common_Interface;
using System;
using System.Collections.Generic;
using System.Text;

namespace ExamSystem.WebApi.entities.TestPapers
{
    public class TestPaperRule : IResult
    {
        public string examTestPaperName;

        public List<int> examQuestionIDs;

        public List<int> examCompletionIDs;

        public List<int> examShortAnswerQuestionIDs;

        public bool isActive = false;

        public TestPaperRule()
        {
            examQuestionIDs = new List<int>();
            examCompletionIDs = new List<int>();
            examShortAnswerQuestionIDs = new List<int>();
        }

    }
}
