using System;
using System.Collections.Generic;
using BetterFog.Config;
using BetterFog.Infrastructure;
using UnityEngine;

namespace BetterFog.Features
{
    public sealed class MistFeature : IFeature
    {
        private readonly IGameEvents _events;
        private readonly IModSettings _settings;
        private readonly HashSet<ParticleSystem> _faded = new HashSet<ParticleSystem>();
        private GameObject[] _weatherSystems;

        public MistFeature(IGameEvents events, IModSettings settings)
        {
            _events = events;
            _settings = settings;
        }

        public void Enable()
        {
            _events.EnvironmentApplied += OnEnvironmentApplied;
            _events.MistCreated += OnMistCreated;
            _events.FogEmitterUpdating += OnFogEmitterUpdating;
        }

        public void Disable()
        {
            _events.EnvironmentApplied -= OnEnvironmentApplied;
            _events.MistCreated -= OnMistCreated;
            _events.FogEmitterUpdating -= OnFogEmitterUpdating;
        }

        private static bool IsFogLike(ParticleSystem system)
        {
            var name = system.name;
            return name.IndexOf("fog", StringComparison.OrdinalIgnoreCase) >= 0
                || name.IndexOf("mist", StringComparison.OrdinalIgnoreCase) >= 0;
        }

        private void OnEnvironmentApplied()
        {
            var current = EnvMan.instance.m_currentPSystems;
            if (current == null || current == _weatherSystems)
            {
                return;
            }

            _weatherSystems = current;
            foreach (var weather in current)
            {
                foreach (var system in weather.GetComponentsInChildren<ParticleSystem>(true))
                {
                    if (IsFogLike(system))
                    {
                        Fade(system);
                    }
                }
            }
        }

        private void OnMistCreated(ParticleMist mist)
        {
            Fade(mist.m_ps);
        }

        private void OnFogEmitterUpdating(DistantFogEmitter emitter)
        {
            foreach (var system in emitter.m_psystems)
            {
                Fade(system);
            }
        }

        private void Fade(ParticleSystem system)
        {
            if (_faded.Add(system))
            {
                ParticleFade.Scale(system, _settings.MistOpacity);
            }
        }
    }
}
