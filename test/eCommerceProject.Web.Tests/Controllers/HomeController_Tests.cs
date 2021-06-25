using System.Threading.Tasks;
using eCommerceProject.Models.TokenAuth;
using eCommerceProject.Web.Controllers;
using Shouldly;
using Xunit;

namespace eCommerceProject.Web.Tests.Controllers
{
    public class HomeController_Tests: eCommerceProjectWebTestBase
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