using BetterFog.Infrastructure;
using HarmonyLib;
using UnityEngine;

namespace BetterFog.Patches
{
    internal static class FogPatches
    {
        [HarmonyPatch(typeof(EnvMan), "SetEnv")]
        private static class SetEnv
        {
            private static void Postfix()
            {
                if (Camera.main != null)
                {
                    GameEvents.Instance?.RaiseEnvironmentApplied();
                }
            }
        }

        [HarmonyPatch(typeof(ParticleMist), "Awake")]
        private static class MistAwake
        {
            private static void Postfix(ParticleMist __instance)
            {
                GameEvents.Instance?.RaiseMistCreated(__instance);
            }
        }

        [HarmonyPatch(typeof(DistantFogEmitter), "Update")]
        private static class FogEmitterUpdate
        {
            private static void Prefix(DistantFogEmitter __instance)
            {
                GameEvents.Instance?.RaiseFogEmitterUpdating(__instance);
            }
        }
    }
}
