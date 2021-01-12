using System.Threading.Tasks;
using MyProject6.Models.TokenAuth;
using MyProject6.Web.Controllers;
using Shouldly;
using Xunit;

namespace MyProject6.Web.Tests.Controllers
{
    public class HomeController_Tests: MyProject6WebTestBase
    {
        [Fact]
        public async Task Index_Test()
        {
            await AuthenticateAsync(null, new AuthenticateModel
            {
                UserNameOrEmailAddress = "admin",
                Password = "123qwe"
            });

            //Act
            var response = await GetResponseAsStringAsync(
                GetUrl<HomeController>(nameof(HomeController.Index))
            );

            //Assert
            response.ShouldNotBeNullOrEmpty();
        }
    }
}