using System;
using System.Collections.Generic;
using System.Text;
using ExamSystem.WebApi;

namespace ExamSystem.WebApi.Server
{
    public class SAQuestionServer : UserWebRequest
    {
        public SAQuestionServer(string login_Token) : base(login_Token)
        {
        }
    }
}
