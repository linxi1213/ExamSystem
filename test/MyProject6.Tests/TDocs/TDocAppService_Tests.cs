using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Shouldly;
using Xunit;
using Abp.Application.Services.Dto;
using MyProject6.TDocs;
using MyProject6.TDocs.Dto;

namespace MyProject6.Tests.TDocs
{
    public class TDocAppService_Tests : MyProject6TestBase
    {
        private readonly ITDocAppService _TDocAppService;

        public TDocAppService_Tests()
        {
            _TDocAppService = Resolve<ITDocAppService>();
        }

        [Fact]
        public async Task GetTDocs_Test()
        {
            // Act
            var output = await _TDocAppService.GetDocs(new GetTDocsInfo {  flag = 1 });

            // Assert
            output.Items.Count.ShouldBe(0);
        }

        /*
        [Fact]
        public async Task CreateTDocs_Test()
        {
            // Act
            await _userAppService.CreateAsync(
                new CreateUserDto
                {
                    EmailAddress = "john@volosoft.com",
                    IsActive = true,
                    Name = "John",
                    Surname = "Nash",
                    Password = "123qwe",
                    UserName = "john.nash"
                });

            await UsingDbContextAsync(async context =>
            {
                var johnNashUser = await context.Users.FirstOrDefaultAsync(u => u.UserName == "john.nash");
                johnNashUser.ShouldNotBeNull();
            });
        }*/
    }
}
