using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace Stealth
{
    public class Sprite
    {
        private sbyte[,] pixels;

        private short width;
        public short Width { get => width; }

        private short height;
        public short Height { get => height; }

        public Sprite(byte[,] colors, byte[,] masks)
        {
            if (colors.GetLength(0) != masks.GetLength(0) || colors.GetLength(1) != 2 * masks.GetLength(1))
                throw new ArgumentException("Color and mask array size mismatch. Arrays must be mxn and mx2n for mask and color, respectively.");

            width = (short)(masks.GetLength(1) * 8);
            height = (short)masks.GetLength(0);

            pixels = new sbyte[height, width];
            for (int y = 0; y < height; y++)
                for (int x = 0; x < width; x++)
                    pixels[y, x] = (sbyte)((1 & (masks[y, x / 8] >> (7 - (x & 7)))) == 0 ? -1 : 3 & (colors[y, x / 4] >> ((3 - (x & 3)) << 1)));
        }

        public sbyte GetPixel(short x, short y)
        {
            // Check if bit at y, x is 1; if so, return 2 bits at y, x
            return pixels[y, x];
        }
    }
}
