using System.Collections.Generic;
using System.Threading.Tasks;
using spacex_pads.Models;

namespace spacex_pads.Services
{
    public interface ILaunchPads
    {
         Task<List<LaunchPad>> GetAllPads();
         Task<LaunchPad> GetPad(string padId);
         Task<List<LaunchPad>> GetPadsByStatus(string status);
         Task<List<LaunchPad>> GetPadsSearch(string criteria);
    }
}