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

        private byte[,] collision;
        public byte[,] Collision
        {
            get => collision;
            set => collision = value;
        }

        public Stealth.PalettesTypes PalettesType;

        private double cameraXMin;
        public double CameraXMin { get => cameraXMin; }
        private double cameraXMax;
        public double CameraXMax { get => cameraXMax; }

        public Map(sbyte[,] walls = null, sbyte[,] ceilings = null, sbyte[,] floors = null, byte[,] collision = null,
            Stealth.PalettesTypes palettesType = Stealth.PalettesTypes.basic)
        {
            Walls = walls;
            Ceilings = ceilings;
            Floors = floors;
            Collision = collision;

            if (walls.GetLength(0) != ceilings.GetLength(0) || walls.GetLength(0) != floors.GetLength(0) || walls.GetLength(0) != collision.GetLength(0)
                || walls.GetLength(1) != ceilings.GetLength(1) || walls.GetLength(1) != floors.GetLength(1) || walls.GetLength(1) != collision.GetLength(1))
                throw new ArgumentException("Arguments walls, ceilings, and floors must be arrays of equal sizes");

            PalettesType = palettesType;
        }
    }

    public partial class Stealth
    {
        public enum MapList { attic, closet, bathroom, hallway, bedroom, COUNT };
        public static Map[] Maps = new Map[(int)MapList.COUNT];

        public static void InitializeMaps()
        {
            Maps[(int)MapList.attic] =
            new Map
            (
                walls: new sbyte[,]
                {
                    { 5,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1, 4, 4,-1,-1,-1,-1,11 },
                    { 6,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,10 },
                    { 7,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1, 9 },
                    { 8,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1, 8 },
                    { 9,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1, 7 },
                    {10,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1, 6 },
                    {11,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1, 5 },
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
                collision: new byte[,]
                {
                    { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, },
                    { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, },
                    { 0, 0, 0, 0, 9, 8, 8, 8, 8, 8, 8, 8, 8, 8, 8, 8, 8, 8, 8,12, 0, },
                    { 0, 0, 0, 0, 1, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 4, 0, },
                    { 0, 0, 0, 0, 3, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 6, 0, },
                    { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, },
                    { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, },
                    { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, },
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
                collision: new byte[,]
                {
                    { 0,27,24,30, 0, },
                    { 0, 0, 5, 0, 0, },
                    { 0, 0, 7, 0, 0, },
                    { 0, 0, 0, 0, 0, },
                },
                palettesType: PalettesTypes.gold
            );

            Maps[(int)MapList.bathroom] = new Map
            (
                walls: new sbyte[,]
                {
                    {19,-1,-1,-1,-1,18,},
                    {20,-1,-1,-1,-1,17,},
                    {21,-1,-1,-1,-1,16,},
                    {29,-1,23,24,25,15,},
                    {30,-1,23,24,25,15,},
                    {31,-1,23,24,25,15,},
                    {29,17,23,24,25,15,},
                },
                ceilings: new sbyte[,]
                {
                    { 3, 3, 3, 3, 3, 3,},
                    { 3, 3, 3, 3, 3, 3,},
                    { 3, 3, 3, 3, 3, 3,},
                    { 3, 3, 3, 3, 3, 3,},
                    { 3, 3, 3, 3, 3, 3,},
                    { 3, 3, 3, 3, 3, 3,},
                    { 3, 3, 3, 3, 3, 3,},
                },
                floors: new sbyte[,]
                {
                    {19,24,24,25,22,19,},
                    {19,20,21,23,22,19,},
                    {19,22,22,22,22,19,},
                    {19,19,19,19,19,19,},
                    {19,19,19,19,19,19,},
                    {19,19,19,19,19,19,},
                    {19,19,19,19,19,19,},
                },
                collision: new byte[,]
                {
                    { 0, 9,12, 0, 0, 0, },
                    { 0, 3, 6, 0, 0, 0, },
                    { 0, 0, 0, 0, 0, 0, },
                    { 0, 0, 0, 0, 0, 0, },
                    { 0, 0, 0, 0, 0, 0, },
                    { 0, 0, 0, 0, 0, 0, },
                    { 0, 0, 0, 0, 0, 0, },
                },
                palettesType: PalettesTypes.lime
            );

            Maps[(int)MapList.hallway] = new Map
            (
                walls: new sbyte[,]
                {
                    { 3,-1,-1, 3, },
                    { 3,-1,-1, 3, },
                    { 3,-1,-1, 3, },
                    { 3,-1,-1, 3, },
                    { 3,-1,-1, 3, },
                    { 3,-1,-1, 3, },
                    { 3,-1,-1, 3, },
                    { 3,-1,-1, 3, },
                    { 3,-1,-1, 3, },
                    { 3,26,28, 3, },
                },
                ceilings: new sbyte[,]
                {
                    { 2, 2, 2, 2, },
                    { 2, 2, 2, 2, },
                    { 2, 2, 2, 2, },
                    { 2, 2, 2, 2, },
                    { 2, 2, 2, 2, },
                    { 2, 2, 2, 2, },
                    { 2, 2, 2, 2, },
                    { 2, 2, 2, 2, },
                    { 2, 2, 2, 2, },
                    { 2, 2, 2, 2, },
                },
                floors: new sbyte[,]
                {
                    { 1, 1, 1, 1, },
                    { 1, 1, 1, 1, },
                    { 1, 1, 1, 1, },
                    { 1, 1, 1, 1, },
                    { 1, 1, 1, 1, },
                    { 1, 1, 1, 1, },
                    { 1, 1, 1, 1, },
                    { 1, 1, 1, 1, },
                    { 1, 1, 1, 1, },
                    { 1, 1, 1, 1, },
                },
                collision: new byte[,]
                {
                    { 0, 9,12, 0, },
                    { 0, 1, 4, 0, },
                    { 0, 1, 4, 0, },
                    { 0, 1, 4, 0, },
                    { 0, 1, 4, 0, },
                    { 0, 1, 4, 0, },
                    { 0, 1, 4, 0, },
                    { 0, 1, 4, 0, },
                    { 0, 3, 6, 0, },
                    { 0, 0, 0, 0, },
                },
                palettesType: PalettesTypes.red
            );

            Maps[(int)MapList.bedroom] = new Map
            (
                walls: new sbyte[,]
                {
                    { 3,-1,-1,-1,-1,-1,-1,-1, 3, },
                    { 3,-1,-1,-1,-1,-1,-1,-1, 3, },
                    { 3,-1,-1,-1,-1,-1,-1,-1, 3, },
                    { 3,-1,-1,-1,-1,-1,-1,-1, 3, },
                    { 3,-1,-1,-1,-1,-1,-1,-1, 3, },
                    { 3,-1,-1,-1,-1,-1,-1,-1, 3, },
                    { 3, 3, 3, 3, 3, 3, 3, 3, 3, },
                },
                ceilings: new sbyte[,]
                {
                    { 2, 2, 2, 2, 2, 2, 2, 2, 2 },
                    { 2, 2, 2, 2, 2, 2, 2, 2, 2 },
                    { 2, 2, 2, 2, 2, 2, 2, 2, 2 },
                    { 2, 2, 2, 2, 2, 2, 2, 2, 2 },
                    { 2, 2, 2, 2, 2, 2, 2, 2, 2 },
                    { 2, 2, 2, 2, 2, 2, 2, 2, 2 },
                    { 2, 2, 2, 2, 2, 2, 2, 2, 2 },
                },
                floors: new sbyte[,]
                {
                    { 1, 1, 1,32,33,34, 1, 1, 1 },
                    { 1, 1, 1,31,30,29, 1, 1, 1 },
                    { 1, 1, 1,26,27,28, 1, 1, 1 },
                    { 1, 1, 1, 1, 1, 1, 1, 1, 1 },
                    { 1, 1, 1, 1, 1, 1, 1, 1, 1 },
                    { 1, 1, 1, 1, 1, 1, 1, 1, 1 },
                    { 1, 1, 1, 1, 1, 1, 1, 1, 1 },
                },
                collision: new byte[,]
                {
                    { 0, 9, 8, 8, 8, 8, 8,12, 0, },
                    { 0, 1, 0, 0, 0, 0, 0, 4, 0, },
                    { 0, 1, 0, 0, 0, 0, 0, 4, 0, },
                    { 0, 1, 0, 0, 0, 0, 0, 4, 0, },
                    { 0, 1, 0, 0, 0, 0, 0, 4, 0, },
                    { 0, 3, 2, 2, 2, 2, 2, 6, 0, },
                    { 0, 0, 0, 0, 0, 0, 0, 0, 0, },
                },
                palettesType: PalettesTypes.crimson
            );
        }
    }
}
