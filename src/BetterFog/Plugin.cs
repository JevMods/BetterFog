using BepInEx;
using BetterFog.Config;
using BetterFog.Features;
using BetterFog.Infrastructure;
using HarmonyLib;

namespace BetterFog
{
    [BepInPlugin(PluginGuid, PluginName, BuildInfo.Version)]
    public sealed class Plugin : BaseUnityPlugin
    {
        public const string PluginGuid = "JevMods.BetterFog";
        public const string PluginName = "BetterFog";

        private IFeature[] _features;
        private Harmony _harmony;

        private void Awake()
        {
            var events = new GameEvents();
            GameEvents.Instance = events;

            var settings = new ModSettings(Config);
            _features = new IFeature[]
            {
                new DistanceFogFeature(events, settings),
                new MistFeature(events, settings),
                new SmokeFeature(events, settings)
            };
            foreach (var feature in _features)
            {
                feature.Enable();
            }

            _harmony = new Harmony(PluginGuid);
            _harmony.PatchAll();

            Logger.LogInfo("Loaded");
        }

        private void OnDestroy()
        {
            _harmony?.UnpatchSelf();
            if (_features != null)
            {
                foreach (var feature in _features)
                {
                    feature.Disable();
                }
            }

            GameEvents.Instance = null;
        }
    }
}
