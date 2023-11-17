using AutoReplace.Events;
using PluginAPI.Core.Attributes;
using PluginAPI.Events;

namespace AutoReplace
{
    public class Plugin
    {
        public static Plugin Instance;

        [PluginConfig]
        public Config Config;

        [PluginEntryPoint("AutoReplace", "1.0.1", 
            "A plugin that replaces SCPs that leave early in the game.", "Heisenberg3666")]
        private void LoadPlugin()
        {
            Instance = this;
            
            EventManager.RegisterEvents<ServerEvents>(Instance);
            EventManager.RegisterEvents<PlayerEvents>(Instance);
        }

        [PluginUnload]
        private void UnloadPlugin()
        {
            EventManager.UnregisterEvents<ServerEvents>(Instance);
            EventManager.UnregisterEvents<PlayerEvents>(Instance);
            
            Instance = null;
        }
    }
}