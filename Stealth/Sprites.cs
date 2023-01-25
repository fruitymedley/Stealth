using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace Stealth
{
    public class Sprite
    {
        private byte[,] color;
        private byte[,] mask;

        private short width;
        public short Width { get => width; }

        private short height;
        public short Height { get => height; }

        public Sprite(byte[,] color, byte[,] mask)
        {
            if (color.GetLength(0) != mask.GetLength(0) || color.GetLength(1) != 2 * mask.GetLength(1))
                throw new ArgumentException("Color and mask array size mismatch. Arrays must be mxn and mx2n for mask and color, respectively.");

            this.color = color;
            this.mask = mask;

            width = (short)(mask.GetLength(1) * 8);
            height = (short)mask.GetLength(0);
        }

        public sbyte GetPixel(short x, short y)
        {
            // Check if bit at y, x is 1; if so, return 2 bits at y, x
            return (sbyte)((mask[y, x / 8] & (1 << (x & 7))) == 0 ? -1 : color[y, x / 4] & (3 << (x & 3)));
        }
    }

    public class Sprites
    {
        public sbyte[,] Texture;
        public Point Location;

        public Sprites() { }
    }

    public partial class Stealth
    {
        public enum SpriteList { apple, player, COUNT };
        public static sbyte[][,] Sprites = new sbyte[(int)SpriteList.COUNT][,]
        {
            new sbyte[WALL_HEIGHT, WALL_WIDTH]
            {
                {-3,-3,-3,-3,-3,-3,-3,-3, },
                {-1,-1,-1,-1,-1,-1,-1,-1, },
                {-3,-3,-3,-3,-3,-3,-3,-3, },
                {-3,-3,-3,-3,-3,-3,-3,-3, },
                {-3,-3,-3,-3,-3,-3,-3,-3, },
                {-3,-3,-3,-3,-3,-3,-3,-3, },
                {-3,-3,-3,-3,-3,-3,-3,-3, },
                {-3,-3,-3,-3,-3,-3,-3,-3, },
                {-3,-3,-3,-3,-3,-3,-3,-3, },
                {-3,-3,-3,-3,-3,-3,-3,-3, },
                {-3,-3,-3,-3,-3,-3,-3,-3, },
                {-3,-3,-3,-3,-3,-3,-3,-3, },
                {-3,-3,-3,-3,-3,-3,-3,-3, },
                {-3,-3,-3,-3,-3,-3,-3,-3, },
                {-3,-3,-3,-3,-3,-3,-3,-3, },
                {-3,-3,-3,-3,-3,-3,-3,-3, },
                {-3,-3,-3,-3,-3,-3,-3,-3, },
                {-3,-3,-3,-3,-3,-3,-3,-3, },
                {-3,-3,-3,-3,-3,-3,-3,-3, },
                {-3,-3,-3,-3,-3,-3,-3,-3, },
                {-3,-3,-3,-3,-3,-3,-3,-3, },
                {-3,-3,-3,-3,-3,-3,-3,-3, },
                {-3,-3,-3,-3,-3,-3,-3,-3, },
                {-3,-3,-3,-3,-3,-3,-3,-3, },
                {-3,-3,-3, 3, 3,-3,-3,-3, },
                {-3,-3, 3,-3,-3, 3,-3,-3, },
                {-3, 3,-3,-3,-3,-3, 3,-3, },
                { 3,-3,-3,-3,-3,-3,-3, 3, },
                { 3,-3,-3,-3,-3,-3,-3, 3, },
                {-3, 3,-3,-3,-3,-3, 3,-3, },
                {-3,-3, 3,-3,-3, 3,-3,-3, },
                {-3,-3,-3, 3, 3,-3,-3,-3, },
            },
            new sbyte[WALL_HEIGHT, WALL_WIDTH]
            {
                {-1,-1,-1,-1,-1,-1,-1,-1, },
                {-1,-1,-1,-1,-1,-1,-1,-1, },
                {-1,-1,-1,-1,-1,-1,-1,-1, },
                {-1,-1,-1,-1,-1,-1,-1,-1, },
                {-1,-1,-1,-1,-1,-1,-1,-1, },
                {-1,-1,-1,-1,-1,-1,-1,-1, },
                {-1,-1,-1,-1,-1,-1,-1,-1, },
                {-1,-1,-1,-1,-1,-1,-1,-1, },
                {-1,-1,-1, 0, 0, 1,-1,-1, },
                {-1,-1, 0, 1, 1, 2, 1,-1, },
                {-1, 0, 1, 2, 2, 2, 2, 1, },
                {-1, 0, 1, 3, 0, 2, 3, 0, },
                {-1, 0, 1, 2, 2, 2, 2, 2, },
                { 0, 1, 1, 2, 1, 1, 2,-1, },
                { 1, 2, 1, 1, 2, 2, 1, 1, },
                { 1, 2, 2, 2, 1, 1, 1, 1, },
                { 1, 2, 2, 2, 3, 3, 1,-1, },
                { 1, 1, 1, 1, 2, 3, 1,-1, },
                { 1, 2, 2, 2, 1, 1, 1, 3, },
                { 0, 1, 1, 1, 2, 2, 1, 3, },
                { 0, 0, 0, 0, 1, 1, 1,-1, },
                { 1, 1, 1, 1, 0, 0, 0,-1, },
                { 1, 2, 2, 2, 1, 1, 1,-1, },
                { 1, 2, 2, 2, 2, 2, 1,-1, },
                { 1, 3, 2, 0, 2, 3, 1,-1, },
                { 1, 3, 2, 1, 2, 3, 1,-1, },
                { 1, 3, 2, 0, 2, 3, 1,-1, },
                { 1, 2, 2, 1, 1, 2, 1,-1, },
                { 1, 1, 2, 1, 2, 1, 1,-1, },
                { 1, 2, 1, 1, 2, 2, 3, 0, },
                { 1, 2, 2, 3, 0, 0, 0,-1, },
                {-1, 0, 0, 0,-1,-1,-1,-1, },
            }
        };
    }
}
