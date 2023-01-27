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
        public enum MapList { attic, closet, COUNT };
        public static Map[] Maps = new Map[(int)MapList.COUNT];

        public static void InitializeMaps()
        {
            Maps[(int)MapList.attic] =
            new Map
            (
                walls: new sbyte[,]
                {
                    { 5,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1, 4, 4,-1,-1,-1,-1, 5 },
                    { 6,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1, 6 },
                    { 7,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1, 7 },
                    { 8,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1, 8 },
                    { 9,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1, 9 },
                    {10,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,10 },
                    {11,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,11 },
                    { 4, 4, 4, 4, 4, 4, 4, 4, 4, 4, 4, 4, 4, 4, 4, 4, 4, 4, 4, 4, 4 },
                },
                ceilings: new sbyte[,]
                {
                    { 3, 3, 3, 3, 3, 3, 3, 3, 3, 3, 3, 3, 3, 3, 3, 3, 3, 3, 3, 3, 3 },
                    { 3, 3, 3, 3, 3, 3, 3, 3, 3, 3, 3, 3, 3, 3, 3, 3, 3, 3, 3, 3, 3 },
                    { 3, 3, 3, 3, 3, 3, 3, 3, 3, 3, 3, 3, 3, 3, 3, 3, 3, 3, 3, 3, 3 },
                    { 3, 3, 3, 3, 3, 3, 3, 3, 3, 3, 3, 3, 3, 3, 3, 3, 3, 3, 3, 3, 3 },
                    { 3, 3, 3, 3, 3, 3, 3, 3, 3, 3, 3, 3, 3, 3, 3, 3, 3, 3, 3, 3, 3 },
                    { 3, 3, 3, 3, 3, 3, 3, 3, 3, 3, 3, 3, 3, 3, 3, 3, 3, 3, 3, 3, 3 },
                    { 3, 3, 3, 3, 3, 3, 3, 3, 3, 3, 3, 3, 3, 3, 3, 3, 3, 3, 3, 3, 3 },
                    { 3, 3, 3, 3, 3, 3, 3, 3, 3, 3, 3, 3, 3, 3, 3, 3, 3, 3, 3, 3, 3 },
                },
                floors: new sbyte[,]
                {
                    { 6, 6, 8, 6, 8, 6, 8, 6, 8, 6, 8, 6, 8, 6, 8, 6, 8, 6, 8, 6, 6 },
                    { 6, 6, 7, 6, 7, 6, 7, 6, 7, 6, 7, 6, 7, 6, 7, 6, 7, 6, 7, 6, 6 },
                    {10,11,12, 9, 9, 9, 9, 9, 9, 9, 9, 9, 9, 9, 9, 9, 9, 9,10,11,12 },
                    {13,14,15, 9, 9, 9, 9, 9, 9, 9, 9, 9, 9, 9, 9, 9, 9, 9,13,14,15 },
                    {16,17,18, 9, 9, 9, 9, 9, 9, 9, 9, 9, 9, 9, 9, 9, 9, 9,16,17,18 },
                    { 6, 6, 4, 6, 4, 6, 4, 6, 4, 6, 4, 6, 4, 6, 4, 6, 4, 6, 4, 6, 6 },
                    { 6, 6, 5, 6, 5, 6, 5, 6, 5, 6, 5, 6, 5, 6, 5, 6, 5, 6, 5, 6, 6 },
                    { 6, 6, 6, 6, 6, 6, 6, 6, 6, 6, 6, 6, 6, 6, 6, 6, 6, 6, 6, 6, 6 },
                },
                palettesType: PalettesTypes.deepBlue
            );

            Maps[(int)MapList.closet] = new Map
            (
                walls: new sbyte[,]
                {
                    {12,-1,-1,-1,12,},
                    {12,-1,-1,-1,12,},
                    {12,-1,-1,-1,12,},
                    {13,13,14,13,13,},
                },
                ceilings: new sbyte[,]
                {
                    { 3, 3, 3, 3, 3,},
                    { 3, 3, 3, 3, 3,},
                    { 3, 3, 3, 3, 3,},
                    { 3, 3, 3, 3, 3,},
                },
                floors: new sbyte[,]
                {
                    { 2, 2, 2, 2, 2,},
                    { 2, 2, 2, 2, 2,},
                    { 2, 2, 2, 2, 2,},
                    { 2, 2, 2, 2, 2,},
                },
                palettesType: PalettesTypes.gold
            );
        }
    }
}
