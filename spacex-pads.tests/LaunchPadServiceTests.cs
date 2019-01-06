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
        private readonly AppSettings _appSettings = new AppSettings();
        [Fact]
        public void Should_get_all_launchpads()
        {
            IOptions<AppSettings> options = Options.Create(_appSettings);
            var lpService = new LaunchPads(options);
            Assert.NotNull(lpService.GetAllPads());
        }

        [Fact]
        public void Should_get_a_single_launchpad()
        {
            IOptions<AppSettings> options = Options.Create(_appSettings);
            var lpService = new LaunchPads(options);
            Assert.NotNull(lpService.GetPad("kwajalein_atoll"));
        }        

        [Theory]
        [InlineData("active")]
        [InlineData("retired")]
        public void Should_get_launchpads_by_status(string value)
        {
            IOptions<AppSettings> options = Options.Create(_appSettings);
            var lpService = new LaunchPads(options);
            Assert.NotNull(lpService.GetPadsByStatus(value));
        } 

        [Theory]
        [InlineData("Space")]
        [InlineData("Force")]
        public void Should_get_launchpads_by_search_criteria(string value)
        {
            IOptions<AppSettings> options = Options.Create(_appSettings);
            var lpService = new LaunchPads(options);
            Assert.NotNull(lpService.GetPadsSearch(value));
        }         
    }
}
