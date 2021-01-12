﻿using System.Threading.Tasks;
using ExamText.Models.TokenAuth;
using ExamText.Web.Controllers;
using Shouldly;
using Xunit;

namespace ExamText.Web.Tests.Controllers
{
    public class HomeController_Tests: ExamTextWebTestBase
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