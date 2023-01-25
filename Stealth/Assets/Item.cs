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
                 { 0, new Sprite(new byte[,] { { 0, 0, }, { 0, 0, }, { 0, 0, }, { 0, 0, }, { 0, 0, }, { 0, 0, }, { 0, 0, }, { 0, 0, }, { 0, 0, }, { 0, 0, }, { 0, 0, }, { 0, 0, }, { 0, 0, }, { 0, 0, }, { 0, 0, }, { 0, 0, }, { 0, 0, }, { 0, 0, }, { 0, 0, }, { 0, 0, }, { 0, 0, }, { 0, 0, }, { 0, 0, }, { 0, 0, }, { 3, 192, }, { 12, 48, }, { 48, 12, }, { 192, 3, }, { 192, 3, }, { 48, 12, }, { 12, 48, }, { 3, 192, }, }, new byte[,] { { 0, }, { 0, }, { 0, }, { 0, }, { 0, }, { 0, }, { 0, }, { 0, }, { 0, }, { 0, }, { 0, }, { 0, }, { 0, }, { 0, }, { 0, }, { 0, }, { 0, }, { 0, }, { 0, }, { 0, }, { 0, }, { 0, }, { 0, }, { 0, }, { 24, }, { 36, }, { 66, }, { 129, }, { 129, }, { 66, }, { 36, }, { 24, }, })},
           };
       }
   }
}
