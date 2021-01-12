using System;
using System.Collections.Generic;
using System.Text;

namespace ExamSystem.WebApi.Server
{
    public class ExamineeServer : UserWebRequest
    {
        public ExamineeServer(string login_Token) : base(login_Token)
        {

        }
    }
}
