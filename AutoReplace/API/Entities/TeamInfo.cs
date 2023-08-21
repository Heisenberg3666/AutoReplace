using System.Collections.Generic;
using PlayerRoles;
using PluginAPI.Core;

namespace AutoReplace.API.Entities
{
    public class TeamInfo
    {
        public Team Team { get; set; }
        public List<Player> Players { get; set; }
    }
}