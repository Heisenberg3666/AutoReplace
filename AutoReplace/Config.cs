using System.Collections.Generic;
using System.ComponentModel;
using PlayerRoles;

namespace AutoReplace
{
    public class Config
    {
        public bool Debug { get; set; } = false;
        
        [Description("Stops SCPs from being replaced after a certain amount of seconds pass.")]
        public float StopAfterSeconds { get; set; } = 30f;

        [Description(
            "The message that is broadcasted to everyone when an SCP is replaced. Variables: %scp% %newplayer% %oldplayer%")]
        public string BroadcastMessage { get; set; } = "%scp% has been replaced by %newplayer%";

        [Description("Players within these teams can be chosen to replace the SCP.")]
        public List<Team> AvailableTeams { get; set; } = new List<Team>()
        {
            Team.Dead,
            Team.Scientists,
            Team.ChaosInsurgency,
            Team.ClassD,
            Team.FoundationForces
        };
    }
}