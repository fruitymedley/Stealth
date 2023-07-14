using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace Stealth
{
    public class Sprite
    {
        public const float bitToDither = Dither.DEPTH / 16.0f;

        private sbyte[,] mask;
        private sbyte[,] flat;
        private sbyte[,] reflect;
        private Vector3[,] normal;

        private short width;
        public short Width { get => width; }

        private short height;
        public short Height { get => height; }

        public Sprite(sbyte[,] mask, sbyte[,] flat, sbyte[,] reflect = null, Vector3[,] normal = null)
        {
            if (flat.GetLength(0) != mask.GetLength(0) || flat.GetLength(1) != mask.GetLength(1))
                throw new ArgumentException("Flat and mask array size mismatch. Arrays must be mxn.");

            if (reflect != null && (flat.GetLength(0) != reflect.GetLength(0) || flat.GetLength(1) != reflect.GetLength(1)))
                throw new ArgumentException("Flat and reflect array size mismatch. Arrays must be mxn.");

            if (normal != null && (flat.GetLength(0) != normal.GetLength(0) || flat.GetLength(1) != normal.GetLength(1)))
                throw new ArgumentException("Flat and normal array size mismatch. Arrays must be mxn.");

            width = (short)mask.GetLength(1);
            height = (short)mask.GetLength(0);

            this.mask = mask;
            this.flat = flat;
            this.reflect = reflect;
            this.normal = normal;
        }

        public sbyte GetPixel(short x, short y, Vector3[] rays=null)
        {
            if (rays == null || reflect == null || normal == null)
                return mask[y,x] == 0 ? (sbyte)-1 : flat[y, x];

            float intensity = 0;
            foreach (Vector3 ray in rays)
            {
                float part = Vector3.Dot((Vector3)ray, normal[y, x]);
                if (part > 0)
                    intensity += part;
            }
            return (sbyte)Math.Max(0, Math.Min(Dither.DEPTH, mask[y, x] == 0 ? -1 : flat[y, x] * bitToDither + reflect[y, x] * intensity));
        }
    }
}
