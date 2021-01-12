using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Threading.Tasks;
using Abp.Application.Services;
using Abp.Application.Services.Dto;
using Abp.Authorization;
using Abp.Domain.Repositories;
using Abp.IdentityFramework;
using Abp.Timing;
using MyProject6.Authorization;
using MyProject6.Authorization.Users;
using Microsoft.AspNetCore.Identity;
using MyProject6.Examinees.Dto;
using MyProject6.Examinees;

namespace MyProject6.Examinees
{
    [AbpAuthorize(PermissionNames.Pages_Examinees)]
    public class ExamineeAppService : AsyncCrudAppService<Examinee,ExamineeDto,long,PagedExamineeResultRequestDto, CreateUpdateExamineeDto, ExamineeDto> ,IExamineeAppService
    {
        private readonly IRepository<Examinee,long> _examineeRepository;

        private readonly IRepository<User, long> _userRepository;

        public ExamineeAppService(IRepository<Examinee, long> examineeRepository, IRepository<User, long> userRepository)
            :base(examineeRepository)
        {
            _examineeRepository = examineeRepository;
            _userRepository = userRepository;
        }

        public  async Task<ExamineeDto> CreateUpdateAsync(CreateUpdateExamineeDto input)
        {
            CheckCreatePermission();

            var user = await _userRepository.GetAsync(input.UserIdNum);

            Byte[] b = Convert.FromBase64String(input.PicturePath);

            MemoryStream pi = new MemoryStream(b);

            Bitmap bitmap = new Bitmap(pi);

            string filename = "F:\\homework and information\\specialty\\3up\\Practical training\\MyProject6\\MyProject6\\6.0.0\\aspnet-core\\facesystem\\data\\Face\\" + user.Name + ".jpg";

            bitmap.Save(filename);

            Examinee examinee = new Examinee()
            {
                PicturePath = filename,
                UserIdNum = input.UserIdNum
            };

            await pi.DisposeAsync();

            await _examineeRepository.InsertAsync(examinee);

            return  MapToEntityDto(examinee);
        }

        public Task<int> GetExamiessCount()
        {
            throw new NotImplementedException();
        }

        public async Task<int> GetExamineesCount()
        {
            var examinees = await _examineeRepository.GetAllListAsync();
            return examinees.Count;
        }
    }
}
