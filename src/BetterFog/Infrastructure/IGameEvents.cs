using System;

namespace BetterFog.Infrastructure
{
    public interface IGameEvents
    {
        event Action EnvironmentApplied;
        event Action<ParticleMist> MistCreated;
        event Action<DistantFogEmitter> FogEmitterUpdating;
        event SmokeAlphaHandler SmokeAlphaCalculated;
    }
}
