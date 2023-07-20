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
                cameraXMin = Math.Min(Graphics.CAMERA_WIDTH / 2.0 + 1, Width / 2.0);
                cameraXMax = Math.Max(Width - Graphics.CAMERA_WIDTH / 2.0 - 1, Width / 2.0);
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

        private Dictionary<Point, Warp> warps;
        public Dictionary<Point, Warp> Warps
        {
            get => warps;
            set => warps = value;
        }

        private Light[] lights;
        public Light[] Lights;

        public Stealth.PalettesTypes PalettesType;

        private double cameraXMin;
        public double CameraXMin { get => cameraXMin; }
        private double cameraXMax;
        public double CameraXMax { get => cameraXMax; }

        public Map(sbyte[,] walls = null, sbyte[,] ceilings = null, sbyte[,] floors = null, byte[,] collision = null, Dictionary<Point, Warp> warps = null,
            Light[] lights = null, Stealth.PalettesTypes palettesType = Stealth.PalettesTypes.basic)
        {
            Walls = walls;
            Ceilings = ceilings;
            Floors = floors;
            Collision = collision;
            Warps = warps;
            Lights = lights;

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
                warps: new Dictionary<Point, Warp>(),
                palettesType: PalettesTypes.deepBlue
            );

            Maps[(int)MapList.closet] = new Map
            (
                walls: new sbyte[,]
                {
                    { 4,-1,-1,-1, 4,},
                    { 4,-1,-1,-1, 4,},
                    { 4,-1,-1,-1, 4,},
                    { 4, 4, 4, 4, 4,},
                },
                ceilings: new sbyte[,]
                {
                    { 2, 2, 2, 2, 2,},
                    { 2, 2, 2, 2, 2,},
                    { 2, 2, 2, 2, 2,},
                    { 2, 2, 2, 2, 2,},
                },
                floors: new sbyte[,]
                {
                    { 1, 1, 1, 1, 1,},
                    { 1, 1, 1, 1, 1,},
                    { 1, 1, 1, 1, 1,},
                    { 1, 1, 1, 1, 1,},
                },
                collision: new byte[,]
                {
                    { 0,27,24,30, 0, },
                    { 0, 0, 5, 0, 0, },
                    { 0, 0, 5, 0, 0, },
                    { 0, 0, 0, 0, 0, },
                },
                lights: new Light[]
                {
                    new IsotropicLight(new Vector3(2.5f, 1.5f, 0.5f), 10),
                },
                warps: new Dictionary<Point, Warp>() { { new Point(2, 3), new Warp((int)MapList.bedroom, 6, 0) } },
                palettesType: PalettesTypes.gold
            );

            Maps[(int)MapList.bathroom] = new Map
            (
                walls: new sbyte[,]
                {
                    {15,-1,-1,-1,-1,15,},
                    {15,-1,-1,-1,-1,15,},
                    {15,-1,-1,-1,-1,15,},
                    {15,-1,15,15,15,15,},
                    {15,-1,15,15,15,15,},
                    {15,-1,15,15,15,15,},
                    {15,15,15,15,15,15,},
                },
                ceilings: new sbyte[,]
                {
                    { 2, 2, 2, 2, 2, 2,},
                    { 2, 2, 2, 2, 2, 2,},
                    { 2, 2, 2, 2, 2, 2,},
                    { 2, 2, 2, 2, 2, 2,},
                    { 2, 2, 2, 2, 2, 2,},
                    { 2, 2, 2, 2, 2, 2,},
                    { 2, 2, 2, 2, 2, 2,},
                },
                floors: new sbyte[,]
                {
                    {19,19,19,19,19,19,},
                    {19,19,19,19,19,19,},
                    {19,19,19,19,19,19,},
                    {19,19,19,19,19,19,},
                    {19,19,19,19,19,19,},
                    {19,19,19,19,19,19,},
                    {19,19,19,19,19,19,},
                },
                collision: new byte[,]
                {
                    { 0, 9,12, 0, 0, 0, },
                    { 0, 2, 6, 0, 0, 0, },
                    { 0, 0, 0, 0, 0, 0, },
                    { 0, 0, 0, 0, 0, 0, },
                    { 0, 0, 0, 0, 0, 0, },
                    { 0, 0, 0, 0, 0, 0, },
                    { 0, 0, 0, 0, 0, 0, },
                },
                lights: new Light[]
                {
                    new IsotropicLight(new Vector3(1.5f, 2.5f, 0.5f), 50),
                },
                warps: new Dictionary<Point, Warp>() { { new Point(0, 1), new Warp((int)MapList.hallway, 2, 1) } },
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
                    { 0, 1, 4, 0, },
                    { 0, 1, 0, 0, },
                    { 0, 1, 4, 0, },
                    { 0, 1, 4, 0, },
                    { 0, 1, 4, 0, },
                    { 0, 1, 4, 0, },
                    { 0, 1, 4, 0, },
                    { 0, 0, 0, 0, },
                    { 0, 3, 6, 0, },
                    { 0, 0, 0, 0, },
                },
                warps: new Dictionary<Point, Warp>()
                {
                    { new Point(3, 1), new Warp((int)MapList.bathroom, 1, 1) },
                    { new Point(3, 7), new Warp((int)MapList.bedroom, 1, 4) },
                },
                lights: new Light[]
                {
                    new IsotropicLight(new Vector3(2f, 20f, -10), 2500),
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
                    { 0, 9, 8, 8, 8, 8, 0,12, 0, },
                    { 0, 1, 0, 0, 0, 0, 0, 4, 0, },
                    { 0, 1, 0, 0, 0, 0, 0, 4, 0, },
                    { 0, 1, 0, 0, 0, 0, 0, 4, 0, },
                    { 0, 0, 0, 0, 0, 0, 0, 4, 0, },
                    { 0, 3, 2, 2, 2, 2, 2, 6, 0, },
                    { 0, 0, 0, 0, 0, 0, 0, 0, 0, },
                },
                warps: new Dictionary<Point, Warp>()
                {
                    { new Point(0, 4), new Warp((int)MapList.hallway, 2, 7) },
                    { new Point(6,-1), new Warp((int)MapList.closet, 2, 1) },
                },
                lights: new Light[]
                {
                    new IsotropicLight(new Vector3(4.5f, 2.5f, 0.5f), 25),
                    new IsotropicLight(new Vector3(3f,   2f,   3.5f), 1),
                    new IsotropicLight(new Vector3(6f,   2f,   3.5f), 1),
                    new IsotropicLight(new Vector3(3.5f, 0f,   3.5f), 1),
                    new IsotropicLight(new Vector3(5.5f, 0f,   3.5f), 1),
                    new IsotropicLight(new Vector3(4.5f, 3f,   3.5f), 1),
                },
                palettesType: PalettesTypes.crimson
            );
        }
    }

    public class Warp
    {
        public sbyte Room { get; set; }
        public sbyte X { get; set; }
        public sbyte Y { get; set; }

        public Warp(sbyte room, sbyte x, sbyte y)
        {
            Room = room;
            X = x;
            Y = y;
        }
    }
}
