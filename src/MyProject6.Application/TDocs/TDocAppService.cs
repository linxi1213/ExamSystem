using Abp.Application.Services.Dto;
using Abp.Domain.Repositories;
using MyProject6.TDocs.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyProject6.TDocs
{


    public class TDocAppService: MyProject6AppServiceBase, ITDocAppService
    {
        private readonly IRepository<TestDocument> _TDocsRepository;

        public TDocAppService(IRepository<TestDocument> TDocsRepository)
        {
            _TDocsRepository = TDocsRepository;
        }
        public string SayHello()
        {
            return "hello world";
        }

        public async Task<ListResultDto<TDocDto>> GetDocs(GetTDocsInfo info)
        {
            var TDocs = await _TDocsRepository
                .GetAllListAsync();

            return new ListResultDto<TDocDto>(
                ObjectMapper.Map<List<TDocDto>>(TDocs)
                );


        }
    }
}
