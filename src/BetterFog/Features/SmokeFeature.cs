using BetterFog.Config;
using BetterFog.Infrastructure;

namespace BetterFog.Features
{
    public sealed class SmokeFeature : IFeature
    {
        private readonly IGameEvents _events;
        private readonly IModSettings _settings;

        public SmokeFeature(IGameEvents events, IModSettings settings)
        {
            _events = events;
            _settings = settings;
        }

        public void Enable()
        {
            _events.SmokeAlphaCalculated += OnSmokeAlphaCalculated;
        }

        public void Disable()
        {
            _events.SmokeAlphaCalculated -= OnSmokeAlphaCalculated;
        }

        private void OnSmokeAlphaCalculated(ref float alpha)
        {
            alpha *= _settings.SmokeOpacity;
        }
    }
}
