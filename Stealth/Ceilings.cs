using System;
using System.Collections.Generic;
using System.Text;

namespace Stealth
{
    public partial class Stealth
    {
        public enum CeilingTypes { checkerboard, COUNT }
        public static sbyte[][,] Ceilings = new sbyte[(int)CeilingTypes.COUNT][,]
        {
            // Checkerboard
            new sbyte[WALL_WIDTH, WALL_WIDTH]
            {
                { 3, 3, 3, 3, 2, 2, 2, 2, },
                { 3, 3, 3, 3, 2, 2, 2, 2, },
                { 3, 3, 3, 3, 2, 2, 2, 2, },
                { 3, 3, 3, 3, 2, 2, 2, 2, },
                { 2, 2, 2, 2, 3, 3, 3, 3, },
                { 2, 2, 2, 2, 3, 3, 3, 3, },
                { 2, 2, 2, 2, 3, 3, 3, 3, },
                { 2, 2, 2, 2, 3, 3, 3, 3, },
            }
        };
    }
}
