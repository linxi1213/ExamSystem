using Abp.Application.Services.Dto;
using Abp.AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MyProject6.TDocs;

namespace MyProject6.TDocs.Dto
{

    public class GetTDocsInfo
    {
        public int flag;
    }


    [AutoMapFrom(typeof(TestDocument))]
    public class TDocDto : EntityDto<long>

    {
        public DateTime CreationTime { get; set; }

        public string TestDocumentID { get; set; }
        public string Version { get; set; }
        public string Content { get; set; }
    }
}
