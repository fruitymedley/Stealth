using System;
using System.Collections.Generic;
using System.Text;
using Stealth;

namespace Stealth.Assets
{
   class Item
   {
       public static Dictionary<int, Sprite> Sprites;
       public static void Init()
       {
           Sprites = new Dictionary<int, Sprite>
           {
                 { 0, new Sprite(new byte[,] { { 0, 0, }, { 0, 0, }, { 0, 0, }, { 0, 0, }, { 0, 0, }, { 0, 0, }, { 0, 0, }, { 0, 0, }, { 0, 0, }, { 0, 0, }, { 0, 0, }, { 0, 0, }, { 0, 0, }, { 0, 0, }, { 0, 0, }, { 0, 0, }, { 0, 0, }, { 0, 0, }, { 0, 0, }, { 0, 0, }, { 0, 0, }, { 0, 0, }, { 0, 0, }, { 0, 0, }, { 8, 32, }, { 42, 168, }, { 170, 186, }, { 170, 250, }, { 42, 168, }, { 42, 168, }, { 10, 160, }, { 8, 32, }, }, new byte[,] { { 0, }, { 0, }, { 0, }, { 0, }, { 0, }, { 0, }, { 0, }, { 0, }, { 0, }, { 0, }, { 0, }, { 0, }, { 0, }, { 0, }, { 0, }, { 0, }, { 0, }, { 0, }, { 0, }, { 0, }, { 0, }, { 0, }, { 0, }, { 16, }, { 60, }, { 126, }, { 255, }, { 255, }, { 126, }, { 126, }, { 60, }, { 36, }, })},
           };
       }
   }
}
