using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Text;
using Stealth.Assets;

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

        private double cameraXMin;
        public double CameraXMin { get => cameraXMin; }
        private double cameraXMax;
        public double CameraXMax { get => cameraXMax; }

        public Map(sbyte[,] walls = null, sbyte[,] ceilings = null, sbyte[,] floors = null, 
            Stealth.PalettesTypes palettesType = Stealth.PalettesTypes.basic)
        {
            Walls = walls;
            Ceilings = ceilings;
            Floors = floors;

            if (walls.GetLength(0) != ceilings.GetLength(0) || walls.GetLength(0) != floors.GetLength(0)
                || walls.GetLength(1) != ceilings.GetLength(1) || walls.GetLength(1) != floors.GetLength(1))
                throw new ArgumentException("Arguments walls, ceilings, and floors must be arrays of equal sizes");

            PalettesType = palettesType;
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
                    { 2,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1, 2 },
                    { 2,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1, 2 },
                    { 1,-1,-1, 2, 2, 0, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2 },
                    { 1,-1,-1, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2 },
                    { 1,-1,-1, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2 },
                    { 1,-1,-1, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2 },
                    { 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2 },
                },
                ceilings: new sbyte[,]
                {
                    { 0, 1, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 },
                    { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1, 0 },
                    { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 },
                    { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 },
                    { 0, 0, 1, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 },
                    { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 },
                    { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 },
                },
                floors: new sbyte[,]
                {
                    { 0, 1, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 },
                    { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1, 0 },
                    { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 },
                    { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 },
                    { 0, 0, 1, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 },
                    { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 },
                    { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 },
                },
                palettesType: PalettesTypes.deepBlue
            );
        }
    }
}
