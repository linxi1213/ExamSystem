using ExamSystem.WebApi.Common_Interface;
using System;
using System.Collections.Generic;
using System.Text;

namespace ExamSystem.WebApi.entities.Roles
{
    public class RoleRule : IResult
    {
        public string id;
        public string name;
        public string displayName;
        public string normalizedName;
        public string description;
        public string[] grantedPermissions;
    }
}
