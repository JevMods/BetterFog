using BetterFog.Config;
using BetterFog.Infrastructure;
using UnityEngine;

namespace BetterFog.Features
{
    public sealed class DistanceFogFeature : IFeature
    {
        private readonly IGameEvents _events;
        private readonly IModSettings _settings;

        public DistanceFogFeature(IGameEvents events, IModSettings settings)
        {
            _events = events;
            _settings = settings;
        }

        public void Enable()
        {
            _events.EnvironmentApplied += OnEnvironmentApplied;
        }

        public void Disable()
        {
            _events.EnvironmentApplied -= OnEnvironmentApplied;
        }

        private void OnEnvironmentApplied()
        {
            RenderSettings.fogDensity *= _settings.FogDensity;
        }
    }
}
