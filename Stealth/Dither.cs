using System;
using System.Collections.Generic;
using System.Text;

namespace Stealth
{
    public static class Dither
    {
        public const int DEPTH = 25;
        public const int WIDTH = 4;

        private static short[][,] dithers;

        public static void InitDither()
        {
            dithers = new short[DEPTH][,]
            {
                new short[WIDTH,WIDTH]
                {
                    { 0, 0, 0, 0 },
                    { 0, 0, 0, 0 },
                    { 0, 0, 0, 0 },
                    { 0, 0, 0, 0 },
                },
                new short[WIDTH,WIDTH]
                {
                    { 1, 0, 0, 0 },
                    { 0, 0, 0, 0 },
                    { 0, 0, 0, 0 },
                    { 0, 0, 0, 1 },
                },
                new short[WIDTH,WIDTH]
                {
                    { 1, 0, 0, 0 },
                    { 0, 0, 1, 0 },
                    { 0, 1, 0, 0 },
                    { 0, 0, 0, 1 },
                },
                new short[WIDTH,WIDTH]
                {
                    { 1, 0, 0, 0 },
                    { 0, 1, 1, 0 },
                    { 0, 1, 1, 0 },
                    { 0, 0, 0, 1 },
                },
                new short[WIDTH,WIDTH]
                {
                    { 1, 0, 1, 0 },
                    { 0, 1, 0, 1 },
                    { 1, 0, 1, 0 },
                    { 0, 1, 0, 1 },
                },
                new short[WIDTH,WIDTH]
                {
                    { 1, 1, 1, 0 },
                    { 1, 0, 0, 1 },
                    { 1, 0, 0, 1 },
                    { 0, 1, 1, 1 },
                },
                new short[WIDTH,WIDTH]
                {
                    { 1, 1, 1, 0 },
                    { 1, 0, 1, 1 },
                    { 1, 1, 0, 1 },
                    { 0, 1, 1, 1 },
                },
                new short[WIDTH,WIDTH]
                {
                    { 1, 1, 1, 0 },
                    { 1, 1, 1, 1 },
                    { 1, 1, 1, 1 },
                    { 0, 1, 1, 1 },
                },
                new short[WIDTH,WIDTH]
                {
                    { 1, 1, 1, 1 },
                    { 1, 1, 1, 1 },
                    { 1, 1, 1, 1 },
                    { 1, 1, 1, 1 },
                },
                new short[WIDTH,WIDTH]
                {
                    { 2, 1, 1, 1 },
                    { 1, 1, 1, 1 },
                    { 1, 1, 1, 1 },
                    { 1, 1, 1, 2 },
                },
                new short[WIDTH,WIDTH]
                {
                    { 2, 1, 1, 1 },
                    { 1, 1, 2, 1 },
                    { 1, 2, 1, 1 },
                    { 1, 1, 1, 2 },
                },
                new short[WIDTH,WIDTH]
                {
                    { 2, 1, 1, 1 },
                    { 1, 2, 2, 1 },
                    { 1, 2, 2, 1 },
                    { 1, 1, 1, 2 },
                },
                new short[WIDTH,WIDTH]
                {
                    { 2, 1, 2, 1 },
                    { 1, 2, 1, 2 },
                    { 2, 1, 2, 1 },
                    { 1, 2, 1, 2 },
                },
                new short[WIDTH,WIDTH]
                {
                    { 2, 2, 2, 1 },
                    { 2, 1, 1, 2 },
                    { 2, 1, 1, 2 },
                    { 1, 2, 2, 2 },
                },
                new short[WIDTH,WIDTH]
                {
                    { 2, 2, 2, 1 },
                    { 2, 1, 2, 2 },
                    { 2, 2, 1, 2 },
                    { 1, 2, 2, 2 },
                },
                new short[WIDTH,WIDTH]
                {
                    { 2, 2, 2, 1 },
                    { 2, 2, 2, 2 },
                    { 2, 2, 2, 2 },
                    { 1, 2, 2, 2 },
                },
                new short[WIDTH,WIDTH]
                {
                    { 2, 2, 2, 2 },
                    { 2, 2, 2, 2 },
                    { 2, 2, 2, 2 },
                    { 2, 2, 2, 2 },
                },
                new short[WIDTH,WIDTH]
                {
                    { 3, 2, 2, 2 },
                    { 2, 2, 2, 2 },
                    { 2, 2, 2, 2 },
                    { 2, 2, 2, 3 },
                },
                new short[WIDTH,WIDTH]
                {
                    { 3, 2, 2, 2 },
                    { 2, 2, 3, 2 },
                    { 2, 3, 2, 2 },
                    { 2, 2, 2, 3 },
                },
                new short[WIDTH,WIDTH]
                {
                    { 3, 2, 2, 2 },
                    { 2, 3, 3, 2 },
                    { 2, 3, 3, 2 },
                    { 2, 2, 2, 3 },
                },
                new short[WIDTH,WIDTH]
                {
                    { 3, 2, 3, 2 },
                    { 2, 3, 2, 3 },
                    { 3, 2, 3, 2 },
                    { 2, 3, 2, 3 },
                },
                new short[WIDTH,WIDTH]
                {
                    { 3, 3, 3, 2 },
                    { 3, 2, 2, 3 },
                    { 3, 2, 2, 3 },
                    { 2, 3, 3, 3 },
                },
                new short[WIDTH,WIDTH]
                {
                    { 3, 3, 3, 2 },
                    { 3, 2, 3, 3 },
                    { 3, 3, 2, 3 },
                    { 2, 3, 3, 3 },
                },
                new short[WIDTH,WIDTH]
                {
                    { 3, 3, 3, 2 },
                    { 3, 3, 3, 3 },
                    { 3, 3, 3, 3 },
                    { 2, 3, 3, 3 },
                },
                new short[WIDTH,WIDTH]
                {
                    { 3, 3, 3, 3 },
                    { 3, 3, 3, 3 },
                    { 3, 3, 3, 3 },
                    { 3, 3, 3, 3 },
                },
            };
        }

        public static short ToDither(short level, int x, int y)
        {
            if (level >= DEPTH)
                return DEPTH - 1;
            if (level < 0)
                return 0;
            return dithers[level][y % 4, x % 4];
        }
    }
}
