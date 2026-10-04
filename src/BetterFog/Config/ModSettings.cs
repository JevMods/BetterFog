using BepInEx.Configuration;

namespace BetterFog.Config
{
    public sealed class ModSettings : IModSettings
    {
        private readonly ConfigEntry<float> _fogDensity;
        private readonly ConfigEntry<float> _mistOpacity;
        private readonly ConfigEntry<float> _smokeOpacity;

        public ModSettings(ConfigFile file)
        {
            _fogDensity = file.Bind(
                "Fog",
                "Density",
                0.5f,
                new ConfigDescription(
                    "Reduces the distance fog density to this fraction of vanilla, "
                        + "from 0 (no fog) to 1 (unchanged).",
                    new AcceptableValueRange<float>(0f, 1f)));

            _mistOpacity = file.Bind(
                "Fog",
                "MistOpacity",
                0.2f,
                new ConfigDescription(
                    "Reduces the opacity of the mist and fog particles (Mistlands mist, fog "
                        + "banks, weather fog) to this fraction of vanilla, from 0 (invisible) "
                        + "to 1 (unchanged). Restart the game after changing it.",
                    new AcceptableValueRange<float>(0f, 1f)));

            _smokeOpacity = file.Bind(
                "Smoke",
                "Opacity",
                0.5f,
                new ConfigDescription(
                    "Reduces the opacity of fire smoke to this fraction of vanilla, "
                        + "from 0 (invisible) to 1 (unchanged).",
                    new AcceptableValueRange<float>(0f, 1f)));
        }

        public float FogDensity => _fogDensity.Value;

        public float MistOpacity => _mistOpacity.Value;

        public float SmokeOpacity => _smokeOpacity.Value;
    }
}
