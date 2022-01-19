using UnityEngine;
using UnityEngine.UI;

namespace RainingBalls.Effects
{
    public static class Recolorer
    {
        public static void RecolorParticle(ParticleSystem particle, Image image)
        {
            var main = particle.main;
            var color = GetColorFromImage(image);
            main.startColor = new ParticleSystem.MinMaxGradient(color);
        }

        private static Color GetColorFromImage(Image image)
        {
            var x = (int) image.rectTransform.rect.width / 2;
            var y = (int) image.rectTransform.rect.height / 2;
            var color = image.sprite.texture.GetPixel(x, y);
            color.a = 1;
            return color;
        }
    }
}