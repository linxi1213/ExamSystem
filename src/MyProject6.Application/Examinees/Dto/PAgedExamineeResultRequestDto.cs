using System;
using System.Collections.Generic;
using System.Text;
using Abp.Application.Services.Dto;

namespace MyProject6.Examinees.Dto
{
    public class PagedExamineeResultRequestDto : PagedResultRequestDto
    {
        public string Keyword { get; set; }
    }
}
