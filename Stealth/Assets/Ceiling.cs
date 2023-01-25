using System;
using System.Collections.Generic;
using System.Text;
using Stealth;

namespace Stealth.Assets
{
   class Ceiling
   {
       public static Dictionary<int, Sprite> Sprites;
       public static void Init()
       {
           Sprites = new Dictionary<int, Sprite>
           {
                 { 0, new Sprite(new byte[,] { { 255, 170, }, { 255, 170, }, { 255, 170, }, { 255, 170, }, { 170, 255, }, { 170, 255, }, { 170, 255, }, { 170, 255, }, }, new byte[,] { { 255, }, { 255, }, { 255, }, { 255, }, { 255, }, { 255, }, { 255, }, { 255, }, })},
                 { 1, new Sprite(new byte[,] { { 0, 0, }, { 0, 0, }, { 0, 0, }, { 0, 0, }, { 0, 0, }, { 0, 0, }, { 0, 0, }, { 0, 0, }, }, new byte[,] { { 255, }, { 255, }, { 255, }, { 255, }, { 255, }, { 255, }, { 255, }, { 255, }, })},
           };
       }
   }
}
