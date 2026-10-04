using System;

namespace BetterFog.Infrastructure
{
    public sealed class GameEvents : IGameEvents
    {
        internal static GameEvents Instance { get; set; }

        public event Action EnvironmentApplied;
        public event Action<ParticleMist> MistCreated;
        public event Action<DistantFogEmitter> FogEmitterUpdating;
        public event SmokeAlphaHandler SmokeAlphaCalculated;

        internal void RaiseEnvironmentApplied()
        {
            EnvironmentApplied?.Invoke();
        }

        internal void RaiseMistCreated(ParticleMist mist)
        {
            MistCreated?.Invoke(mist);
        }

        internal void RaiseFogEmitterUpdating(DistantFogEmitter emitter)
        {
            FogEmitterUpdating?.Invoke(emitter);
        }

        internal void RaiseSmokeAlphaCalculated(ref float alpha)
        {
            SmokeAlphaCalculated?.Invoke(ref alpha);
        }
    }
}
