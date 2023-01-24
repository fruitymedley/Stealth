using System;
using System.Collections.Generic;
using System.Text;

namespace Stealth
{
    public partial class Stealth
    {
        public enum FloorTypes { checker, COUNT };
        public static sbyte[][,] Floors = new sbyte[(int)FloorTypes.COUNT][,]
        {
            new sbyte[WALL_WIDTH, WALL_WIDTH]
            {
                { 0, 0, 0, 0, 2, 2, 2, 2, },
                { 0, 0, 0, 0, 2, 2, 2, 2, },
                { 0, 0, 0, 0, 2, 2, 2, 2, },
                { 0, 0, 0, 0, 2, 2, 2, 2, },
                { 2, 2, 2, 2, 0, 0, 0, 0, },
                { 2, 2, 2, 2, 0, 0, 0, 0, },
                { 2, 2, 2, 2, 0, 0, 0, 0, },
                { 2, 2, 2, 2, 0, 0, 0, 0, },
            }
        };
    }
}
