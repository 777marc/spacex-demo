using System;
using Xunit;
using spacex_pads.Services;
using spacex_pads.Config;
using spacex_pads.Controllers;
using Microsoft.Extensions.Options;
using Newtonsoft.Json.Linq;
using Microsoft.Extensions.Logging;
using Moq;

namespace spacex_pads.tests
{
    public class LaunchPadControllerTest
    {
        private readonly AppSettings _appSettings = new AppSettings();
        

        [Fact]
        public void Should_get_all_launchpads()
        {
            IOptions<AppSettings> options = Options.Create(_appSettings);
            var lpService = new LaunchPads(options);
            var logger = Mock.Of<ILogger<LaunchPadsController>>();
            var lpController = new LaunchPadsController(lpService, logger);
            Assert.NotNull(lpController.GetAllPads());
        }

        [Theory]
        [InlineData("kwajalein_atoll")]
        [InlineData("ccafs_slc_40")]
        [InlineData("ksc_lc_39a")]
        public void Should_get_a_launchpad_by_controller(string value)
        {
            IOptions<AppSettings> options = Options.Create(_appSettings);
            var lpService = new LaunchPads(options);
            var logger = Mock.Of<ILogger<LaunchPadsController>>();
            var lpController = new LaunchPadsController(lpService, logger);
            Assert.NotNull(lpController.Get(value));
        }        

        [Theory]
        [InlineData("active")]
        [InlineData("retired")]
        public void Should_get_launchpads_by_status_by_controller(string value)
        {
            IOptions<AppSettings> options = Options.Create(_appSettings);
            var lpService = new LaunchPads(options);
            var logger = Mock.Of<ILogger<LaunchPadsController>>();
            var lpController = new LaunchPadsController(lpService, logger);
            Assert.NotNull(lpController.GetByStatus(value));
        } 
    }
}
