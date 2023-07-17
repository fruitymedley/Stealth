using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace Stealth
{
    public class Sprite
    {
        public const float bitToDither = Dither.DEPTH / 16.0f;

        public sbyte[,] Mask;
        public sbyte[,] Flat;
        public sbyte[,] Reflect;
        public Vector3[,] Normal;

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

            width = (short)mask.GetLength(0);
            height = (short)mask.GetLength(1);

            this.Mask = mask;
            this.Flat = flat;
            this.Reflect = reflect;
            this.Normal = normal;
        }
    }
}
