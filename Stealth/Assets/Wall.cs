using System;
using System.Collections.Generic;
using System.Text;
using Stealth;

namespace Stealth.Assets
{
   class Wall
   {
       public static Dictionary<int, Sprite> Sprites;
       public static void Init()
       {
           Sprites = new Dictionary<int, Sprite>
           {
                 { 0, new Sprite(new byte[,] { { 170, 170, }, { 170, 170, }, { 170, 170, }, { 170, 170, }, { 170, 170, }, { 170, 170, }, { 170, 170, }, { 170, 170, }, { 170, 170, }, { 170, 170, }, { 170, 170, }, { 170, 170, }, { 170, 170, }, { 170, 170, }, { 170, 170, }, { 170, 170, }, { 170, 170, }, { 170, 170, }, { 170, 170, }, { 170, 170, }, { 170, 170, }, { 170, 170, }, { 170, 170, }, { 170, 170, }, { 170, 170, }, { 170, 170, }, { 170, 170, }, { 170, 170, }, { 170, 170, }, { 170, 170, }, { 170, 170, }, { 170, 170, }, }, new byte[,] { { 255, }, { 255, }, { 255, }, { 255, }, { 255, }, { 255, }, { 255, }, { 255, }, { 255, }, { 255, }, { 255, }, { 255, }, { 255, }, { 255, }, { 255, }, { 255, }, { 255, }, { 255, }, { 255, }, { 255, }, { 255, }, { 255, }, { 255, }, { 255, }, { 255, }, { 255, }, { 255, }, { 255, }, { 255, }, { 255, }, { 255, }, { 255, }, })},
                 { 1, new Sprite(new byte[,] { { 165, 90, }, { 165, 90, }, { 165, 90, }, { 165, 90, }, { 165, 90, }, { 165, 90, }, { 165, 90, }, { 165, 90, }, { 165, 90, }, { 165, 90, }, { 165, 90, }, { 165, 90, }, { 165, 90, }, { 165, 90, }, { 165, 90, }, { 165, 90, }, { 165, 90, }, { 165, 90, }, { 165, 90, }, { 165, 90, }, { 165, 90, }, { 165, 90, }, { 165, 90, }, { 165, 90, }, { 165, 90, }, { 165, 90, }, { 165, 90, }, { 165, 90, }, { 165, 90, }, { 165, 90, }, { 165, 90, }, { 165, 90, }, }, new byte[,] { { 255, }, { 255, }, { 255, }, { 255, }, { 255, }, { 255, }, { 255, }, { 255, }, { 255, }, { 255, }, { 255, }, { 255, }, { 255, }, { 255, }, { 255, }, { 255, }, { 255, }, { 255, }, { 255, }, { 255, }, { 255, }, { 255, }, { 255, }, { 255, }, { 255, }, { 255, }, { 255, }, { 255, }, { 255, }, { 255, }, { 255, }, { 255, }, })},
                 { 2, new Sprite(new byte[,] { { 255, 255, }, { 255, 255, }, { 255, 255, }, { 255, 255, }, { 239, 239, }, { 254, 254, }, { 239, 239, }, { 187, 187, }, { 238, 238, }, { 187, 187, }, { 238, 238, }, { 186, 186, }, { 171, 171, }, { 186, 186, }, { 170, 170, }, { 170, 170, }, { 170, 170, }, { 170, 170, }, { 154, 154, }, { 169, 169, }, { 154, 154, }, { 102, 102, }, { 153, 153, }, { 102, 102, }, { 153, 153, }, { 101, 101, }, { 86, 86, }, { 101, 101, }, { 85, 85, }, { 85, 85, }, { 85, 85, }, { 85, 85, }, }, new byte[,] { { 255, }, { 255, }, { 255, }, { 255, }, { 255, }, { 255, }, { 255, }, { 255, }, { 255, }, { 255, }, { 255, }, { 255, }, { 255, }, { 255, }, { 255, }, { 255, }, { 255, }, { 255, }, { 255, }, { 255, }, { 255, }, { 255, }, { 255, }, { 255, }, { 255, }, { 255, }, { 255, }, { 255, }, { 255, }, { 255, }, { 255, }, { 255, }, })},
                 { 3, new Sprite(new byte[,] { { 255, 255, 255, 255, }, { 153, 153, 153, 153, }, { 170, 170, 170, 170, }, { 85, 85, 85, 85, }, { 85, 85, 85, 85, }, { 85, 85, 85, 85, }, { 85, 85, 85, 85, }, { 85, 85, 85, 85, }, { 81, 85, 85, 85, }, { 64, 85, 85, 85, }, { 64, 149, 85, 85, }, { 82, 149, 85, 85, }, { 86, 101, 85, 85, }, { 85, 101, 85, 85, }, { 85, 149, 85, 85, }, { 85, 85, 85, 85, }, { 85, 85, 85, 85, }, { 85, 85, 85, 85, }, { 81, 81, 81, 81, }, { 21, 21, 21, 21, }, { 81, 81, 81, 81, }, { 21, 21, 0, 21, }, { 81, 81, 64, 145, }, { 21, 21, 18, 21, }, { 81, 81, 82, 97, }, { 21, 21, 21, 37, }, { 81, 81, 81, 145, }, { 21, 21, 21, 21, }, { 81, 81, 81, 81, }, { 21, 21, 21, 21, }, { 68, 68, 68, 68, }, { 17, 17, 17, 17, }, { 64, 68, 68, 68, }, { 0, 17, 17, 17, }, { 64, 132, 68, 68, }, { 18, 17, 17, 17, }, { 68, 68, 68, 68, }, { 17, 33, 17, 17, }, { 68, 132, 68, 68, }, { 17, 17, 17, 17, }, { 68, 68, 68, 68, }, { 17, 17, 17, 17, }, { 238, 238, 238, 238, }, { 170, 170, 170, 170, }, { 153, 153, 153, 153, }, { 85, 85, 85, 85, }, { 106, 171, 106, 171, }, { 106, 171, 106, 171, }, { 105, 170, 105, 170, }, { 90, 155, 90, 155, }, { 105, 170, 105, 171, }, { 90, 155, 90, 155, }, { 38, 103, 38, 103, }, { 89, 154, 89, 154, }, { 38, 103, 38, 103, }, { 89, 154, 89, 154, }, { 38, 103, 38, 103, }, { 89, 154, 89, 154, }, { 22, 87, 22, 87, }, { 37, 102, 37, 102, }, { 22, 87, 22, 87, }, { 153, 153, 153, 153, }, { 85, 85, 85, 85, }, { 85, 85, 85, 85, }, }, new byte[,] { { 255, 255, }, { 255, 255, }, { 255, 255, }, { 255, 255, }, { 255, 255, }, { 255, 255, }, { 255, 255, }, { 255, 255, }, { 255, 255, }, { 255, 255, }, { 255, 255, }, { 255, 255, }, { 255, 255, }, { 255, 255, }, { 255, 255, }, { 255, 255, }, { 255, 255, }, { 255, 255, }, { 255, 255, }, { 255, 255, }, { 255, 255, }, { 255, 255, }, { 255, 255, }, { 255, 255, }, { 255, 255, }, { 255, 255, }, { 255, 255, }, { 255, 255, }, { 255, 255, }, { 255, 255, }, { 255, 255, }, { 255, 255, }, { 255, 255, }, { 255, 255, }, { 255, 255, }, { 255, 255, }, { 255, 255, }, { 255, 255, }, { 255, 255, }, { 255, 255, }, { 255, 255, }, { 255, 255, }, { 255, 255, }, { 255, 255, }, { 255, 255, }, { 255, 255, }, { 255, 255, }, { 255, 255, }, { 255, 255, }, { 255, 255, }, { 255, 255, }, { 255, 255, }, { 255, 255, }, { 255, 255, }, { 255, 255, }, { 255, 255, }, { 255, 255, }, { 255, 255, }, { 255, 255, }, { 255, 255, }, { 255, 255, }, { 255, 255, }, { 255, 255, }, { 255, 255, }, })},
                 { 4, new Sprite(new byte[,] { { 0, 0, 0, 0, }, { 0, 0, 0, 0, }, { 0, 0, 0, 0, }, { 0, 0, 0, 0, }, { 0, 0, 0, 0, }, { 0, 0, 0, 0, }, { 0, 0, 0, 0, }, { 0, 0, 0, 0, }, { 0, 0, 0, 0, }, { 0, 0, 0, 0, }, { 0, 0, 0, 0, }, { 0, 0, 0, 0, }, { 0, 0, 0, 0, }, { 0, 0, 0, 0, }, { 0, 0, 0, 0, }, { 0, 0, 0, 0, }, { 0, 0, 0, 0, }, { 0, 0, 0, 0, }, { 0, 0, 0, 0, }, { 0, 0, 0, 0, }, { 0, 0, 0, 0, }, { 0, 0, 0, 0, }, { 0, 0, 0, 0, }, { 0, 0, 0, 0, }, { 0, 0, 0, 0, }, { 0, 0, 0, 0, }, { 0, 0, 0, 0, }, { 0, 0, 0, 0, }, { 0, 0, 0, 0, }, { 0, 0, 0, 0, }, { 0, 0, 0, 0, }, { 0, 0, 0, 0, }, { 0, 0, 0, 0, }, { 0, 0, 0, 0, }, { 0, 0, 0, 0, }, { 0, 0, 0, 0, }, { 0, 0, 0, 0, }, { 0, 0, 0, 0, }, { 0, 0, 0, 0, }, { 0, 0, 0, 0, }, { 0, 0, 0, 0, }, { 0, 0, 0, 0, }, { 0, 0, 0, 0, }, { 0, 0, 0, 0, }, { 0, 0, 0, 0, }, { 0, 0, 0, 0, }, { 0, 0, 0, 0, }, { 0, 0, 0, 0, }, { 0, 0, 0, 0, }, { 0, 0, 0, 0, }, { 0, 0, 0, 0, }, { 0, 0, 0, 0, }, { 0, 0, 0, 0, }, { 0, 0, 0, 0, }, { 0, 0, 0, 0, }, { 0, 0, 0, 0, }, { 0, 0, 0, 0, }, { 0, 0, 0, 0, }, { 0, 0, 0, 0, }, { 0, 0, 0, 0, }, { 0, 0, 0, 0, }, { 0, 0, 0, 0, }, { 0, 0, 0, 0, }, { 0, 0, 0, 0, }, }, new byte[,] { { 255, 255, }, { 255, 255, }, { 255, 255, }, { 255, 255, }, { 255, 255, }, { 255, 255, }, { 255, 255, }, { 255, 255, }, { 255, 255, }, { 255, 255, }, { 255, 255, }, { 255, 255, }, { 255, 255, }, { 255, 255, }, { 255, 255, }, { 255, 255, }, { 255, 255, }, { 255, 255, }, { 255, 255, }, { 255, 255, }, { 255, 255, }, { 255, 255, }, { 255, 255, }, { 255, 255, }, { 255, 255, }, { 255, 255, }, { 255, 255, }, { 255, 255, }, { 255, 255, }, { 255, 255, }, { 255, 255, }, { 255, 255, }, { 255, 255, }, { 255, 255, }, { 255, 255, }, { 255, 255, }, { 255, 255, }, { 255, 255, }, { 255, 255, }, { 255, 255, }, { 255, 255, }, { 255, 255, }, { 255, 255, }, { 255, 255, }, { 255, 255, }, { 255, 255, }, { 255, 255, }, { 255, 255, }, { 255, 255, }, { 255, 255, }, { 255, 255, }, { 255, 255, }, { 255, 255, }, { 255, 255, }, { 255, 255, }, { 255, 255, }, { 255, 255, }, { 255, 255, }, { 255, 255, }, { 255, 255, }, { 255, 255, }, { 255, 255, }, { 255, 255, }, { 255, 255, }, })},
                 { 5, new Sprite(new byte[,] { { 0, 0, 0, 0, }, { 0, 0, 0, 0, }, { 0, 0, 0, 0, }, { 0, 0, 0, 0, }, { 0, 0, 0, 0, }, { 0, 0, 0, 0, }, { 0, 0, 0, 0, }, { 0, 0, 0, 0, }, { 0, 0, 0, 0, }, { 0, 0, 0, 0, }, { 0, 0, 0, 0, }, { 0, 0, 0, 0, }, { 0, 0, 0, 0, }, { 0, 0, 0, 0, }, { 0, 0, 0, 0, }, { 0, 0, 0, 0, }, { 0, 0, 0, 0, }, { 0, 0, 0, 0, }, { 0, 0, 0, 0, }, { 0, 0, 0, 0, }, { 0, 0, 0, 0, }, { 0, 0, 0, 0, }, { 0, 0, 0, 0, }, { 0, 0, 0, 0, }, { 0, 0, 0, 0, }, { 0, 0, 0, 0, }, { 0, 0, 0, 0, }, { 0, 0, 0, 101, }, { 0, 0, 1, 84, }, { 0, 0, 4, 88, }, { 0, 0, 21, 84, }, { 0, 16, 17, 21, }, { 0, 0, 21, 84, }, { 4, 68, 4, 68, }, { 0, 0, 17, 84, }, { 17, 16, 4, 16, }, { 0, 0, 17, 20, }, { 4, 68, 4, 68, }, { 0, 0, 17, 20, }, { 0, 16, 20, 68, }, { 0, 0, 1, 16, }, { 0, 4, 4, 68, }, { 0, 0, 0, 16, }, { 0, 0, 17, 4, }, { 0, 0, 0, 0, }, { 0, 0, 4, 68, }, { 0, 0, 0, 0, }, { 0, 0, 17, 16, }, { 0, 0, 0, 0, }, { 0, 0, 0, 68, }, { 0, 0, 0, 0, }, { 0, 0, 0, 16, }, { 0, 0, 0, 0, }, { 0, 0, 0, 0, }, { 0, 0, 0, 0, }, { 0, 0, 0, 0, }, { 0, 0, 0, 0, }, { 0, 0, 0, 0, }, { 0, 0, 0, 0, }, { 0, 0, 0, 0, }, { 0, 0, 0, 0, }, { 0, 0, 0, 0, }, { 0, 0, 0, 0, }, { 0, 0, 0, 0, }, }, new byte[,] { { 255, 255, }, { 255, 255, }, { 255, 255, }, { 255, 255, }, { 255, 255, }, { 255, 255, }, { 255, 255, }, { 255, 255, }, { 255, 255, }, { 255, 255, }, { 255, 255, }, { 255, 255, }, { 255, 255, }, { 255, 255, }, { 255, 255, }, { 255, 255, }, { 255, 255, }, { 255, 255, }, { 255, 255, }, { 255, 255, }, { 255, 255, }, { 255, 255, }, { 255, 255, }, { 255, 255, }, { 255, 255, }, { 255, 255, }, { 255, 255, }, { 255, 255, }, { 255, 255, }, { 255, 255, }, { 255, 255, }, { 255, 255, }, { 255, 255, }, { 255, 255, }, { 255, 255, }, { 255, 255, }, { 255, 255, }, { 255, 255, }, { 255, 255, }, { 255, 255, }, { 255, 255, }, { 255, 255, }, { 255, 255, }, { 255, 255, }, { 255, 255, }, { 255, 255, }, { 255, 255, }, { 255, 255, }, { 255, 255, }, { 255, 255, }, { 255, 255, }, { 255, 255, }, { 255, 255, }, { 255, 255, }, { 255, 255, }, { 255, 255, }, { 255, 255, }, { 255, 255, }, { 255, 255, }, { 255, 255, }, { 255, 255, }, { 255, 255, }, { 255, 255, }, { 255, 255, }, })},
                 { 6, new Sprite(new byte[,] { { 0, 0, 0, 0, }, { 0, 0, 0, 0, }, { 0, 0, 0, 0, }, { 0, 0, 0, 0, }, { 0, 0, 0, 0, }, { 0, 0, 0, 0, }, { 0, 0, 0, 0, }, { 0, 0, 0, 0, }, { 0, 0, 0, 0, }, { 0, 0, 0, 0, }, { 0, 0, 0, 0, }, { 0, 0, 0, 0, }, { 0, 0, 0, 0, }, { 0, 0, 0, 0, }, { 0, 0, 0, 0, }, { 0, 0, 0, 0, }, { 0, 0, 0, 0, }, { 0, 0, 0, 0, }, { 0, 0, 0, 0, }, { 0, 0, 0, 9, }, { 0, 0, 0, 101, }, { 0, 0, 10, 169, }, { 0, 0, 101, 152, }, { 0, 24, 90, 169, }, { 2, 101, 38, 101, }, { 25, 152, 89, 169, }, { 21, 101, 38, 104, }, { 38, 88, 89, 153, }, { 21, 85, 38, 101, }, { 89, 152, 89, 152, }, { 21, 84, 38, 101, }, { 38, 101, 89, 152, }, { 21, 84, 22, 101, }, { 89, 152, 89, 152, }, { 21, 84, 21, 101, }, { 22, 101, 38, 88, }, { 21, 84, 21, 85, }, { 5, 152, 89, 152, }, { 21, 84, 21, 84, }, { 17, 101, 38, 101, }, { 21, 84, 21, 84, }, { 4, 68, 89, 152, }, { 21, 84, 21, 84, }, { 17, 16, 22, 101, }, { 17, 84, 21, 84, }, { 4, 68, 5, 152, }, { 17, 20, 21, 84, }, { 4, 68, 17, 20, }, { 17, 16, 21, 84, }, { 4, 68, 4, 68, }, { 0, 16, 17, 84, }, { 17, 4, 4, 80, }, { 0, 0, 17, 16, }, { 4, 68, 4, 68, }, { 0, 0, 1, 16, }, { 17, 16, 16, 68, }, { 0, 0, 0, 16, }, { 0, 84, 4, 68, }, { 0, 0, 0, 0, }, { 0, 4, 17, 16, }, { 0, 0, 0, 0, }, { 0, 0, 4, 68, }, { 0, 0, 0, 0, }, { 0, 0, 0, 16, }, }, new byte[,] { { 255, 255, }, { 255, 255, }, { 255, 255, }, { 255, 255, }, { 255, 255, }, { 255, 255, }, { 255, 255, }, { 255, 255, }, { 255, 255, }, { 255, 255, }, { 255, 255, }, { 255, 255, }, { 255, 255, }, { 255, 255, }, { 255, 255, }, { 255, 255, }, { 255, 255, }, { 255, 255, }, { 255, 255, }, { 255, 255, }, { 255, 255, }, { 255, 255, }, { 255, 255, }, { 255, 255, }, { 255, 255, }, { 255, 255, }, { 255, 255, }, { 255, 255, }, { 255, 255, }, { 255, 255, }, { 255, 255, }, { 255, 255, }, { 255, 255, }, { 255, 255, }, { 255, 255, }, { 255, 255, }, { 255, 255, }, { 255, 255, }, { 255, 255, }, { 255, 255, }, { 255, 255, }, { 255, 255, }, { 255, 255, }, { 255, 255, }, { 255, 255, }, { 255, 255, }, { 255, 255, }, { 255, 255, }, { 255, 255, }, { 255, 255, }, { 255, 255, }, { 255, 255, }, { 255, 255, }, { 255, 255, }, { 255, 255, }, { 255, 255, }, { 255, 255, }, { 255, 255, }, { 255, 255, }, { 255, 255, }, { 255, 255, }, { 255, 255, }, { 255, 255, }, { 255, 255, }, })},
                 { 7, new Sprite(new byte[,] { { 0, 0, 0, 0, }, { 0, 0, 0, 0, }, { 0, 0, 0, 0, }, { 0, 0, 0, 0, }, { 0, 0, 0, 0, }, { 0, 0, 0, 0, }, { 0, 0, 0, 0, }, { 0, 0, 0, 0, }, { 0, 0, 0, 0, }, { 0, 0, 0, 0, }, { 0, 0, 0, 0, }, { 0, 0, 0, 9, }, { 0, 0, 0, 169, }, { 0, 0, 10, 169, }, { 0, 0, 90, 169, }, { 0, 9, 106, 169, }, { 0, 101, 38, 169, }, { 10, 169, 106, 169, }, { 89, 152, 89, 169, }, { 106, 169, 106, 169, }, { 38, 101, 38, 105, }, { 106, 169, 106, 169, }, { 89, 152, 89, 152, }, { 106, 169, 106, 169, }, { 38, 101, 38, 101, }, { 106, 169, 106, 169, }, { 89, 152, 89, 152, }, { 106, 169, 106, 169, }, { 38, 101, 38, 101, }, { 106, 169, 106, 169, }, { 25, 152, 89, 152, }, { 90, 169, 106, 169, }, { 38, 101, 38, 101, }, { 89, 169, 106, 169, }, { 38, 88, 89, 152, }, { 89, 152, 106, 169, }, { 38, 101, 38, 101, }, { 89, 152, 89, 169, }, { 38, 101, 38, 88, }, { 25, 152, 89, 152, }, { 22, 101, 38, 101, }, { 89, 152, 89, 152, }, { 21, 85, 38, 101, }, { 38, 101, 25, 152, }, { 21, 84, 22, 101, }, { 89, 152, 89, 152, }, { 21, 84, 21, 84, }, { 38, 101, 38, 101, }, { 21, 84, 21, 84, }, { 21, 152, 89, 152, }, { 21, 84, 21, 84, }, { 17, 20, 38, 101, }, { 21, 84, 21, 84, }, { 4, 68, 5, 84, }, { 17, 84, 21, 84, }, { 4, 80, 17, 16, }, { 17, 16, 21, 84, }, { 4, 68, 4, 68, }, { 1, 16, 17, 16, }, { 20, 68, 4, 68, }, { 0, 0, 17, 16, }, { 4, 68, 4, 68, }, { 0, 0, 0, 0, }, { 17, 16, 17, 16, }, }, new byte[,] { { 255, 255, }, { 255, 255, }, { 255, 255, }, { 255, 255, }, { 255, 255, }, { 255, 255, }, { 255, 255, }, { 255, 255, }, { 255, 255, }, { 255, 255, }, { 255, 255, }, { 255, 255, }, { 255, 255, }, { 255, 255, }, { 255, 255, }, { 255, 255, }, { 255, 255, }, { 255, 255, }, { 255, 255, }, { 255, 255, }, { 255, 255, }, { 255, 255, }, { 255, 255, }, { 255, 255, }, { 255, 255, }, { 255, 255, }, { 255, 255, }, { 255, 255, }, { 255, 255, }, { 255, 255, }, { 255, 255, }, { 255, 255, }, { 255, 255, }, { 255, 255, }, { 255, 255, }, { 255, 255, }, { 255, 255, }, { 255, 255, }, { 255, 255, }, { 255, 255, }, { 255, 255, }, { 255, 255, }, { 255, 255, }, { 255, 255, }, { 255, 255, }, { 255, 255, }, { 255, 255, }, { 255, 255, }, { 255, 255, }, { 255, 255, }, { 255, 255, }, { 255, 255, }, { 255, 255, }, { 255, 255, }, { 255, 255, }, { 255, 255, }, { 255, 255, }, { 255, 255, }, { 255, 255, }, { 255, 255, }, { 255, 255, }, { 255, 255, }, { 255, 255, }, { 255, 255, }, })},
                 { 8, new Sprite(new byte[,] { { 0, 0, 0, 0, }, { 0, 0, 0, 0, }, { 0, 0, 0, 0, }, { 0, 0, 0, 0, }, { 0, 0, 0, 0, }, { 0, 0, 0, 0, }, { 0, 0, 0, 0, }, { 0, 0, 0, 0, }, { 0, 41, 104, 0, }, { 10, 169, 106, 160, }, { 106, 169, 106, 169, }, { 106, 169, 106, 169, }, { 106, 169, 106, 169, }, { 106, 169, 106, 169, }, { 106, 169, 106, 169, }, { 106, 169, 106, 169, }, { 106, 169, 106, 169, }, { 106, 169, 106, 169, }, { 106, 169, 106, 169, }, { 106, 169, 106, 169, }, { 106, 169, 106, 169, }, { 106, 169, 106, 169, }, { 90, 169, 106, 168, }, { 106, 169, 106, 169, }, { 38, 101, 38, 101, }, { 106, 169, 106, 169, }, { 89, 152, 89, 152, }, { 106, 169, 106, 169, }, { 38, 101, 38, 101, }, { 106, 169, 106, 169, }, { 89, 152, 89, 152, }, { 106, 169, 106, 169, }, { 38, 101, 38, 101, }, { 106, 169, 106, 169, }, { 89, 152, 89, 152, }, { 106, 169, 106, 169, }, { 38, 101, 38, 101, }, { 106, 169, 106, 169, }, { 89, 152, 89, 152, }, { 90, 169, 106, 168, }, { 38, 101, 38, 101, }, { 89, 152, 89, 152, }, { 38, 101, 38, 101, }, { 89, 152, 89, 152, }, { 38, 101, 38, 101, }, { 89, 152, 89, 152, }, { 38, 101, 38, 101, }, { 38, 101, 38, 101, }, { 21, 84, 21, 84, }, { 89, 152, 89, 152, }, { 21, 84, 21, 84, }, { 38, 101, 38, 101, }, { 21, 84, 21, 84, }, { 89, 152, 89, 152, }, { 21, 84, 21, 84, }, { 17, 16, 17, 16, }, { 21, 84, 21, 84, }, { 4, 68, 4, 68, }, { 17, 16, 17, 16, }, { 4, 68, 4, 68, }, { 17, 16, 17, 16, }, { 4, 68, 4, 68, }, { 17, 16, 17, 16, }, { 17, 16, 17, 16, }, }, new byte[,] { { 255, 255, }, { 255, 255, }, { 255, 255, }, { 255, 255, }, { 255, 255, }, { 255, 255, }, { 255, 255, }, { 255, 255, }, { 255, 255, }, { 255, 255, }, { 255, 255, }, { 255, 255, }, { 255, 255, }, { 255, 255, }, { 255, 255, }, { 255, 255, }, { 255, 255, }, { 255, 255, }, { 255, 255, }, { 255, 255, }, { 255, 255, }, { 255, 255, }, { 255, 255, }, { 255, 255, }, { 255, 255, }, { 255, 255, }, { 255, 255, }, { 255, 255, }, { 255, 255, }, { 255, 255, }, { 255, 255, }, { 255, 255, }, { 255, 255, }, { 255, 255, }, { 255, 255, }, { 255, 255, }, { 255, 255, }, { 255, 255, }, { 255, 255, }, { 255, 255, }, { 255, 255, }, { 255, 255, }, { 255, 255, }, { 255, 255, }, { 255, 255, }, { 255, 255, }, { 255, 255, }, { 255, 255, }, { 255, 255, }, { 255, 255, }, { 255, 255, }, { 255, 255, }, { 255, 255, }, { 255, 255, }, { 255, 255, }, { 255, 255, }, { 255, 255, }, { 255, 255, }, { 255, 255, }, { 255, 255, }, { 255, 255, }, { 255, 255, }, { 255, 255, }, { 255, 255, }, })},
                 { 9, new Sprite(new byte[,] { { 0, 0, 0, 0, }, { 0, 0, 0, 0, }, { 0, 0, 0, 0, }, { 0, 0, 0, 0, }, { 0, 0, 0, 0, }, { 0, 0, 0, 0, }, { 0, 0, 0, 0, }, { 0, 0, 0, 0, }, { 0, 0, 0, 0, }, { 0, 0, 0, 0, }, { 0, 0, 0, 0, }, { 96, 0, 0, 0, }, { 106, 0, 0, 0, }, { 106, 160, 0, 0, }, { 106, 168, 0, 0, }, { 106, 169, 96, 0, }, { 106, 165, 38, 0, }, { 106, 169, 106, 160, }, { 106, 152, 89, 152, }, { 106, 169, 106, 169, }, { 106, 101, 38, 101, }, { 106, 169, 106, 169, }, { 89, 152, 89, 152, }, { 106, 169, 106, 169, }, { 38, 101, 38, 101, }, { 106, 169, 106, 169, }, { 89, 152, 89, 152, }, { 106, 169, 106, 169, }, { 38, 101, 38, 101, }, { 106, 169, 106, 169, }, { 89, 152, 89, 152, }, { 106, 169, 106, 168, }, { 38, 101, 38, 101, }, { 106, 169, 106, 152, }, { 89, 152, 89, 101, }, { 106, 169, 89, 152, }, { 38, 101, 38, 101, }, { 106, 152, 89, 152, }, { 89, 101, 38, 101, }, { 89, 152, 89, 152, }, { 38, 101, 38, 100, }, { 89, 152, 89, 152, }, { 38, 101, 37, 84, }, { 89, 152, 38, 101, }, { 38, 100, 21, 84, }, { 89, 152, 89, 152, }, { 21, 84, 21, 84, }, { 38, 101, 38, 101, }, { 21, 84, 21, 84, }, { 89, 152, 89, 148, }, { 21, 84, 21, 84, }, { 38, 101, 21, 16, }, { 21, 84, 21, 84, }, { 21, 68, 4, 68, }, { 21, 84, 21, 16, }, { 17, 16, 4, 68, }, { 21, 80, 17, 16, }, { 4, 68, 4, 68, }, { 17, 16, 17, 16, }, { 4, 68, 4, 16, }, { 17, 16, 16, 0, }, { 4, 68, 4, 68, }, { 0, 0, 0, 0, }, { 17, 16, 17, 16, }, }, new byte[,] { { 255, 255, }, { 255, 255, }, { 255, 255, }, { 255, 255, }, { 255, 255, }, { 255, 255, }, { 255, 255, }, { 255, 255, }, { 255, 255, }, { 255, 255, }, { 255, 255, }, { 255, 255, }, { 255, 255, }, { 255, 255, }, { 255, 255, }, { 255, 255, }, { 255, 255, }, { 255, 255, }, { 255, 255, }, { 255, 255, }, { 255, 255, }, { 255, 255, }, { 255, 255, }, { 255, 255, }, { 255, 255, }, { 255, 255, }, { 255, 255, }, { 255, 255, }, { 255, 255, }, { 255, 255, }, { 255, 255, }, { 255, 255, }, { 255, 255, }, { 255, 255, }, { 255, 255, }, { 255, 255, }, { 255, 255, }, { 255, 255, }, { 255, 255, }, { 255, 255, }, { 255, 255, }, { 255, 255, }, { 255, 255, }, { 255, 255, }, { 255, 255, }, { 255, 255, }, { 255, 255, }, { 255, 255, }, { 255, 255, }, { 255, 255, }, { 255, 255, }, { 255, 255, }, { 255, 255, }, { 255, 255, }, { 255, 255, }, { 255, 255, }, { 255, 255, }, { 255, 255, }, { 255, 255, }, { 255, 255, }, { 255, 255, }, { 255, 255, }, { 255, 255, }, { 255, 255, }, })},
                 { 10, new Sprite(new byte[,] { { 0, 0, 0, 0, }, { 0, 0, 0, 0, }, { 0, 0, 0, 0, }, { 0, 0, 0, 0, }, { 0, 0, 0, 0, }, { 0, 0, 0, 0, }, { 0, 0, 0, 0, }, { 0, 0, 0, 0, }, { 0, 0, 0, 0, }, { 0, 0, 0, 0, }, { 0, 0, 0, 0, }, { 0, 0, 0, 0, }, { 0, 0, 0, 0, }, { 0, 0, 0, 0, }, { 0, 0, 0, 0, }, { 0, 0, 0, 0, }, { 0, 0, 0, 0, }, { 0, 0, 0, 0, }, { 0, 0, 0, 0, }, { 96, 0, 0, 0, }, { 38, 64, 0, 0, }, { 106, 160, 0, 0, }, { 89, 149, 0, 0, }, { 106, 152, 81, 0, }, { 38, 101, 38, 64, }, { 105, 152, 89, 160, }, { 86, 101, 38, 84, }, { 89, 152, 89, 101, }, { 38, 101, 37, 84, }, { 89, 152, 89, 152, }, { 38, 101, 21, 84, }, { 89, 152, 38, 101, }, { 38, 100, 21, 84, }, { 89, 152, 89, 152, }, { 38, 84, 21, 84, }, { 89, 101, 38, 100, }, { 37, 84, 21, 84, }, { 89, 152, 89, 148, }, { 21, 84, 21, 84, }, { 38, 101, 37, 16, }, { 21, 84, 21, 80, }, { 89, 152, 4, 68, }, { 21, 84, 21, 80, }, { 38, 80, 17, 68, }, { 21, 84, 21, 16, }, { 89, 68, 4, 68, }, { 21, 84, 17, 16, }, { 21, 16, 4, 68, }, { 21, 84, 17, 16, }, { 4, 84, 4, 68, }, { 21, 16, 16, 0, }, { 4, 68, 1, 16, }, { 17, 16, 0, 0, }, { 4, 68, 4, 68, }, { 17, 16, 0, 0, }, { 4, 16, 17, 16, }, { 16, 0, 0, 0, }, { 4, 68, 4, 0, }, { 0, 0, 0, 0, }, { 17, 16, 16, 0, }, { 0, 0, 0, 0, }, { 4, 64, 0, 0, }, { 0, 0, 0, 0, }, { 16, 0, 0, 0, }, }, new byte[,] { { 255, 255, }, { 255, 255, }, { 255, 255, }, { 255, 255, }, { 255, 255, }, { 255, 255, }, { 255, 255, }, { 255, 255, }, { 255, 255, }, { 255, 255, }, { 255, 255, }, { 255, 255, }, { 255, 255, }, { 255, 255, }, { 255, 255, }, { 255, 255, }, { 255, 255, }, { 255, 255, }, { 255, 255, }, { 255, 255, }, { 255, 255, }, { 255, 255, }, { 255, 255, }, { 255, 255, }, { 255, 255, }, { 255, 255, }, { 255, 255, }, { 255, 255, }, { 255, 255, }, { 255, 255, }, { 255, 255, }, { 255, 255, }, { 255, 255, }, { 255, 255, }, { 255, 255, }, { 255, 255, }, { 255, 255, }, { 255, 255, }, { 255, 255, }, { 255, 255, }, { 255, 255, }, { 255, 255, }, { 255, 255, }, { 255, 255, }, { 255, 255, }, { 255, 255, }, { 255, 255, }, { 255, 255, }, { 255, 255, }, { 255, 255, }, { 255, 255, }, { 255, 255, }, { 255, 255, }, { 255, 255, }, { 255, 255, }, { 255, 255, }, { 255, 255, }, { 255, 255, }, { 255, 255, }, { 255, 255, }, { 255, 255, }, { 255, 255, }, { 255, 255, }, { 255, 255, }, })},
                 { 11, new Sprite(new byte[,] { { 0, 0, 0, 0, }, { 0, 0, 0, 0, }, { 0, 0, 0, 0, }, { 0, 0, 0, 0, }, { 0, 0, 0, 0, }, { 0, 0, 0, 0, }, { 0, 0, 0, 0, }, { 0, 0, 0, 0, }, { 0, 0, 0, 0, }, { 0, 0, 0, 0, }, { 0, 0, 0, 0, }, { 0, 0, 0, 0, }, { 0, 0, 0, 0, }, { 0, 0, 0, 0, }, { 0, 0, 0, 0, }, { 0, 0, 0, 0, }, { 0, 0, 0, 0, }, { 0, 0, 0, 0, }, { 0, 0, 0, 0, }, { 0, 0, 0, 0, }, { 0, 0, 0, 0, }, { 0, 0, 0, 0, }, { 0, 0, 0, 0, }, { 0, 0, 0, 0, }, { 0, 0, 0, 0, }, { 0, 0, 0, 0, }, { 0, 0, 0, 0, }, { 32, 0, 0, 0, }, { 21, 0, 0, 0, }, { 84, 64, 0, 0, }, { 21, 80, 0, 0, }, { 17, 68, 16, 0, }, { 21, 16, 0, 0, }, { 4, 68, 4, 64, }, { 21, 16, 0, 0, }, { 20, 68, 17, 16, }, { 17, 16, 0, 0, }, { 4, 68, 4, 64, }, { 17, 16, 0, 0, }, { 4, 64, 17, 0, }, { 17, 0, 0, 0, }, { 4, 68, 4, 0, }, { 16, 0, 0, 0, }, { 1, 16, 16, 0, }, { 0, 0, 0, 0, }, { 4, 68, 0, 0, }, { 0, 0, 0, 0, }, { 17, 16, 0, 0, }, { 0, 0, 0, 0, }, { 4, 64, 0, 0, }, { 0, 0, 0, 0, }, { 16, 0, 0, 0, }, { 0, 0, 0, 0, }, { 0, 0, 0, 0, }, { 0, 0, 0, 0, }, { 0, 0, 0, 0, }, { 0, 0, 0, 0, }, { 0, 0, 0, 0, }, { 0, 0, 0, 0, }, { 0, 0, 0, 0, }, { 0, 0, 0, 0, }, { 0, 0, 0, 0, }, { 0, 0, 0, 0, }, { 0, 0, 0, 0, }, }, new byte[,] { { 255, 255, }, { 255, 255, }, { 255, 255, }, { 255, 255, }, { 255, 255, }, { 255, 255, }, { 255, 255, }, { 255, 255, }, { 255, 255, }, { 255, 255, }, { 255, 255, }, { 255, 255, }, { 255, 255, }, { 255, 255, }, { 255, 255, }, { 255, 255, }, { 255, 255, }, { 255, 255, }, { 255, 255, }, { 255, 255, }, { 255, 255, }, { 255, 255, }, { 255, 255, }, { 255, 255, }, { 255, 255, }, { 255, 255, }, { 255, 255, }, { 255, 255, }, { 255, 255, }, { 255, 255, }, { 255, 255, }, { 255, 255, }, { 255, 255, }, { 255, 255, }, { 255, 255, }, { 255, 255, }, { 255, 255, }, { 255, 255, }, { 255, 255, }, { 255, 255, }, { 255, 255, }, { 255, 255, }, { 255, 255, }, { 255, 255, }, { 255, 255, }, { 255, 255, }, { 255, 255, }, { 255, 255, }, { 255, 255, }, { 255, 255, }, { 255, 255, }, { 255, 255, }, { 255, 255, }, { 255, 255, }, { 255, 255, }, { 255, 255, }, { 255, 255, }, { 255, 255, }, { 255, 255, }, { 255, 255, }, { 255, 255, }, { 255, 255, }, { 255, 255, }, { 255, 255, }, })},
           };
       }
   }
}
