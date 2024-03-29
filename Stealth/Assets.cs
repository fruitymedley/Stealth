﻿using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Content;
using SixLabors.ImageSharp;
using SixLabors.ImageSharp.PixelFormats;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace Stealth
{
    public static class Assets
    {
        public const string ASSETS = "Assets";

        public static Dictionary<int, Sprite> Ceilings = new Dictionary<int, Sprite>();
        public static Dictionary<int, Sprite> Floors = new Dictionary<int, Sprite>();
        public static Dictionary<int, Sprite> Walls = new Dictionary<int, Sprite>();
        public static Dictionary<int, Sprite> Players = new Dictionary<int, Sprite>();
        public static Dictionary<int, Sprite> Items = new Dictionary<int, Sprite>();
        public static void Load(this Dictionary<int, Sprite> sprites, ContentManager content, string folder)
        {
            foreach (string asset in Directory.GetDirectories(Path.Combine(ASSETS, folder)).Where(a => int.TryParse(Path.GetFileNameWithoutExtension(a), out _)).OrderBy(a => int.Parse(Path.GetFileNameWithoutExtension(a))))
            {
                Image<Rgba32> flatImage = Image.Load<Rgba32>(File.ReadAllBytes(Path.Join(asset, "flat.png")));
                Image<Rgba32> reflectImage = Image.Load<Rgba32>(File.ReadAllBytes(Path.Join(asset, "reflect.png")));
                Image<Rgba32> normalImage = Image.Load<Rgba32>(File.ReadAllBytes(Path.Join(asset, "normal.png")));

                sbyte[,] mask = new sbyte[flatImage.Width, flatImage.Height], flat = new sbyte[flatImage.Width, flatImage.Height], reflect = new sbyte[flatImage.Width, flatImage.Height];
                Vector3[,] normal = new Vector3[flatImage.Width, flatImage.Height];

                for (int y = 0; y < flatImage.Height; y++)
                {
                    for (int x = 0; x < flatImage.Width; x++)
                    {
                        mask[x, y] = (sbyte)(flatImage[x, y].A == 0 ? 0 : 1);
                        flat[x, y] = (sbyte)(flatImage[x, y].R / 16);
                        reflect[x, y] = (sbyte)(reflectImage[x, y].R / 16);
                        Vector3 n = new Vector3((128 - normalImage[x, y].R), (normalImage[x, y].B - 128), (normalImage[x, y].G - 128));
                        n = n.Length() > 0 ? n / n.Length() : new Vector3();
                        normal[x, y] = n;
                    }
                }

                sprites[int.Parse(Path.GetFileNameWithoutExtension(asset))] = new Sprite(mask, flat, reflect, normal);
            }
        }
    }
}
