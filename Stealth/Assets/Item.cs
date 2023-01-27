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
                 { 0, new Sprite(new byte[,] { { 0, 0, 0, 0, }, { 0, 0, 0, 0, }, { 0, 0, 0, 0, }, { 0, 0, 0, 0, }, { 0, 0, 0, 0, }, { 0, 0, 0, 0, }, { 0, 0, 0, 0, }, { 0, 0, 0, 0, }, { 0, 0, 0, 0, }, { 0, 0, 0, 0, }, { 0, 0, 0, 0, }, { 0, 0, 0, 0, }, { 0, 0, 0, 0, }, { 0, 0, 0, 0, }, { 0, 0, 0, 0, }, { 0, 0, 0, 0, }, { 0, 0, 0, 0, }, { 0, 0, 0, 0, }, { 0, 0, 0, 0, }, { 0, 0, 0, 0, }, { 0, 0, 0, 0, }, { 0, 0, 0, 0, }, { 0, 0, 0, 0, }, { 0, 0, 0, 0, }, { 0, 0, 0, 0, }, { 0, 0, 0, 0, }, { 0, 0, 0, 0, }, { 0, 0, 0, 0, }, { 0, 0, 0, 0, }, { 0, 0, 0, 0, }, { 0, 0, 0, 0, }, { 0, 0, 0, 0, }, { 0, 0, 0, 0, }, { 0, 0, 0, 0, }, { 0, 0, 0, 0, }, { 0, 0, 0, 0, }, { 0, 0, 0, 0, }, { 0, 0, 0, 0, }, { 0, 0, 0, 0, }, { 0, 0, 0, 0, }, { 0, 0, 0, 0, }, { 0, 0, 0, 0, }, { 0, 0, 0, 0, }, { 0, 0, 0, 0, }, { 0, 0, 0, 0, }, { 0, 0, 0, 0, }, { 0, 0, 0, 0, }, { 0, 0, 0, 0, }, { 0, 0, 0, 0, }, { 2, 164, 26, 128, }, { 10, 169, 106, 160, }, { 42, 170, 170, 168, }, { 170, 170, 170, 234, }, { 170, 170, 175, 170, }, { 170, 170, 170, 170, }, { 170, 170, 170, 170, }, { 42, 170, 170, 164, }, { 25, 170, 170, 152, }, { 6, 102, 166, 96, }, { 9, 153, 153, 144, }, { 2, 102, 102, 64, }, { 1, 153, 153, 128, }, { 0, 85, 85, 0, }, { 0, 20, 20, 0, }, }, new byte[,] { { 0, 0, }, { 0, 0, }, { 0, 0, }, { 0, 0, }, { 0, 0, }, { 0, 0, }, { 0, 0, }, { 0, 0, }, { 0, 0, }, { 0, 0, }, { 0, 0, }, { 0, 0, }, { 0, 0, }, { 0, 0, }, { 0, 0, }, { 0, 0, }, { 0, 0, }, { 0, 0, }, { 0, 0, }, { 0, 0, }, { 0, 0, }, { 0, 0, }, { 0, 0, }, { 0, 0, }, { 0, 0, }, { 0, 0, }, { 0, 0, }, { 0, 0, }, { 0, 0, }, { 0, 0, }, { 0, 0, }, { 0, 0, }, { 0, 0, }, { 0, 0, }, { 0, 0, }, { 0, 0, }, { 0, 0, }, { 0, 0, }, { 0, 0, }, { 0, 0, }, { 0, 0, }, { 0, 0, }, { 0, 0, }, { 0, 0, }, { 0, 0, }, { 0, 0, }, { 3, 0, }, { 1, 128, }, { 1, 128, }, { 31, 248, }, { 63, 252, }, { 127, 254, }, { 255, 255, }, { 255, 255, }, { 255, 255, }, { 255, 255, }, { 127, 254, }, { 127, 254, }, { 63, 252, }, { 63, 252, }, { 31, 248, }, { 31, 248, }, { 15, 240, }, { 6, 96, }, })},
                 { 1, new Sprite(new byte[,] { { 0, 4, 0, 0, }, { 0, 0, 16, 0, }, { 0, 4, 0, 0, }, { 0, 0, 16, 0, }, { 0, 4, 0, 0, }, { 0, 0, 16, 0, }, { 0, 4, 0, 0, }, { 0, 0, 16, 0, }, { 0, 4, 0, 0, }, { 0, 0, 16, 0, }, { 0, 4, 0, 0, }, { 0, 0, 16, 0, }, { 0, 4, 0, 0, }, { 0, 0, 16, 0, }, { 0, 4, 0, 0, }, { 0, 0, 16, 0, }, { 0, 4, 0, 0, }, { 0, 0, 16, 0, }, { 0, 4, 0, 0, }, { 0, 0, 16, 0, }, { 0, 4, 0, 0, }, { 0, 0, 16, 0, }, { 0, 4, 0, 0, }, { 0, 0, 16, 0, }, { 0, 4, 0, 0, }, { 0, 0, 16, 0, }, { 0, 4, 0, 0, }, { 0, 0, 16, 0, }, { 0, 4, 0, 0, }, { 0, 0, 16, 0, }, { 0, 4, 0, 0, }, { 0, 0, 16, 0, }, { 0, 4, 0, 0, }, { 0, 0, 16, 0, }, { 0, 4, 0, 0, }, { 0, 0, 16, 0, }, { 0, 4, 0, 0, }, { 0, 0, 16, 0, }, { 0, 4, 0, 0, }, { 0, 0, 16, 0, }, { 0, 4, 0, 0, }, { 0, 0, 16, 0, }, { 0, 4, 0, 0, }, { 0, 0, 16, 0, }, { 0, 4, 0, 0, }, { 0, 0, 16, 0, }, { 0, 4, 0, 0, }, { 0, 0, 16, 0, }, { 0, 4, 0, 0, }, { 0, 0, 16, 0, }, { 0, 4, 0, 0, }, { 0, 0, 16, 0, }, { 0, 4, 0, 0, }, { 0, 0, 16, 0, }, { 0, 4, 0, 0, }, { 0, 0, 16, 0, }, { 0, 4, 0, 0, }, { 0, 0, 16, 0, }, { 0, 4, 0, 0, }, { 0, 0, 16, 0, }, { 0, 4, 0, 0, }, { 0, 0, 16, 0, }, { 0, 4, 0, 0, }, { 0, 0, 16, 0, }, }, new byte[,] { { 3, 192, }, { 3, 192, }, { 3, 192, }, { 3, 192, }, { 3, 192, }, { 3, 192, }, { 3, 192, }, { 3, 192, }, { 3, 192, }, { 3, 192, }, { 3, 192, }, { 3, 192, }, { 3, 192, }, { 3, 192, }, { 3, 192, }, { 3, 192, }, { 3, 192, }, { 3, 192, }, { 3, 192, }, { 3, 192, }, { 3, 192, }, { 3, 192, }, { 3, 192, }, { 3, 192, }, { 3, 192, }, { 3, 192, }, { 3, 192, }, { 3, 192, }, { 3, 192, }, { 3, 192, }, { 3, 192, }, { 3, 192, }, { 3, 192, }, { 3, 192, }, { 3, 192, }, { 3, 192, }, { 3, 192, }, { 3, 192, }, { 3, 192, }, { 3, 192, }, { 3, 192, }, { 3, 192, }, { 3, 192, }, { 3, 192, }, { 3, 192, }, { 3, 192, }, { 3, 192, }, { 3, 192, }, { 3, 192, }, { 3, 192, }, { 3, 192, }, { 3, 192, }, { 3, 192, }, { 3, 192, }, { 3, 192, }, { 3, 192, }, { 3, 192, }, { 3, 192, }, { 3, 192, }, { 3, 192, }, { 3, 192, }, { 3, 192, }, { 3, 192, }, { 3, 192, }, })},
                 { 2, new Sprite(new byte[,] { { 0, 170, 170, 0, }, { 10, 255, 255, 160, }, { 47, 255, 255, 248, }, { 10, 255, 255, 160, }, { 0, 170, 170, 0, }, { 0, 0, 0, 0, }, { 0, 0, 0, 0, }, { 0, 0, 0, 0, }, { 0, 0, 0, 0, }, { 0, 0, 0, 0, }, { 0, 0, 0, 0, }, { 0, 0, 0, 0, }, { 0, 0, 0, 0, }, { 0, 0, 0, 0, }, { 0, 0, 0, 0, }, { 0, 0, 0, 0, }, { 0, 0, 0, 0, }, { 0, 0, 0, 0, }, { 0, 0, 0, 0, }, { 0, 0, 0, 0, }, { 0, 0, 0, 0, }, { 0, 0, 0, 0, }, { 0, 0, 0, 0, }, { 0, 0, 0, 0, }, { 0, 0, 0, 0, }, { 0, 0, 0, 0, }, { 0, 0, 0, 0, }, { 0, 0, 0, 0, }, { 0, 0, 0, 0, }, { 0, 0, 0, 0, }, { 0, 0, 0, 0, }, { 0, 0, 0, 0, }, { 0, 0, 0, 0, }, { 0, 0, 0, 0, }, { 0, 0, 0, 0, }, { 0, 0, 0, 0, }, { 0, 0, 0, 0, }, { 0, 0, 0, 0, }, { 0, 0, 0, 0, }, { 0, 0, 0, 0, }, { 0, 0, 0, 0, }, { 0, 0, 0, 0, }, { 0, 0, 0, 0, }, { 0, 0, 0, 0, }, { 0, 0, 0, 0, }, { 0, 0, 0, 0, }, { 0, 0, 0, 0, }, { 0, 0, 0, 0, }, { 0, 0, 0, 0, }, { 0, 0, 0, 0, }, { 0, 0, 0, 0, }, { 0, 0, 0, 0, }, { 0, 0, 0, 0, }, { 0, 0, 0, 0, }, { 0, 0, 0, 0, }, { 0, 0, 0, 0, }, { 0, 0, 0, 0, }, { 0, 0, 0, 0, }, { 0, 0, 0, 0, }, { 0, 0, 0, 0, }, { 0, 0, 0, 0, }, { 0, 0, 0, 0, }, { 0, 0, 0, 0, }, { 0, 0, 0, 0, }, }, new byte[,] { { 15, 240, }, { 63, 252, }, { 127, 254, }, { 63, 252, }, { 15, 240, }, { 0, 0, }, { 0, 0, }, { 0, 0, }, { 0, 0, }, { 0, 0, }, { 0, 0, }, { 0, 0, }, { 0, 0, }, { 0, 0, }, { 0, 0, }, { 0, 0, }, { 0, 0, }, { 0, 0, }, { 0, 0, }, { 0, 0, }, { 0, 0, }, { 0, 0, }, { 0, 0, }, { 0, 0, }, { 0, 0, }, { 0, 0, }, { 0, 0, }, { 0, 0, }, { 0, 0, }, { 0, 0, }, { 0, 0, }, { 0, 0, }, { 0, 0, }, { 0, 0, }, { 0, 0, }, { 0, 0, }, { 0, 0, }, { 0, 0, }, { 0, 0, }, { 0, 0, }, { 0, 0, }, { 0, 0, }, { 0, 0, }, { 0, 0, }, { 0, 0, }, { 0, 0, }, { 0, 0, }, { 0, 0, }, { 0, 0, }, { 0, 0, }, { 0, 0, }, { 0, 0, }, { 0, 0, }, { 0, 0, }, { 0, 0, }, { 0, 0, }, { 0, 0, }, { 0, 0, }, { 0, 0, }, { 0, 0, }, { 0, 0, }, { 0, 0, }, { 0, 0, }, { 0, 0, }, })},
                 { 3, new Sprite(new byte[,] { { 0, 1, 80, 0, }, { 0, 5, 64, 0, }, { 0, 1, 80, 0, }, { 0, 5, 64, 0, }, { 0, 1, 80, 0, }, { 0, 5, 64, 0, }, { 0, 1, 80, 0, }, { 0, 5, 64, 0, }, { 0, 1, 80, 0, }, { 0, 5, 64, 0, }, { 0, 1, 80, 0, }, { 0, 5, 64, 0, }, { 0, 1, 80, 0, }, { 0, 5, 64, 0, }, { 0, 1, 80, 0, }, { 0, 5, 64, 0, }, { 0, 1, 80, 0, }, { 0, 5, 64, 0, }, { 0, 1, 80, 0, }, { 0, 5, 64, 0, }, { 0, 1, 80, 0, }, { 0, 5, 64, 0, }, { 0, 1, 80, 0, }, { 0, 5, 64, 0, }, { 0, 1, 80, 0, }, { 0, 5, 64, 0, }, { 0, 1, 80, 0, }, { 0, 5, 64, 0, }, { 0, 1, 80, 0, }, { 0, 5, 64, 0, }, { 0, 1, 80, 0, }, { 0, 5, 64, 0, }, { 0, 1, 80, 0, }, { 0, 5, 64, 0, }, { 0, 1, 80, 0, }, { 0, 5, 64, 0, }, { 0, 1, 80, 0, }, { 0, 5, 64, 0, }, { 0, 1, 80, 0, }, { 0, 5, 64, 0, }, { 0, 1, 80, 0, }, { 0, 5, 64, 0, }, { 0, 1, 80, 0, }, { 0, 5, 64, 0, }, { 0, 1, 80, 0, }, { 0, 5, 64, 0, }, { 0, 1, 80, 0, }, { 0, 5, 64, 0, }, { 0, 1, 80, 0, }, { 0, 5, 64, 0, }, { 0, 1, 80, 0, }, { 0, 5, 64, 0, }, { 0, 1, 80, 0, }, { 0, 5, 64, 0, }, { 0, 1, 80, 0, }, { 0, 5, 64, 0, }, { 0, 1, 80, 0, }, { 0, 5, 64, 0, }, { 0, 1, 80, 0, }, { 0, 5, 64, 0, }, { 0, 1, 80, 0, }, { 0, 5, 64, 0, }, { 0, 1, 80, 0, }, { 0, 5, 64, 0, }, }, new byte[,] { { 3, 192, }, { 3, 192, }, { 3, 192, }, { 3, 192, }, { 3, 192, }, { 3, 192, }, { 3, 192, }, { 3, 192, }, { 3, 192, }, { 3, 192, }, { 3, 192, }, { 3, 192, }, { 3, 192, }, { 3, 192, }, { 3, 192, }, { 3, 192, }, { 3, 192, }, { 3, 192, }, { 3, 192, }, { 3, 192, }, { 3, 192, }, { 3, 192, }, { 3, 192, }, { 3, 192, }, { 3, 192, }, { 3, 192, }, { 3, 192, }, { 3, 192, }, { 3, 192, }, { 3, 192, }, { 3, 192, }, { 3, 192, }, { 3, 192, }, { 3, 192, }, { 3, 192, }, { 3, 192, }, { 3, 192, }, { 3, 192, }, { 3, 192, }, { 3, 192, }, { 3, 192, }, { 3, 192, }, { 3, 192, }, { 3, 192, }, { 3, 192, }, { 3, 192, }, { 3, 192, }, { 3, 192, }, { 3, 192, }, { 3, 192, }, { 3, 192, }, { 3, 192, }, { 3, 192, }, { 3, 192, }, { 3, 192, }, { 3, 192, }, { 3, 192, }, { 3, 192, }, { 3, 192, }, { 3, 192, }, { 3, 192, }, { 3, 192, }, { 3, 192, }, { 3, 192, }, })},
                 { 4, new Sprite(new byte[,] { { 0, 0, 0, 0, }, { 0, 0, 0, 0, }, { 0, 0, 0, 0, }, { 0, 0, 0, 0, }, { 0, 0, 0, 0, }, { 0, 0, 0, 0, }, { 0, 0, 0, 0, }, { 0, 0, 0, 0, }, { 0, 0, 0, 0, }, { 0, 0, 0, 0, }, { 0, 0, 0, 0, }, { 0, 0, 0, 0, }, { 0, 0, 0, 0, }, { 0, 0, 0, 0, }, { 0, 0, 0, 0, }, { 0, 0, 0, 0, }, { 0, 0, 0, 0, }, { 0, 0, 0, 0, }, { 0, 0, 0, 0, }, { 0, 0, 0, 0, }, { 0, 0, 0, 0, }, { 0, 0, 0, 0, }, { 0, 0, 0, 0, }, { 0, 0, 0, 0, }, { 0, 0, 0, 0, }, { 0, 0, 0, 0, }, { 0, 0, 0, 0, }, { 0, 0, 0, 0, }, { 0, 0, 0, 0, }, { 0, 0, 0, 0, }, { 0, 0, 0, 0, }, { 0, 0, 0, 0, }, { 0, 0, 0, 0, }, { 0, 0, 0, 0, }, { 0, 0, 0, 0, }, { 0, 0, 0, 0, }, { 0, 0, 0, 0, }, { 0, 0, 0, 0, }, { 0, 0, 0, 0, }, { 0, 0, 0, 0, }, { 0, 0, 0, 0, }, { 0, 0, 0, 0, }, { 0, 0, 0, 0, }, { 0, 0, 0, 0, }, { 0, 0, 0, 0, }, { 0, 0, 0, 0, }, { 0, 0, 0, 0, }, { 0, 0, 0, 0, }, { 0, 0, 0, 0, }, { 0, 0, 0, 0, }, { 0, 0, 0, 0, }, { 0, 0, 0, 0, }, { 0, 0, 0, 0, }, { 0, 0, 0, 0, }, { 0, 0, 0, 0, }, { 0, 0, 0, 0, }, { 0, 0, 0, 0, }, { 0, 0, 0, 0, }, { 0, 0, 0, 0, }, { 0, 0, 0, 0, }, { 0, 0, 0, 0, }, { 0, 0, 0, 0, }, { 0, 0, 0, 0, }, { 0, 0, 0, 0, }, }, new byte[,] { { 255, 255, }, { 255, 255, }, { 255, 255, }, { 255, 255, }, { 255, 255, }, { 255, 255, }, { 255, 255, }, { 255, 255, }, { 255, 255, }, { 255, 255, }, { 255, 255, }, { 255, 255, }, { 255, 255, }, { 255, 255, }, { 255, 255, }, { 255, 255, }, { 255, 255, }, { 255, 255, }, { 255, 255, }, { 255, 255, }, { 255, 255, }, { 255, 255, }, { 255, 255, }, { 255, 255, }, { 255, 255, }, { 255, 255, }, { 255, 255, }, { 255, 255, }, { 255, 255, }, { 255, 255, }, { 255, 255, }, { 255, 255, }, { 255, 255, }, { 255, 255, }, { 255, 255, }, { 255, 255, }, { 255, 255, }, { 255, 255, }, { 255, 255, }, { 255, 255, }, { 255, 255, }, { 255, 255, }, { 255, 255, }, { 255, 255, }, { 255, 255, }, { 255, 255, }, { 255, 255, }, { 255, 255, }, { 255, 255, }, { 255, 255, }, { 255, 255, }, { 255, 255, }, { 255, 255, }, { 255, 255, }, { 255, 255, }, { 255, 255, }, { 255, 255, }, { 255, 255, }, { 255, 255, }, { 255, 255, }, { 255, 255, }, { 255, 255, }, { 255, 255, }, { 255, 255, }, })},
                 { 5, new Sprite(new byte[,] { { 0, 0, 0, 0, }, { 0, 0, 0, 0, }, { 0, 0, 0, 0, }, { 0, 0, 0, 0, }, { 0, 0, 0, 0, }, { 0, 0, 0, 0, }, { 0, 0, 0, 0, }, { 0, 0, 0, 0, }, { 0, 0, 0, 0, }, { 0, 0, 0, 0, }, { 0, 0, 0, 0, }, { 0, 0, 0, 0, }, { 0, 0, 0, 0, }, { 0, 0, 0, 0, }, { 0, 0, 0, 0, }, { 0, 0, 0, 0, }, { 0, 0, 0, 0, }, { 0, 0, 0, 0, }, { 0, 0, 0, 0, }, { 0, 0, 0, 0, }, { 0, 0, 0, 0, }, { 0, 0, 21, 85, }, { 0, 0, 21, 85, }, { 0, 0, 21, 85, }, { 0, 0, 21, 85, }, { 0, 0, 21, 85, }, { 0, 0, 21, 85, }, { 0, 0, 21, 85, }, { 0, 0, 21, 85, }, { 0, 0, 21, 85, }, { 0, 0, 21, 85, }, { 0, 0, 21, 85, }, { 0, 0, 21, 85, }, { 0, 0, 21, 85, }, { 0, 0, 0, 0, }, { 0, 4, 81, 85, }, { 1, 17, 21, 21, }, { 68, 68, 81, 86, }, { 0, 0, 0, 1, }, { 0, 0, 0, 1, }, { 0, 0, 0, 0, }, { 0, 0, 0, 1, }, { 0, 0, 0, 0, }, { 0, 0, 0, 1, }, { 0, 0, 0, 0, }, { 0, 0, 0, 0, }, { 0, 0, 0, 0, }, { 0, 0, 0, 0, }, { 0, 0, 0, 0, }, { 0, 0, 0, 0, }, { 0, 0, 0, 0, }, { 0, 0, 0, 0, }, { 0, 0, 0, 0, }, { 0, 0, 0, 0, }, { 0, 0, 0, 0, }, { 0, 0, 0, 0, }, { 0, 0, 0, 0, }, { 0, 0, 0, 0, }, { 0, 0, 0, 0, }, { 0, 0, 0, 0, }, { 0, 0, 0, 0, }, { 0, 0, 0, 0, }, { 0, 0, 0, 0, }, { 0, 0, 0, 0, }, }, new byte[,] { { 0, 0, }, { 0, 0, }, { 0, 0, }, { 0, 0, }, { 0, 0, }, { 0, 0, }, { 0, 0, }, { 0, 0, }, { 0, 0, }, { 0, 0, }, { 0, 0, }, { 0, 0, }, { 0, 0, }, { 0, 0, }, { 0, 0, }, { 0, 0, }, { 0, 0, }, { 0, 0, }, { 0, 0, }, { 0, 0, }, { 0, 0, }, { 0, 127, }, { 0, 127, }, { 0, 127, }, { 0, 127, }, { 0, 127, }, { 0, 127, }, { 0, 127, }, { 0, 127, }, { 0, 127, }, { 0, 127, }, { 0, 127, }, { 0, 127, }, { 0, 127, }, { 0, 127, }, { 3, 255, }, { 31, 255, }, { 255, 255, }, { 255, 255, }, { 255, 255, }, { 255, 255, }, { 255, 255, }, { 255, 255, }, { 255, 255, }, { 255, 255, }, { 255, 255, }, { 255, 255, }, { 255, 255, }, { 255, 255, }, { 255, 255, }, { 255, 255, }, { 255, 255, }, { 255, 255, }, { 255, 255, }, { 255, 255, }, { 255, 255, }, { 255, 255, }, { 255, 255, }, { 255, 255, }, { 255, 255, }, { 255, 255, }, { 255, 255, }, { 255, 255, }, { 255, 254, }, })},
                 { 6, new Sprite(new byte[,] { { 0, 4, 0, 0, }, { 0, 0, 16, 0, }, { 0, 4, 0, 0, }, { 0, 0, 16, 0, }, { 0, 4, 0, 0, }, { 0, 0, 16, 0, }, { 0, 4, 0, 0, }, { 0, 0, 16, 0, }, { 0, 4, 0, 0, }, { 0, 0, 16, 0, }, { 0, 4, 0, 0, }, { 0, 0, 16, 0, }, { 0, 4, 0, 0, }, { 0, 0, 16, 0, }, { 0, 4, 0, 0, }, { 0, 0, 16, 0, }, { 0, 4, 0, 0, }, { 0, 0, 16, 0, }, { 0, 4, 0, 0, }, { 0, 0, 16, 0, }, { 0, 4, 0, 0, }, { 85, 80, 16, 0, }, { 85, 84, 4, 0, }, { 85, 80, 20, 0, }, { 85, 84, 4, 0, }, { 85, 80, 20, 0, }, { 85, 84, 4, 0, }, { 85, 80, 20, 0, }, { 85, 84, 4, 0, }, { 85, 80, 20, 0, }, { 85, 84, 4, 0, }, { 85, 80, 20, 0, }, { 85, 84, 4, 0, }, { 85, 80, 20, 0, }, { 0, 4, 4, 0, }, { 90, 64, 20, 0, }, { 165, 68, 4, 0, }, { 85, 64, 25, 154, }, { 84, 100, 6, 105, }, { 69, 0, 16, 0, }, { 84, 4, 0, 0, }, { 64, 0, 16, 0, }, { 64, 4, 0, 0, }, { 0, 0, 16, 0, }, { 0, 4, 0, 0, }, { 0, 0, 16, 0, }, { 0, 4, 0, 0, }, { 0, 0, 16, 0, }, { 0, 4, 0, 0, }, { 0, 0, 16, 0, }, { 0, 4, 0, 0, }, { 0, 0, 16, 0, }, { 0, 4, 0, 0, }, { 0, 0, 16, 0, }, { 0, 4, 0, 0, }, { 0, 0, 16, 0, }, { 0, 4, 0, 0, }, { 0, 0, 16, 0, }, { 0, 4, 0, 0, }, { 0, 0, 16, 0, }, { 0, 4, 0, 0, }, { 0, 0, 16, 0, }, { 0, 4, 0, 0, }, { 0, 0, 16, 0, }, }, new byte[,] { { 3, 192, }, { 3, 192, }, { 3, 192, }, { 3, 192, }, { 3, 192, }, { 3, 192, }, { 3, 192, }, { 3, 192, }, { 3, 192, }, { 3, 192, }, { 3, 192, }, { 3, 192, }, { 3, 192, }, { 3, 192, }, { 3, 192, }, { 3, 192, }, { 3, 192, }, { 3, 192, }, { 3, 192, }, { 3, 192, }, { 3, 192, }, { 255, 192, }, { 255, 224, }, { 255, 224, }, { 255, 224, }, { 255, 224, }, { 255, 224, }, { 255, 224, }, { 255, 224, }, { 255, 224, }, { 255, 224, }, { 255, 224, }, { 255, 224, }, { 255, 224, }, { 255, 224, }, { 255, 224, }, { 255, 224, }, { 255, 255, }, { 255, 255, }, { 255, 255, }, { 255, 255, }, { 255, 255, }, { 255, 255, }, { 255, 255, }, { 255, 255, }, { 255, 255, }, { 255, 255, }, { 255, 255, }, { 255, 255, }, { 255, 255, }, { 255, 255, }, { 255, 255, }, { 255, 255, }, { 255, 255, }, { 255, 255, }, { 255, 255, }, { 255, 255, }, { 255, 255, }, { 255, 255, }, { 239, 255, }, { 195, 192, }, { 131, 192, }, { 3, 192, }, { 3, 192, }, })},
                 { 7, new Sprite(new byte[,] { { 0, 0, 0, 0, }, { 0, 0, 0, 0, }, { 0, 0, 0, 0, }, { 0, 0, 0, 0, }, { 0, 0, 0, 0, }, { 0, 0, 0, 0, }, { 0, 0, 0, 0, }, { 0, 0, 0, 0, }, { 0, 0, 0, 0, }, { 0, 0, 0, 0, }, { 0, 0, 0, 0, }, { 0, 0, 0, 0, }, { 0, 0, 0, 0, }, { 0, 0, 0, 0, }, { 0, 0, 0, 0, }, { 0, 0, 0, 0, }, { 0, 0, 0, 0, }, { 0, 0, 0, 0, }, { 0, 0, 0, 0, }, { 0, 0, 0, 0, }, { 0, 0, 0, 0, }, { 0, 0, 0, 0, }, { 0, 0, 0, 0, }, { 0, 0, 0, 0, }, { 0, 0, 0, 0, }, { 0, 0, 0, 0, }, { 0, 0, 0, 0, }, { 0, 0, 0, 0, }, { 0, 0, 0, 0, }, { 0, 0, 0, 0, }, { 0, 0, 0, 0, }, { 0, 0, 0, 0, }, { 0, 0, 0, 0, }, { 0, 0, 0, 0, }, { 0, 0, 0, 0, }, { 0, 0, 0, 0, }, { 0, 0, 0, 0, }, { 154, 170, 170, 175, }, { 170, 170, 170, 245, }, { 0, 0, 0, 85, }, { 0, 0, 0, 85, }, { 0, 0, 0, 85, }, { 0, 0, 0, 89, }, { 0, 0, 0, 98, }, { 0, 0, 0, 145, }, { 0, 0, 0, 132, }, { 0, 0, 0, 66, }, { 0, 0, 0, 40, }, { 0, 0, 0, 65, }, { 0, 0, 0, 68, }, { 0, 0, 0, 81, }, { 0, 0, 0, 68, }, { 0, 0, 0, 16, }, { 0, 0, 0, 68, }, { 0, 0, 0, 16, }, { 0, 0, 0, 64, }, { 0, 0, 0, 0, }, { 0, 0, 0, 64, }, { 0, 0, 0, 0, }, { 0, 0, 0, 0, }, { 0, 0, 0, 0, }, { 0, 0, 0, 0, }, { 0, 0, 0, 0, }, { 0, 0, 0, 0, }, }, new byte[,] { { 0, 0, }, { 0, 0, }, { 0, 0, }, { 0, 0, }, { 0, 0, }, { 0, 0, }, { 0, 0, }, { 0, 0, }, { 0, 0, }, { 0, 0, }, { 0, 0, }, { 0, 0, }, { 0, 0, }, { 0, 0, }, { 0, 0, }, { 0, 0, }, { 0, 0, }, { 0, 0, }, { 0, 0, }, { 0, 0, }, { 0, 0, }, { 0, 0, }, { 0, 0, }, { 0, 0, }, { 0, 0, }, { 0, 0, }, { 0, 0, }, { 0, 0, }, { 0, 0, }, { 0, 0, }, { 0, 0, }, { 0, 0, }, { 0, 0, }, { 0, 0, }, { 0, 0, }, { 0, 0, }, { 0, 0, }, { 255, 255, }, { 255, 255, }, { 255, 255, }, { 255, 255, }, { 255, 255, }, { 255, 255, }, { 255, 255, }, { 255, 255, }, { 255, 255, }, { 255, 255, }, { 255, 255, }, { 255, 255, }, { 255, 255, }, { 255, 255, }, { 255, 255, }, { 255, 254, }, { 255, 254, }, { 255, 252, }, { 255, 252, }, { 255, 248, }, { 255, 248, }, { 255, 240, }, { 255, 240, }, { 0, 0, }, { 0, 0, }, { 0, 0, }, { 0, 0, }, })},
                 { 8, new Sprite(new byte[,] { { 0, 0, 0, 0, }, { 0, 0, 0, 0, }, { 0, 0, 0, 0, }, { 0, 0, 0, 0, }, { 0, 0, 0, 0, }, { 0, 0, 0, 0, }, { 0, 0, 0, 0, }, { 0, 0, 0, 0, }, { 0, 0, 0, 0, }, { 0, 0, 0, 0, }, { 0, 0, 0, 0, }, { 0, 0, 0, 0, }, { 0, 0, 0, 0, }, { 0, 0, 0, 0, }, { 0, 0, 0, 0, }, { 0, 0, 0, 0, }, { 0, 0, 0, 0, }, { 0, 0, 0, 0, }, { 0, 0, 0, 0, }, { 0, 0, 0, 0, }, { 0, 0, 0, 0, }, { 0, 0, 0, 0, }, { 0, 0, 0, 0, }, { 0, 0, 0, 0, }, { 0, 0, 0, 0, }, { 0, 0, 0, 0, }, { 0, 0, 0, 0, }, { 0, 0, 0, 0, }, { 0, 0, 0, 0, }, { 0, 0, 0, 0, }, { 0, 0, 0, 0, }, { 0, 0, 0, 0, }, { 0, 0, 0, 0, }, { 0, 0, 0, 0, }, { 0, 0, 0, 0, }, { 0, 0, 0, 0, }, { 0, 0, 0, 0, }, { 0, 0, 0, 0, }, { 0, 0, 0, 0, }, { 0, 0, 0, 0, }, { 0, 4, 68, 68, }, { 0, 1, 17, 17, }, { 0, 0, 0, 0, }, { 0, 0, 0, 0, }, { 0, 0, 0, 0, }, { 0, 0, 0, 0, }, { 0, 0, 0, 0, }, { 0, 0, 0, 0, }, { 0, 0, 0, 0, }, { 0, 0, 0, 0, }, { 0, 0, 0, 0, }, { 0, 0, 0, 0, }, { 0, 0, 0, 0, }, { 0, 0, 0, 0, }, { 0, 0, 0, 0, }, { 0, 0, 0, 0, }, { 0, 0, 0, 0, }, { 0, 0, 0, 0, }, { 0, 0, 0, 0, }, { 0, 0, 0, 0, }, { 0, 0, 0, 0, }, { 0, 0, 0, 0, }, { 0, 0, 0, 0, }, { 0, 0, 0, 0, }, }, new byte[,] { { 0, 0, }, { 0, 0, }, { 0, 0, }, { 0, 0, }, { 0, 0, }, { 0, 0, }, { 0, 0, }, { 0, 0, }, { 0, 0, }, { 0, 0, }, { 0, 0, }, { 0, 0, }, { 0, 0, }, { 0, 0, }, { 0, 0, }, { 0, 0, }, { 0, 0, }, { 0, 0, }, { 0, 0, }, { 0, 0, }, { 0, 0, }, { 0, 0, }, { 0, 0, }, { 0, 0, }, { 0, 0, }, { 0, 0, }, { 0, 0, }, { 0, 0, }, { 0, 0, }, { 0, 0, }, { 0, 0, }, { 0, 0, }, { 0, 0, }, { 0, 0, }, { 0, 0, }, { 0, 0, }, { 0, 0, }, { 0, 0, }, { 0, 0, }, { 0, 0, }, { 3, 255, }, { 3, 255, }, { 3, 255, }, { 3, 255, }, { 3, 255, }, { 3, 255, }, { 3, 255, }, { 3, 255, }, { 3, 255, }, { 3, 255, }, { 3, 255, }, { 3, 255, }, { 3, 255, }, { 3, 255, }, { 3, 255, }, { 3, 255, }, { 3, 255, }, { 3, 255, }, { 3, 255, }, { 3, 255, }, { 3, 255, }, { 3, 255, }, { 3, 255, }, { 3, 255, }, })},
                 { 9, new Sprite(new byte[,] { { 0, 0, 0, 0, }, { 0, 0, 0, 0, }, { 0, 0, 0, 0, }, { 0, 0, 0, 0, }, { 0, 0, 0, 0, }, { 0, 0, 0, 0, }, { 0, 0, 0, 0, }, { 0, 0, 0, 0, }, { 0, 0, 0, 0, }, { 0, 0, 0, 0, }, { 0, 0, 0, 0, }, { 0, 0, 0, 0, }, { 0, 0, 0, 0, }, { 0, 0, 0, 0, }, { 0, 0, 0, 0, }, { 0, 0, 0, 0, }, { 0, 0, 0, 0, }, { 0, 0, 0, 0, }, { 0, 0, 0, 0, }, { 0, 0, 0, 0, }, { 0, 0, 0, 0, }, { 0, 0, 0, 0, }, { 0, 0, 0, 0, }, { 0, 0, 0, 0, }, { 0, 0, 0, 0, }, { 0, 0, 0, 0, }, { 0, 0, 0, 0, }, { 0, 0, 0, 0, }, { 0, 0, 0, 0, }, { 0, 0, 0, 0, }, { 0, 0, 0, 0, }, { 0, 0, 0, 0, }, { 0, 0, 0, 0, }, { 0, 0, 0, 0, }, { 0, 0, 0, 0, }, { 0, 0, 0, 0, }, { 0, 0, 0, 0, }, { 0, 0, 0, 0, }, { 0, 0, 0, 0, }, { 0, 0, 0, 0, }, { 68, 68, 68, 68, }, { 17, 17, 17, 17, }, { 0, 0, 0, 0, }, { 0, 0, 0, 0, }, { 0, 0, 0, 0, }, { 0, 0, 0, 0, }, { 0, 0, 0, 0, }, { 0, 0, 0, 0, }, { 0, 0, 0, 0, }, { 0, 0, 0, 0, }, { 0, 0, 0, 0, }, { 0, 0, 0, 0, }, { 0, 0, 0, 0, }, { 0, 0, 0, 0, }, { 0, 0, 0, 0, }, { 0, 0, 0, 0, }, { 0, 0, 0, 0, }, { 0, 0, 0, 0, }, { 0, 0, 0, 0, }, { 0, 0, 0, 0, }, { 0, 0, 0, 0, }, { 0, 0, 0, 0, }, { 0, 0, 0, 0, }, { 0, 0, 0, 0, }, }, new byte[,] { { 0, 0, }, { 0, 0, }, { 0, 0, }, { 0, 0, }, { 0, 0, }, { 0, 0, }, { 0, 0, }, { 0, 0, }, { 0, 0, }, { 0, 0, }, { 0, 0, }, { 0, 0, }, { 0, 0, }, { 0, 0, }, { 0, 0, }, { 0, 0, }, { 0, 0, }, { 0, 0, }, { 0, 0, }, { 0, 0, }, { 0, 0, }, { 0, 0, }, { 0, 0, }, { 0, 0, }, { 0, 0, }, { 0, 0, }, { 0, 0, }, { 0, 0, }, { 0, 0, }, { 0, 0, }, { 0, 0, }, { 0, 0, }, { 0, 0, }, { 0, 0, }, { 0, 0, }, { 0, 0, }, { 0, 0, }, { 0, 0, }, { 0, 0, }, { 0, 0, }, { 255, 255, }, { 255, 255, }, { 255, 255, }, { 255, 255, }, { 255, 255, }, { 255, 255, }, { 255, 255, }, { 255, 255, }, { 255, 255, }, { 255, 255, }, { 255, 255, }, { 255, 255, }, { 255, 255, }, { 255, 255, }, { 255, 255, }, { 255, 255, }, { 255, 255, }, { 255, 255, }, { 255, 255, }, { 255, 255, }, { 255, 255, }, { 255, 255, }, { 255, 255, }, { 255, 255, }, })},
                 { 10, new Sprite(new byte[,] { { 0, 0, 0, 0, }, { 0, 0, 0, 0, }, { 0, 0, 0, 0, }, { 0, 0, 0, 0, }, { 0, 0, 0, 0, }, { 0, 0, 0, 0, }, { 0, 0, 0, 0, }, { 0, 0, 0, 0, }, { 0, 0, 0, 0, }, { 0, 0, 0, 0, }, { 0, 0, 0, 0, }, { 0, 0, 0, 0, }, { 0, 0, 0, 0, }, { 0, 0, 0, 0, }, { 0, 0, 0, 0, }, { 0, 0, 0, 0, }, { 0, 0, 0, 0, }, { 0, 0, 0, 0, }, { 0, 0, 0, 0, }, { 0, 0, 0, 0, }, { 0, 0, 0, 0, }, { 0, 0, 0, 0, }, { 0, 0, 0, 0, }, { 0, 0, 0, 0, }, { 0, 0, 0, 0, }, { 0, 0, 0, 0, }, { 0, 0, 0, 0, }, { 0, 0, 0, 0, }, { 0, 0, 0, 0, }, { 0, 0, 0, 0, }, { 0, 0, 0, 0, }, { 0, 0, 0, 0, }, { 0, 0, 0, 0, }, { 0, 0, 0, 0, }, { 0, 0, 0, 0, }, { 0, 0, 0, 0, }, { 0, 0, 0, 0, }, { 0, 0, 0, 0, }, { 0, 0, 0, 0, }, { 0, 0, 0, 0, }, { 68, 68, 64, 0, }, { 17, 17, 16, 0, }, { 0, 0, 0, 0, }, { 0, 0, 0, 0, }, { 0, 0, 0, 0, }, { 0, 0, 0, 0, }, { 0, 0, 0, 0, }, { 0, 0, 0, 0, }, { 0, 0, 0, 0, }, { 0, 0, 0, 0, }, { 0, 0, 0, 0, }, { 0, 0, 0, 0, }, { 0, 0, 0, 0, }, { 0, 0, 0, 0, }, { 0, 0, 0, 0, }, { 0, 0, 0, 0, }, { 0, 0, 0, 0, }, { 0, 0, 0, 0, }, { 0, 0, 0, 0, }, { 0, 0, 0, 0, }, { 0, 0, 0, 0, }, { 0, 0, 0, 0, }, { 0, 0, 0, 0, }, { 0, 0, 0, 0, }, }, new byte[,] { { 0, 0, }, { 0, 0, }, { 0, 0, }, { 0, 0, }, { 0, 0, }, { 0, 0, }, { 0, 0, }, { 0, 0, }, { 0, 0, }, { 0, 0, }, { 0, 0, }, { 0, 0, }, { 0, 0, }, { 0, 0, }, { 0, 0, }, { 0, 0, }, { 0, 0, }, { 0, 0, }, { 0, 0, }, { 0, 0, }, { 0, 0, }, { 0, 0, }, { 0, 0, }, { 0, 0, }, { 0, 0, }, { 0, 0, }, { 0, 0, }, { 0, 0, }, { 0, 0, }, { 0, 0, }, { 0, 0, }, { 0, 0, }, { 0, 0, }, { 0, 0, }, { 0, 0, }, { 0, 0, }, { 0, 0, }, { 0, 0, }, { 0, 0, }, { 0, 0, }, { 255, 192, }, { 255, 192, }, { 255, 192, }, { 255, 192, }, { 255, 192, }, { 255, 192, }, { 255, 192, }, { 255, 192, }, { 255, 192, }, { 255, 192, }, { 255, 192, }, { 255, 192, }, { 255, 192, }, { 255, 192, }, { 255, 192, }, { 255, 192, }, { 255, 192, }, { 255, 192, }, { 255, 192, }, { 255, 192, }, { 255, 192, }, { 255, 192, }, { 255, 192, }, { 255, 192, }, })},
                 { 11, new Sprite(new byte[,] { { 0, 0, 0, 0, }, { 0, 0, 0, 0, }, { 0, 0, 0, 0, }, { 0, 0, 0, 0, }, { 0, 0, 0, 0, }, { 0, 0, 0, 0, }, { 0, 0, 0, 0, }, { 0, 0, 0, 0, }, { 0, 0, 0, 0, }, { 0, 0, 0, 0, }, { 0, 0, 0, 0, }, { 0, 0, 0, 0, }, { 0, 0, 0, 0, }, { 0, 0, 0, 0, }, { 0, 0, 0, 0, }, { 0, 0, 0, 0, }, { 0, 0, 0, 0, }, { 0, 0, 0, 0, }, { 0, 0, 0, 0, }, { 0, 0, 0, 0, }, { 0, 0, 0, 0, }, { 0, 0, 0, 0, }, { 0, 0, 0, 0, }, { 0, 0, 0, 0, }, { 0, 0, 0, 0, }, { 0, 0, 0, 0, }, { 0, 0, 0, 0, }, { 0, 0, 0, 0, }, { 0, 0, 0, 0, }, { 0, 0, 0, 0, }, { 0, 0, 0, 0, }, { 0, 0, 0, 0, }, { 0, 0, 0, 0, }, { 0, 0, 0, 0, }, { 0, 0, 0, 0, }, { 0, 0, 0, 0, }, { 0, 0, 0, 0, }, { 0, 0, 0, 0, }, { 0, 0, 0, 0, }, { 0, 0, 0, 0, }, { 0, 0, 0, 0, }, { 0, 0, 0, 0, }, { 0, 4, 68, 68, }, { 0, 1, 17, 17, }, { 0, 4, 68, 68, }, { 0, 1, 17, 17, }, { 0, 4, 68, 68, }, { 0, 1, 17, 17, }, { 0, 4, 68, 68, }, { 0, 1, 17, 17, }, { 0, 4, 68, 68, }, { 0, 1, 17, 17, }, { 0, 4, 68, 68, }, { 0, 1, 17, 17, }, { 0, 4, 68, 68, }, { 0, 1, 17, 17, }, { 0, 4, 68, 68, }, { 0, 1, 17, 17, }, { 0, 4, 68, 68, }, { 0, 1, 17, 17, }, { 0, 4, 68, 68, }, { 0, 1, 17, 17, }, { 0, 4, 68, 68, }, { 0, 1, 17, 17, }, }, new byte[,] { { 0, 0, }, { 0, 0, }, { 0, 0, }, { 0, 0, }, { 0, 0, }, { 0, 0, }, { 0, 0, }, { 0, 0, }, { 0, 0, }, { 0, 0, }, { 0, 0, }, { 0, 0, }, { 0, 0, }, { 0, 0, }, { 0, 0, }, { 0, 0, }, { 0, 0, }, { 0, 0, }, { 0, 0, }, { 0, 0, }, { 0, 0, }, { 0, 0, }, { 0, 0, }, { 0, 0, }, { 0, 0, }, { 0, 0, }, { 0, 0, }, { 0, 0, }, { 0, 0, }, { 0, 0, }, { 0, 0, }, { 0, 0, }, { 0, 0, }, { 0, 0, }, { 0, 0, }, { 0, 0, }, { 0, 0, }, { 0, 0, }, { 0, 0, }, { 0, 0, }, { 0, 0, }, { 0, 0, }, { 3, 255, }, { 3, 255, }, { 3, 255, }, { 3, 255, }, { 3, 255, }, { 3, 255, }, { 3, 255, }, { 3, 255, }, { 3, 255, }, { 3, 255, }, { 3, 255, }, { 3, 255, }, { 3, 255, }, { 3, 255, }, { 3, 255, }, { 3, 255, }, { 3, 255, }, { 3, 255, }, { 3, 255, }, { 3, 255, }, { 3, 255, }, { 3, 255, }, })},
                 { 12, new Sprite(new byte[,] { { 0, 0, 0, 0, }, { 0, 0, 0, 0, }, { 0, 0, 0, 0, }, { 0, 0, 0, 0, }, { 0, 0, 0, 0, }, { 0, 0, 0, 0, }, { 0, 0, 0, 0, }, { 0, 0, 0, 0, }, { 0, 0, 0, 0, }, { 0, 0, 0, 0, }, { 0, 0, 0, 0, }, { 0, 0, 0, 0, }, { 0, 0, 0, 0, }, { 0, 0, 0, 0, }, { 0, 0, 0, 0, }, { 0, 0, 0, 0, }, { 0, 0, 0, 0, }, { 0, 0, 0, 0, }, { 0, 0, 0, 0, }, { 0, 0, 0, 0, }, { 0, 0, 0, 0, }, { 0, 0, 0, 0, }, { 0, 0, 0, 0, }, { 0, 0, 0, 0, }, { 0, 0, 0, 0, }, { 0, 0, 0, 0, }, { 0, 0, 0, 0, }, { 0, 0, 0, 0, }, { 0, 0, 0, 0, }, { 0, 0, 0, 0, }, { 0, 0, 0, 0, }, { 0, 0, 0, 0, }, { 0, 0, 0, 0, }, { 0, 0, 0, 0, }, { 0, 0, 0, 0, }, { 0, 0, 0, 0, }, { 0, 0, 0, 0, }, { 0, 0, 0, 0, }, { 0, 0, 0, 0, }, { 0, 0, 0, 0, }, { 0, 0, 0, 0, }, { 0, 0, 0, 0, }, { 68, 68, 68, 68, }, { 17, 17, 17, 17, }, { 68, 68, 68, 68, }, { 17, 17, 17, 17, }, { 68, 68, 68, 68, }, { 17, 17, 17, 17, }, { 68, 68, 68, 68, }, { 17, 17, 17, 17, }, { 68, 68, 68, 68, }, { 17, 17, 17, 17, }, { 68, 68, 68, 68, }, { 17, 17, 17, 17, }, { 68, 68, 68, 68, }, { 17, 17, 17, 17, }, { 68, 68, 68, 68, }, { 17, 17, 17, 17, }, { 68, 68, 68, 68, }, { 17, 17, 17, 17, }, { 68, 68, 68, 68, }, { 17, 17, 17, 17, }, { 68, 68, 68, 68, }, { 17, 17, 17, 17, }, }, new byte[,] { { 0, 0, }, { 0, 0, }, { 0, 0, }, { 0, 0, }, { 0, 0, }, { 0, 0, }, { 0, 0, }, { 0, 0, }, { 0, 0, }, { 0, 0, }, { 0, 0, }, { 0, 0, }, { 0, 0, }, { 0, 0, }, { 0, 0, }, { 0, 0, }, { 0, 0, }, { 0, 0, }, { 0, 0, }, { 0, 0, }, { 0, 0, }, { 0, 0, }, { 0, 0, }, { 0, 0, }, { 0, 0, }, { 0, 0, }, { 0, 0, }, { 0, 0, }, { 0, 0, }, { 0, 0, }, { 0, 0, }, { 0, 0, }, { 0, 0, }, { 0, 0, }, { 0, 0, }, { 0, 0, }, { 0, 0, }, { 0, 0, }, { 0, 0, }, { 0, 0, }, { 0, 0, }, { 0, 0, }, { 255, 255, }, { 255, 255, }, { 255, 255, }, { 255, 255, }, { 255, 255, }, { 255, 255, }, { 255, 255, }, { 255, 255, }, { 255, 255, }, { 255, 255, }, { 255, 255, }, { 255, 255, }, { 255, 255, }, { 255, 255, }, { 255, 255, }, { 255, 255, }, { 255, 255, }, { 255, 255, }, { 255, 255, }, { 255, 255, }, { 255, 255, }, { 255, 255, }, })},
                 { 13, new Sprite(new byte[,] { { 0, 0, 0, 0, }, { 0, 0, 0, 0, }, { 0, 0, 0, 0, }, { 0, 0, 0, 0, }, { 0, 0, 0, 0, }, { 0, 0, 0, 0, }, { 0, 0, 0, 0, }, { 0, 0, 0, 0, }, { 0, 0, 0, 0, }, { 0, 0, 0, 0, }, { 0, 0, 0, 0, }, { 0, 0, 0, 0, }, { 0, 0, 0, 0, }, { 0, 0, 0, 0, }, { 0, 0, 0, 0, }, { 0, 0, 0, 0, }, { 0, 0, 0, 0, }, { 0, 0, 0, 0, }, { 0, 0, 0, 0, }, { 0, 0, 0, 0, }, { 0, 0, 0, 0, }, { 0, 0, 0, 0, }, { 0, 0, 0, 0, }, { 0, 0, 0, 0, }, { 0, 0, 0, 0, }, { 0, 0, 0, 0, }, { 0, 0, 0, 0, }, { 0, 0, 0, 0, }, { 0, 0, 0, 0, }, { 0, 0, 0, 0, }, { 0, 0, 0, 0, }, { 0, 0, 0, 0, }, { 0, 0, 0, 0, }, { 0, 0, 0, 0, }, { 0, 0, 0, 0, }, { 0, 0, 0, 0, }, { 0, 0, 0, 0, }, { 0, 0, 0, 0, }, { 0, 0, 0, 0, }, { 0, 0, 0, 0, }, { 0, 0, 0, 0, }, { 0, 0, 0, 0, }, { 68, 68, 64, 0, }, { 17, 17, 16, 0, }, { 68, 68, 64, 0, }, { 17, 17, 16, 0, }, { 68, 68, 64, 0, }, { 17, 17, 16, 0, }, { 68, 68, 64, 0, }, { 17, 17, 16, 0, }, { 68, 68, 64, 0, }, { 17, 17, 16, 0, }, { 68, 68, 64, 0, }, { 17, 17, 16, 0, }, { 68, 68, 64, 0, }, { 17, 17, 16, 0, }, { 68, 68, 64, 0, }, { 17, 17, 16, 0, }, { 68, 68, 64, 0, }, { 17, 17, 16, 0, }, { 68, 68, 64, 0, }, { 17, 17, 16, 0, }, { 68, 68, 64, 0, }, { 17, 17, 16, 0, }, }, new byte[,] { { 0, 0, }, { 0, 0, }, { 0, 0, }, { 0, 0, }, { 0, 0, }, { 0, 0, }, { 0, 0, }, { 0, 0, }, { 0, 0, }, { 0, 0, }, { 0, 0, }, { 0, 0, }, { 0, 0, }, { 0, 0, }, { 0, 0, }, { 0, 0, }, { 0, 0, }, { 0, 0, }, { 0, 0, }, { 0, 0, }, { 0, 0, }, { 0, 0, }, { 0, 0, }, { 0, 0, }, { 0, 0, }, { 0, 0, }, { 0, 0, }, { 0, 0, }, { 0, 0, }, { 0, 0, }, { 0, 0, }, { 0, 0, }, { 0, 0, }, { 0, 0, }, { 0, 0, }, { 0, 0, }, { 0, 0, }, { 0, 0, }, { 0, 0, }, { 0, 0, }, { 0, 0, }, { 0, 0, }, { 255, 192, }, { 255, 192, }, { 255, 192, }, { 255, 192, }, { 255, 192, }, { 255, 192, }, { 255, 192, }, { 255, 192, }, { 255, 192, }, { 255, 192, }, { 255, 192, }, { 255, 192, }, { 255, 192, }, { 255, 192, }, { 255, 192, }, { 255, 192, }, { 255, 192, }, { 255, 192, }, { 255, 192, }, { 255, 192, }, { 255, 192, }, { 255, 192, }, })},
           };
       }
   }
}
