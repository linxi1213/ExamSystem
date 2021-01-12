using ExamSystem.WebApi.Common_Interface;
using System;
using System.Collections.Generic;
using System.Text;

namespace ExamSystem.WebApi.entities
{
    public class entity<T> : IResult
    {
        public T id;
    }
}
