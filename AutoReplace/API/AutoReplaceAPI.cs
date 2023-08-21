using System.Collections.Generic;
using System.Linq;
using AutoReplace.API.Entities;
using PlayerRoles;
using PluginAPI.Core;
using UnityEngine;

namespace AutoReplace.API
{
    public static class AutoReplaceAPI
    {
        private static readonly Config _config = Plugin.Instance.Config;
        
        public static bool CanBeReplaced = true;

        public static bool ChooseReplacement(out Player player)
        {
            player = null;
            TeamInfo teamInfo = LargestTeam();

            if (teamInfo.Players.Count > 3)
            {
                player = teamInfo.Players[Random.Range(0, teamInfo.Players.Count)];
                return true;
            }

            Log.Debug("There are not enough people available to replace the SCP.", _config.Debug);
            return false;
        }

        private static TeamInfo LargestTeam()
        {
            List<Player> largestTeam = new List<Player>();

            foreach (Team team in _config.AvailableTeams)
            {
                List<Player> players = GetTeam(team).ToList();

                if (players.Count > largestTeam.Count)
                {
                    largestTeam = players;
                }
            }

            return new TeamInfo { Players = largestTeam, Team = largestTeam[0].Team };
        }

        private static IEnumerable<Player> GetTeam(Team team)
            => Player.GetPlayers().Where(x => x.Team == team).ToList();
    }
}