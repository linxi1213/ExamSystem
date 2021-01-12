using ExamSystem.WebApi.entities.TestPapers;
using System;
using System.Collections.Generic;
using System.Text;

namespace ExamSystem.Pages.ExamPage
{
    public class QuestionBank
    {
        public static TestPaperRule testPaperRule;

         public static bool JudgeIsNull_TestRule()
        {
             if(testPaperRule.examCompletionIDs.Count==0
                &&testPaperRule.examQuestionIDs.Count==0
                &&testPaperRule.examShortAnswerQuestionIDs.Count==0)
            {
                return false;
            }
             else
            {
                return true;
            }    
        
         }


    }


 
}
