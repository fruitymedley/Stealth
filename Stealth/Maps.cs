using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Text;

namespace Stealth
{
    public class Map
    {
        private sbyte width;
        public sbyte Width { get => width; }
        private sbyte height;
        public sbyte Height { get => height; }

        private sbyte[,] walls;
        public sbyte[,] Walls 
        {
            get => walls;
            set
            {
                walls = value;
                height = (sbyte)walls.GetLength(0);
                width = (sbyte)walls.GetLength(1);
                cameraXMin = Math.Min(Stealth.CAMERA_WIDTH / 2.0 + 1, Width / 2.0);
                cameraXMax = Math.Max(Width - Stealth.CAMERA_WIDTH / 2.0 - 1, Width / 2.0);
            }
        }

        private sbyte[,] ceilings;
        public sbyte[,] Ceilings
        {
            get => ceilings;
            set => ceilings = value;
        }

        private sbyte[,] floors;
        public sbyte[,] Floors
        {
            get => floors;
            set => floors = value;
        }

        public Stealth.PalettesTypes PalettesType;

        public List<Sprites> Sprites;


        private double cameraXMin;
        public double CameraXMin { get => cameraXMin; }
        private double cameraXMax;
        public double CameraXMax { get => cameraXMax; }

        public Map(sbyte[,] walls = null, sbyte[,] ceilings = null, sbyte[,] floors = null, 
            Stealth.PalettesTypes palettesType = Stealth.PalettesTypes.basic, List<Sprites> sprites = null)
        {
            Walls = walls;
            Ceilings = ceilings;
            Floors = floors;

            if (walls.GetLength(0) != ceilings.GetLength(0) || walls.GetLength(0) != floors.GetLength(0)
                || walls.GetLength(1) != ceilings.GetLength(1) || walls.GetLength(1) != floors.GetLength(1))
                throw new ArgumentException("Arguments walls, ceilings, and floors must be arrays of equal sizes");

            PalettesType = palettesType;

            Sprites = sprites;
        }
    }

    public partial class Stealth
    {
        public enum MapList { test, COUNT };
        public static Map[] Maps = new Map[(int)MapList.COUNT];

        public static void InitializeMaps()
        {
            Maps[(int)MapList.test] =
            new Map
            (
                walls: new sbyte[,]
                {
                    { 2, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 2 },
                    { 2, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 2 },
                    { 2, 0, 0, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2 },
                    { 2, 0, 0, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2 },
                    { 2, 0, 0, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2 },
                    { 2, 0, 0, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2 },
                    { 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2 },
                },
                ceilings: new sbyte[,]
                {
                    { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 },
                    { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 },
                    { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 },
                    { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 },
                    { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 },
                    { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 },
                    { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 },
                },
                floors: new sbyte[,]
                {
                    { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 },
                    { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 },
                    { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 },
                    { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 },
                    { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 },
                    { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 },
                    { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 },
                },
                palettesType: PalettesTypes.deepBlue,
                sprites: new List<Sprites>
                {
                    new Sprites { Texture = Sprites[(int)SpriteList.apple], Location = new Point(1, 0), },
                    new Sprites { Texture = Sprites[(int)SpriteList.apple], Location = new Point(1, 1), },
                    new Sprites { Texture = Sprites[(int)SpriteList.apple], Location = new Point(1, 2), },
                    new Sprites { Texture = Sprites[(int)SpriteList.apple], Location = new Point(6, 1), },
                    //new Sprites { Texture = Sprites[(int)SpriteList.player], Location = new Point(7, 0), },
                    //new Sprites { Texture = Sprites[(int)SpriteList.player], Location = new Point(7, 1), },
                    new Sprites { Texture = Sprites[(int)SpriteList.apple], Location = new Point(8, 1), },
                    new Sprites { Texture = Sprites[(int)SpriteList.apple], Location = new Point(9, 1), },
                    new Sprites { Texture = Sprites[(int)SpriteList.apple], Location = new Point(10, 1), },
                    new Sprites { Texture = Sprites[(int)SpriteList.apple], Location = new Point(11, 2), },
                    new Sprites { Texture = Sprites[(int)SpriteList.apple], Location = new Point(12, 2), },
                    new Sprites { Texture = Sprites[(int)SpriteList.apple], Location = new Point(13, 2), },
                }
            );
        }
    }
}
