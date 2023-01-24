using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace Stealth
{
    public partial class Stealth
    {
        public const int PALETTE_SIZE = 4;

        public enum PalettesTypes { basic, deepBlue, COUNT };
        public static Color[,] Palettes = new Color[(int)PalettesTypes.COUNT, PALETTE_SIZE]
        {
            { new Color(0, 0, 0), new Color(20, 20, 20), new Color(90, 90, 90), new Color(180, 180, 180) },
            { new Color(0, 0, 0), new Color(4, 8, 46), new Color(66, 73, 133), new Color(165, 168, 196) },
        };
    }
}
