using UnityEngine;

namespace BetterFog.Infrastructure
{
    internal static class ParticleFade
    {
        private const string ColorProperty = "_Color";

        public static void Scale(ParticleSystem system, float factor)
        {
            var material = system.GetComponent<ParticleSystemRenderer>().material;
            if (material.HasProperty(ColorProperty))
            {
                material.SetColor(ColorProperty, Faded(material.GetColor(ColorProperty), factor));
                return;
            }

            ScaleStartColor(system, factor);
        }

        private static void ScaleStartColor(ParticleSystem system, float factor)
        {
            var main = system.main;
            var color = main.startColor;
            switch (color.mode)
            {
                case ParticleSystemGradientMode.Color:
                    color.color = Faded(color.color, factor);
                    break;
                case ParticleSystemGradientMode.TwoColors:
                    color.colorMin = Faded(color.colorMin, factor);
                    color.colorMax = Faded(color.colorMax, factor);
                    break;
                default:
                    return;
            }

            main.startColor = color;
        }

        private static Color Faded(Color color, float factor)
        {
            color.a *= factor;
            return color;
        }
    }
}
