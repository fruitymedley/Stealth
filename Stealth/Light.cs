using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace Stealth
{
    public interface Light
    {
        public abstract float Intensity(Vector3 position, Vector3 normal);
    }

    public class IsotropicLight : Light
    {
        private Vector3 position;
        private float intensity;
        private Vector3 difference;

        public IsotropicLight(Vector3 position, float intensity)
        {
            this.position = position;
            this.intensity = intensity;
            difference = new Vector3();
        }

        public float Intensity(Vector3 p, Vector3 normal)
        {
            difference.X = p.X - position.X;
            difference.Y = p.Y - position.Y;
            difference.Z = p.Z - position.Z;
            float cos = difference.X * normal.X + difference.Y * normal.Y + difference.Z * normal.Z;
            if (cos < 0)
                return 0;
            float length = difference.Length();
            return cos * intensity / (float)(length * length * length);
        }
    }

    public class CardioidLight : Light
    {
        private Vector3 position;
        private Vector3 direction;
        private float intensity;

        public CardioidLight(Vector3 position, Vector3 direction, float intensity)
        {
            direction.Normalize();

            this.position = position;
            this.direction = direction;
            this.intensity = intensity;
        }
        public float Intensity(Vector3 p, Vector3 normal)
        {
            return 0;
            //Vector3 difference = p - position;
            //float length = difference.Length();
            //difference.Normalize();
            //float cardioid = (1 + Vector3.Dot(direction, difference)) * 0.5f;
            //return difference * intensity * cardioid / (length * length);
        }
    }
}
