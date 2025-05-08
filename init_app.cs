using Renga;

namespace AutoSaveRengaPlugin
{
    public class InitApp : IPlugin
    {
        private AutoSavePlugin _plugin;

        public bool Initialize(string pluginFolder)
        {
            var rengaApp = new Renga.Application();
            _plugin = new AutoSavePlugin();
            _plugin.Init(rengaApp);
            return true;
        }

        public void Stop()
        {
            _plugin?.Stop();
        }
    }
}
