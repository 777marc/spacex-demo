using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.Extensions.Options;
using Newtonsoft.Json.Linq;
using spacex_pads.Config;
using spacex_pads.Models;

namespace spacex_pads.Services
{
    public class LaunchPads : ILaunchPads
    {
        static HttpClient _client = new HttpClient();

        private readonly string _baseUrl;

        public LaunchPads(IOptions<AppSettings> settings)
        {
            _baseUrl = settings.Value.LaunchPadServiceAPIBaseURL;
        }

        public async Task<List<LaunchPad>> GetAllPads()
        {
            var padList = new List<LaunchPad>();
            HttpResponseMessage response = await _client.GetAsync(_baseUrl);
            var pads = await response.Content.ReadAsStringAsync();
            JArray launchPads = JArray.Parse(pads);

            var launchPadArray = from lp in launchPads
                                 select new LaunchPad {
                                     Id = (string)lp["id"],
                                     Name = (string)lp["full_name"],
                                     Status = (string)lp["status"],
                                 };   

            return launchPadArray.ToList();
        }

        public async Task<LaunchPad> GetPad(string padId)
        {

            HttpResponseMessage response = await _client.GetAsync(_baseUrl + "/" + padId);
            var pad = await response.Content.ReadAsStringAsync();
            JObject singlePad = JObject.Parse(pad);

            var launchPad = new LaunchPad {
                                Id = (string)singlePad["id"],
                                Name = (string)singlePad["full_name"],
                                Status = (string)singlePad["status"],
                            };   

            return launchPad;
        }

        public async Task<List<LaunchPad>> GetPadsByStatus(string status)
        {
            var padList = new List<LaunchPad>();
            HttpResponseMessage response = await _client.GetAsync(_baseUrl);
            var pads = await response.Content.ReadAsStringAsync();
            JArray launchPads = JArray.Parse(pads);

            var launchPadArray = from lp in launchPads
                                 where (string)lp["status"] == status
                                 select new LaunchPad {
                                     Id = (string)lp["id"],
                                     Name = (string)lp["full_name"],
                                     Status = (string)lp["status"],
                                 };   

            return launchPadArray.ToList();
        }

    }
}