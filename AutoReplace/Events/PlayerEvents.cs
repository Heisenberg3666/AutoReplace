using AutoReplace.API;
using PlayerRoles;
using PluginAPI.Core;
using PluginAPI.Core.Attributes;
using PluginAPI.Enums;
using PluginAPI.Events;

namespace AutoReplace.Events
{
    public class PlayerEvents
    {
        private readonly Config _config;

        public PlayerEvents()
        {
            _config = Plugin.Instance.Config;
        }

        [PluginEvent(ServerEventType.PlayerLeft)]
        private void OnPlayerLeft(PlayerLeftEvent ev)
        {
            RoleTypeId role = ev.Player.Role;
            
            if (ev.Player.Team != Team.SCPs)
            {
                Log.Debug("Player is not an SCP!", _config.Debug);
                return;
            }

            if (!AutoReplaceAPI.CanBeReplaced)
            {
                Log.Debug("SCP cannot be replaced, the time limit has run out.", _config.Debug);
                return;
            }

            if (!AutoReplaceAPI.ChooseReplacement(out Player replacement))
                return;
            
            replacement.SetRole(role);
            Log.Debug("SCP has been replaced.", _config.Debug);

            string message = _config.BroadcastMessage
                .Replace("%scp%", role.ToString())
                .Replace("%newplayer%", replacement.Nickname)
                .Replace("%oldplayer%", ev.Player.Nickname);
            
            Map.Broadcast(5, message);
        }
    }
}