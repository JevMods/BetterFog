using BetterFog.Infrastructure;
using HarmonyLib;

namespace BetterFog.Patches
{
    internal static class SmokePatches
    {
        [HarmonyPatch(typeof(Smoke), nameof(Smoke.GetAlpha))]
        private static class GetAlpha
        {
            private static void Postfix(ref float __result)
            {
                GameEvents.Instance?.RaiseSmokeAlphaCalculated(ref __result);
            }
        }
    }
}
