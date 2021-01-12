using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Abp.Domain.Entities;
using Abp.Domain.Entities.Auditing;
using Abp.Timing;

namespace MyProject6
{
    public class TestDocument : Entity, IHasCreationTime
    {
        public TestDocument()
        {
            CreationTime = Clock.Now;
        }

        public DateTime CreationTime { get; set; }

        public string TestDocumentID { get; set; }
        public string Version { get; set; }
        public string Content { get; set; }

    }
}
