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
using ExamText.Authorization;
using ExamText.Authorization.Users;
using ExamText.Examinees.Dto;
using Microsoft.AspNetCore.Identity;

namespace ExamText.Examinees
{
    [AbpAuthorize(PermissionNames.Pages_Examinees)]
    public class ExamineeAppService : AsyncCrudAppService<Examinee,ExamineeDto,long,PagedExamineeResultRequestDto,CreateExamineeDto,UpdateExamineePictureDto> ,IExamineeAppService
    {
        private readonly IRepository<Examinee,long> _examineeRepository;

        private readonly IRepository<User, long> _userRepository;

        public ExamineeAppService(IRepository<Examinee,long> examineeRepository, IRepository<User, long> userRepository) 
            :base(examineeRepository)
        {
            _examineeRepository = examineeRepository;
            _userRepository = userRepository;
        }

        /// <summary>
        /// Create先保存图片到本地，在保存图片地址到数据库
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public override async Task<ExamineeDto> CreateAsync(CreateExamineeDto input)
        {
            CheckCreatePermission();

            var user = await _userRepository.GetAsync(input.UserID);

            Byte[] b = Convert.FromBase64String(input.Picture);

            MemoryStream pi = new MemoryStream(b);

            Bitmap bitmap = new Bitmap(pi);

            string filename = "D:\\Windink Pro\\5.8.1\\aspnet-core\\facesystem\\data\\Face\\" + user.Name + ".jpg";

            bitmap.Save(filename);

            Examinee examinee = new Examinee()
            {
                PicturePath = filename,
                UserID = input.UserID
            };

            //user.examinee = examinee;
            //var examinee = ObjectMapper.Map<Examinee>(input);
            await pi.DisposeAsync();

            await _examineeRepository.InsertAsync(examinee);

            return  MapToEntityDto(examinee);
        }

        ///// <summary>
        ///// 只可以get得到自己
        ///// </summary>
        ///// <returns></returns>
        ///// 
        //public override async Task<ExamineeDto> GetAsync(EntityDto<long> input)
        //{
        //    CheckGetPermission();
        //    return await GetAsync(input);
        //}

        ///// <summary>
        ///// 不需要删除权限
        ///// </summary>
        ///// <param name="input"></param>
        ///// <returns></returns>
        //public override Task DeleteAsync(EntityDto<long> input)
        //{
        //    CheckCreatePermission();
        //    return null;
        //}

        ///// <summary>
        ///// 不需要getAll权限
        ///// </summary>
        ///// <param name="identityResult"></param>
        //public override Task<PagedResultDto<ExamineeDto>> GetAllAsync(PagedExamineeResultRequestDto input)
        //{
        //    CheckGetAllPermission();
        //    return null;
        //}

        ///// <summary>
        ///// 只可以改变自己的Picture
        ///// </summary>
        ///// <param name="input"></param>
        ///// <returns></returns>
        //public override async Task<ExamineeDto> UpdateAsync(UpdateExamineePictureDto input)
        //{

        //    CheckUpdatePermission();
        //    var examinee = _examineeRepository.Get(input.Id);

        //    var user = _userRepository.Get(input.Id);

        //    Bitmap bitmap = input.Picture;

        //    string filename = "D:\\Windink Pro\\5.8.1\\aspnet-core\\facesystem\\data\\Face\\" + user.Name + ".jpg";

        //    bitmap.Save(filename);

        //    return await UpdateAsync(input);
        //}

        public async Task<int> GetExamineesCount()
        {
            var examinees = await _examineeRepository.GetAllListAsync();
            return examinees.Count;
        }

        //public void UpdataExamineesPicture(UpdateExamineePictureDto input)
        //{
        //    CheckUpdatePermission();
        //    var examinee = _examineeRepository.Get(input.Id);

        //    Bitmap bitmap = input.Picture;

        //    string filename = "D:\\Windink Pro\\5.8.1\\aspnet-core\\facesystem\\data\\Face\\" + examinee.Name + ".jpg";

        //    bitmap.Save(filename);

        //}

    }
}
