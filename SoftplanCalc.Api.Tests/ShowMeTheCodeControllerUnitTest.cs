using System.IO;
using Microsoft.AspNetCore.Mvc;
using SoftplanCalc.Api.Controllers;
using Xunit;

namespace SoftplanCalc.Api.Tests
{
    /// <summary>
    /// Show me the code controller unit test.
    /// </summary>
    public class ShowMeTheCodeControllerUnitTest
    {
        /// <summary>
        /// The show me the code controller.
        /// </summary>
        private readonly ShowMeTheCodeController _showMeTheCodeController;

        /// <summary>
        /// Initializes a new instance of the <see cref="T:SoftplanCalc.Api.Tests.ShowMeTheCodeControllerUnitTest"/> class.
        /// </summary>
        public ShowMeTheCodeControllerUnitTest()
        {
            var configuration = TestHelper.GetIConfiguration(Directory.GetCurrentDirectory());

            _showMeTheCodeController = new ShowMeTheCodeController(configuration);
        }

        [Fact]
        public void ShouldReturnGithubRepository()
        {
            var actual = Assert.IsType<OkObjectResult>(_showMeTheCodeController.Get());
            var expected = "https://github.com/gabrielschmith/SoftplanCalc";

            Assert.Equal(expected, actual.Value);
        }
    }
}
