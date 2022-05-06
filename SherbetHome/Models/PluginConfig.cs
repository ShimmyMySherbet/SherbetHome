using Rocket.API;

namespace SherbetHome.Models
{
    public class PluginConfig : IRocketPluginConfiguration
    {
        public int HomeDelay = 10;

        public void LoadDefaults()
        {
        }
    }
}