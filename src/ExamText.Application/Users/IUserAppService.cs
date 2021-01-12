using System.Threading.Tasks;
using Abp.Application.Services;
using Abp.Application.Services.Dto;
using ExamText.Roles.Dto;
using ExamText.Users.Dto;

namespace ExamText.Users
{
    public interface IUserAppService : IAsyncCrudAppService<UserDto, long, PagedUserResultRequestDto, CreateUserDto, UserDto>
    {
        Task<ListResultDto<RoleDto>> GetRoles();

        Task ChangeLanguage(ChangeUserLanguageDto input);

        Task<bool> ChangePassword(ChangePasswordDto input);

        Task<UserDto> CreateExaminee(CreateExaimeeDto input);
    }
}
