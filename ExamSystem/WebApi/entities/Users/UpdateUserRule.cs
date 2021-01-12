using ExamSystem.WebApi.Common_Interface;
using System;
using System.Collections.Generic;
using System.Text;

namespace ExamSystem.WebApi.entities
{
    public class UpdateUserRule :  IResult
    {
        public string id;
        public string userName;
        public string name;
        public string surname;
        public string emailAddress;
        public string[] roleNames;
        public string fullName;
        public string isActive;

    }
}
