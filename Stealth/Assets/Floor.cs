using System;
using System.Collections.Generic;
using System.Text;
using Stealth;

namespace Stealth.Assets
{
   class Floor
   {
       public static Dictionary<int, Sprite> Sprites;
       public static void Init()
       {
           Sprites = new Dictionary<int, Sprite>
           {
                 { 0, new Sprite(new byte[,] { { 85, 0, }, { 85, 0, }, { 85, 0, }, { 85, 0, }, { 0, 85, }, { 0, 85, }, { 0, 85, }, { 0, 85, }, }, new byte[,] { { 255, }, { 255, }, { 255, }, { 255, }, { 255, }, { 255, }, { 255, }, { 255, }, })},
           };
       }
   }
}
