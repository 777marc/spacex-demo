using System;
using Xunit;
using spacex_pads.Services;
using spacex_pads.Config;
using Microsoft.Extensions.Options;
using Newtonsoft.Json.Linq;

namespace spacex_pads.tests
{
    public class LaunchPadServiceTests
    {
        [Fact]
        public void Should_get_all_launchpads()
        {
            // Mock AppSettings
            AppSettings appSettings = new AppSettings();
            IOptions<AppSettings> options = Options.Create(appSettings);
            var lpService = new LaunchPads(options);
            Assert.NotNull(lpService.GetAllPads());
        }

        [Fact]
        public void Should_get_a_single_launchpad()
        {
            // Mock AppSettings
            AppSettings appSettings = new AppSettings();
            IOptions<AppSettings> options = Options.Create(appSettings);
            var lpService = new LaunchPads(options);
            Assert.NotNull(lpService.GetPad("kwajalein_atoll"));
        }        

        [Theory]
        [InlineData("active")]
        [InlineData("retired")]
        public void Should_get_launchpads_by_status(string value)
        {
            // Mock AppSettings
            AppSettings appSettings = new AppSettings();
            IOptions<AppSettings> options = Options.Create(appSettings);
            var lpService = new LaunchPads(options);
            Assert.NotNull(lpService.GetPadsByStatus(value));
        } 
    }
}
