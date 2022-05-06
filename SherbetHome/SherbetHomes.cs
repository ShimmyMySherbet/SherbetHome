using Rocket.Core.Logging;
using Rocket.Core.Plugins;
using SherbetHome.Models;

namespace SherbetHome
{
    public partial class SherbetHomes : RocketPlugin<PluginConfig>
    {
        public PluginConfig Config => Configuration.Instance;
        public HomeManager HomeManager;
        public override void LoadPlugin()
        {
            base.LoadPlugin();
            HomeManager = gameObject.AddComponent<HomeManager>();
            Logger.Log("SherbetHomes by ShimmyMySherbet loaded!");
        }
    }
}