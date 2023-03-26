using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace Stealth
{
    public class Light
    {
        private Func<Vector3, Vector3> intensity;

        public Light(Func<Vector3, Vector3> intenstity)
        {
            this.intensity = intenstity;
        }
        public Vector3 Intensity(Vector3 position)
        {
            return intensity(position);
        }

        public static Light CreateIsotropic(Vector3 position, float intensity)
        {
            return new Light(new Func<Vector3, Vector3>(p => 
            {
                Vector3 difference = p - position;
                float length = difference.Length();
                difference.Normalize();
                return difference * intensity / (length * length); 
            }));
        }

        public static Light CreateCardioid(Vector3 position, Vector3 direction, float intensity)
        {
            direction.Normalize();
            return new Light(new Func<Vector3, Vector3>(p =>
            {
                Vector3 difference = p - position;
                float length = difference.Length();
                difference.Normalize();
                float cardioid = (1 + Vector3.Dot(direction, difference)) * 0.5f;
                return difference * intensity * cardioid / (length * length);
            }));
        }
    }
}
