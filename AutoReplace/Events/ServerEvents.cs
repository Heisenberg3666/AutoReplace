using AutoReplace.API;
using MEC;
using PluginAPI.Core;
using PluginAPI.Core.Attributes;
using PluginAPI.Enums;

namespace AutoReplace.Events
{
    public class ServerEvents
    {
        private readonly Config _config;

        public ServerEvents()
        {
            _config = Plugin.Instance.Config;
        }
        
        [PluginEvent(ServerEventType.RoundStart)]
        private void OnRoundStart()
        {
            Timing.CallDelayed(_config.StopAfterSeconds, () =>
            {
                AutoReplaceAPI.CanBeReplaced = false;
                Log.Debug("SCPs will no longer be automatically replaced.", _config.Debug);
            });
        }
    }
}