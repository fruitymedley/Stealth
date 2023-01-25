using System;
using System.Collections.Generic;
using System.Text;
using Stealth;

namespace Stealth.Assets
{
   class Ceiling
   {
       public static Sprite[] Sprites;
       public static void Init()
       {
           Sprites = new Sprite[]
           {
                 new Sprite(new byte[,] { { 255, 170, }, { 255, 170, }, { 255, 170, }, { 255, 170, }, { 170, 255, }, { 170, 255, }, { 170, 255, }, { 170, 255, }, }, new byte[,] { { 255, }, { 255, }, { 255, }, { 255, }, { 255, }, { 255, }, { 255, }, { 255, }, }),
           };
       }
   }
}
