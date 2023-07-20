using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Stealth
{
    public class Graphics
    {
        public const int SCREEN_WIDTH = 320;
        public const int SCREEN_HEIGHT = 180;

        public const double INVERSE_SCREEN_WIDTH = 1.0 / SCREEN_WIDTH;
        public const double INVERSE_SCREEN_HEIGHT = 1.0 / SCREEN_HEIGHT;

        public const int CAMERA_WIDTH = 9;
        public const int CAMERA_DISTANCE = 5;

        public const double INVERSE_CAMERA_DISTANCE = 1.0 / CAMERA_DISTANCE;
        
        public const double VEL = 0.05;

        private State previousState;

        private Random rng;

        private float[] xPosInit;
        private float[] yPosInit;
        private float[] xVelInit;
        private float[] yVelInit;

        private Pixel[,] background;
        private Pixel[,] sprites;
        private Pixel[,] player;

        private Pixel[,] prerender;
        private Color[] screen;
        public Graphics()
        {
            previousState = null;

            rng = new Random();

            xPosInit = new float[SCREEN_WIDTH];
            yPosInit = new float[SCREEN_WIDTH];
            xVelInit = new float[SCREEN_WIDTH];
            yVelInit = new float[SCREEN_WIDTH];
            for (int x = 0; x < SCREEN_WIDTH; x++)
            {
                xPosInit[x] = (float)((x + 0.5) * ((double)CAMERA_WIDTH) * INVERSE_SCREEN_WIDTH);
                yPosInit[x] = 0;
                double inverseDist = 1 / Math.Sqrt(Math.Pow(xPosInit[x] - CAMERA_WIDTH * 0.5, 2) + Math.Pow(CAMERA_DISTANCE, 2));
                xVelInit[x] = (float)(VEL * ((xPosInit[x] - CAMERA_WIDTH * 0.5) * inverseDist));
                yVelInit[x] = (float)(VEL * CAMERA_DISTANCE * inverseDist);
            }

            background = new Pixel[SCREEN_WIDTH, SCREEN_HEIGHT];
            sprites = new Pixel[SCREEN_WIDTH, SCREEN_HEIGHT];
            player = new Pixel[SCREEN_WIDTH, SCREEN_HEIGHT];

            prerender = new Pixel[SCREEN_WIDTH, SCREEN_HEIGHT];
            screen = new Color[SCREEN_WIDTH * SCREEN_HEIGHT];

            for (int x = 0; x < SCREEN_WIDTH; x++)
            {
                for (int y = 0; y < SCREEN_HEIGHT; y++)
                {
                    background[x, y] = new Pixel();
                    sprites[x, y] = new Pixel();
                    player[x, y] = new Pixel();

                    screen[x + y * SCREEN_WIDTH] = new Color();
                }
            }
        }

        public void Prerender(State state)
        {
            ConcurrentBag<Point> points = new ConcurrentBag<Point>();
            redrawBackgrounds(state, points, backgroundsToRedraw(state));
            redrawSprites(state, points);
            redrawPlayer(state, points);

            foreach (Point p in points.Distinct())
            {
                if (background[p.X, p.Y].Depth < sprites[p.X, p.Y].Depth && background[p.X, p.Y].Depth < player[p.X, p.Y].Depth)
                    prerender[p.X, p.Y] = background[p.X, p.Y];
                else if (sprites[p.X, p.Y].Depth < player[p.X, p.Y].Depth)
                    prerender[p.X, p.Y] = sprites[p.X, p.Y];
                else
                    prerender[p.X, p.Y] = player[p.X, p.Y];
            }

            previousState = state.Copy();
        }

        private int[] backgroundsToRedraw(State state)
        {
            return Enumerable.Range(0, SCREEN_WIDTH).ToArray();
            if (previousState == null)
                return Enumerable.Range(0, SCREEN_WIDTH).ToArray();

            return new int[0];
        }

        private void redrawBackgrounds(State state, ConcurrentBag<Point> points, int[] backgrounds)
        {
            sbyte room = state.Player.Room;
            double xCam = state.Player.XCam;

            float xPos, yPos, xVel, yVel;
            int xPrev, wall;
            Map map = Stealth.Maps[room];
            int mapWidth = map.Width, mapHeight = map.Height;
            sbyte[,] mapWalls = map.Walls, mapCeilings = map.Ceilings, mapFloors = map.Floors;

            bool orientation;
            int height;
            float z, yFloor, xFloor, xCeiling, yCeiling, zPos;
            short iFloor, jFloor, i, j, iCeiling, jCeiling, iFine, jFine;
            Sprite sprite;
            Pixel pixel;

            //for (int x = 0; x < SCREEN_WIDTH; x++)
            foreach (int x in backgrounds)
            //Parallel.ForEach(Enumerable.Range(0, SCREEN_WIDTH), x =>
            {
                xPos = xPosInit[x];
                yPos = yPosInit[x];
                xVel = xVelInit[x];
                yVel = yVelInit[x];
                xPos += (float)(xCam - CAMERA_WIDTH * 0.5);

                xPrev = (int)Math.Floor(xPos);

                while (xPos > 0 && xPos < mapWidth && yPos < mapHeight && mapWalls[(int)Math.Floor(yPos), (int)Math.Floor(xPos)] < 0)
                {
                    xPrev = (int)Math.Floor(xPos);

                    xPos += xVel;
                    yPos += yVel;
                }

                wall = -1;
                if (xPos >= 0 && xPos < mapWidth && yPos >= 0 && yPos < mapHeight)
                {
                    wall = mapWalls[(int)yPos, (int)xPos];
                }

                orientation = xPrev == Math.Floor(xPos);

                if (orientation)
                    yPos = (float)Math.Round(yPos);
                else
                    xPos = (float)Math.Round(xPos);



                height = (int)(SCREEN_HEIGHT * CAMERA_DISTANCE / (CAMERA_DISTANCE + yPos));

                for (int y = 0; y < SCREEN_HEIGHT; y++)
                {
                    points.Add(new Point(x, y));
                    pixel = background[x, y];

                    // Render floors
                    if (y > (SCREEN_HEIGHT + height) * 0.5)
                    {
                        z = (float)((float)y * INVERSE_SCREEN_HEIGHT - 0.5);
                        yFloor = (float)(0.5 * CAMERA_DISTANCE / z - CAMERA_DISTANCE);
                        xFloor = (float)(((x + 0.5) * INVERSE_SCREEN_WIDTH - 0.5) * CAMERA_WIDTH * (CAMERA_DISTANCE + yFloor) * INVERSE_CAMERA_DISTANCE + xCam);
                        iFloor = (short)Math.Floor(xFloor);
                        jFloor = (short)Math.Floor(yFloor);
                        i = (short)(Assets.Floors[mapFloors[jFloor, iFloor]].Width * (xFloor - Math.Floor(xFloor)));
                        j = (short)(Assets.Floors[mapFloors[jFloor, iFloor]].Height * (1 - yFloor + Math.Floor(yFloor)) - 1);
                        sprite = Assets.Floors[mapFloors[jFloor, iFloor]];

                        pixel.Depth = yFloor;
                        pixel.Flat = sprite.Flat[i, j];
                        pixel.Reflect = sprite.Reflect[i, j];
                        pixel.Position.X = xFloor;
                        pixel.Position.Y = yFloor;
                        pixel.Position.Z = z;
                        pixel.Normal.X = sprite.Normal[i, j].X;
                        pixel.Normal.Y = sprite.Normal[i, j].Z;
                        pixel.Normal.Z = sprite.Normal[i, j].Y;
                    }
                    // Render ceilings
                    else if (y < (SCREEN_HEIGHT - height) * 0.5)
                    {
                        z = (float)(0.5 - (float)y * INVERSE_SCREEN_HEIGHT);
                        yCeiling = (float)(0.5 * CAMERA_DISTANCE / z - CAMERA_DISTANCE);
                        xCeiling = (float)(((x + 0.5) * INVERSE_SCREEN_WIDTH - 0.5) * CAMERA_WIDTH * (CAMERA_DISTANCE + yCeiling) * INVERSE_CAMERA_DISTANCE + xCam);
                        iCeiling = (short)Math.Floor(xCeiling);
                        jCeiling = (short)Math.Floor(yCeiling);
                        iFine = (short)(Assets.Ceilings[mapCeilings[jCeiling, iCeiling]].Width * (xCeiling - Math.Floor(xCeiling)));
                        jFine = (short)(Assets.Ceilings[mapCeilings[jCeiling, iCeiling]].Height * (yCeiling - Math.Floor(yCeiling)));
                        sprite = Assets.Ceilings[mapCeilings[jCeiling, iCeiling]];

                        pixel.Depth = yCeiling;
                        pixel.Flat = sprite.Flat[iFine, jFine];
                        pixel.Reflect = sprite.Reflect[iFine, jFine];
                        pixel.Position.X = xCeiling;
                        pixel.Position.Y = yCeiling;
                        pixel.Position.Z = z;
                        pixel.Normal.X = sprite.Normal[iFine, jFine].X;
                        pixel.Normal.Y = sprite.Normal[iFine, jFine].Z;
                        pixel.Normal.Z = -sprite.Normal[iFine, jFine].Y;
                    }
                    // Render Walls
                    else if (wall >= 0)
                    {
                        zPos = (float)(4 * (y - (SCREEN_HEIGHT - height) * 0.5) / height);

                        j = (short)(Assets.Walls[wall].Height * (y - (SCREEN_HEIGHT - height) * 0.5) / height);
                        i = orientation ? (short)(Assets.Walls[wall].Width * (xPos - Math.Floor(xPos))) : (short)(Assets.Walls[wall].Width * ((xVel < 0) ? (yPos - Math.Floor(yPos)) : (1 - yPos + Math.Floor(yPos))));
                        j = Math.Max(Math.Min(j, (short)(Assets.Walls[wall].Height - 1)), (short)0);
                        sprite = Assets.Walls[wall];

                        pixel.Depth = yPos;
                        pixel.Flat = sprite.Flat[i, j];
                        pixel.Reflect = sprite.Reflect[i, j];
                        pixel.Position.X = xPos;
                        pixel.Position.Y = yPos;
                        pixel.Position.Z = zPos;

                        if (orientation)
                        {
                            pixel.Normal.X = sprite.Normal[i, j].X;
                            pixel.Normal.Y = sprite.Normal[i, j].Y;
                            pixel.Normal.Z = sprite.Normal[i, j].Z;
                        }
                        else if (xVel < 0)
                        {
                            pixel.Normal.X = -sprite.Normal[i, j].Y;
                            pixel.Normal.Y = sprite.Normal[i, j].X;
                            pixel.Normal.Z = sprite.Normal[i, j].Z;
                        }
                        else
                        {
                            pixel.Normal.X = sprite.Normal[i, j].Y;
                            pixel.Normal.Y = sprite.Normal[i, j].X;
                            pixel.Normal.Z = sprite.Normal[i, j].Z;
                        }
                    }
                }
            }
            //});
        }

        private void redrawSprites(State state, ConcurrentBag<Point> points)
        {
            //if (previousState != null)
            //    return;

            double xCam = state.Player.XCam;

            uint key;

            sbyte itemX, itemY;
            Item item;
            short i, j;
            Sprite sprite;

            bool empty;
            float xItem, yItem, zItem;
            Pixel pixel;

            IEnumerable<KeyValuePair<uint, Item>> items = state.GetItemsInRoom();
            for (int x = 0; x < SCREEN_WIDTH; x++)
            //Parallel.ForEach(Enumerable.Range(0, SCREEN_WIDTH), x =>
            {
                List<KeyValuePair<uint, Item>> shortItems = new List<KeyValuePair<uint, Item>>();

                foreach (KeyValuePair<uint, Item> kvp in items)
                {
                    key = kvp.Key;
                    itemX = (sbyte)(key & 0xFF);
                    itemY = (sbyte)((key >> 8) & 0xFF);
                    item = kvp.Value;
                    sprite = item.Sprite;
                    i = (short)Math.Floor(sprite.Width * (((((double)CAMERA_WIDTH * x * INVERSE_SCREEN_WIDTH) - (CAMERA_WIDTH * 0.5)) * (CAMERA_DISTANCE + itemY) * INVERSE_CAMERA_DISTANCE) + (CAMERA_WIDTH * 0.5 - itemX + xCam - CAMERA_WIDTH * 0.5)));
                    if (i >= 0 && i < sprite.Width)
                        shortItems.Add(kvp);
                }

                shortItems = shortItems.OrderBy(kvp => ((kvp.Key >> 8) & 0xFF)).ToList();

                for (int y = 0; y < SCREEN_HEIGHT; y++)
                {
                    empty = true;
                    pixel = sprites[x, y];
                    foreach (KeyValuePair<uint, Item> kvp in shortItems)
                    {

                        key = kvp.Key;
                        itemX = (sbyte)(key & 0xFF);
                        itemY = (sbyte)((key >> 8) & 0xFF);

                        item = kvp.Value;
                        sprite = item.Sprite;
                        i = (short)Math.Floor(sprite.Width * (((((double)CAMERA_WIDTH * x * INVERSE_SCREEN_WIDTH) - (CAMERA_WIDTH * 0.5)) * (CAMERA_DISTANCE + itemY) * INVERSE_CAMERA_DISTANCE) + (CAMERA_WIDTH * 0.5 - itemX + xCam - CAMERA_WIDTH * 0.5)));
                        j = (short)(sprite.Height * (((double)y * INVERSE_SCREEN_HEIGHT - 0.5) * (CAMERA_DISTANCE + itemY) * INVERSE_CAMERA_DISTANCE + 0.5));

                        if (i >= 0 && i < sprite.Width && j >= 0 && j < sprite.Height && sprite.Mask[i, j] > 0)
                        {
                            xItem = itemX + (float)i / sprite.Width;
                            yItem = itemY;
                            zItem = 4 * (float)j / sprite.Height;

                            points.Add(new Point(x, y));

                            pixel.Depth = yItem - 0.1;
                            pixel.Flat = sprite.Flat[i, j];
                            pixel.Reflect = sprite.Reflect[i, j];
                            pixel.Position.X = xItem;
                            pixel.Position.Y = yItem;
                            pixel.Position.Z = zItem;
                            pixel.Normal.X = sprite.Normal[i, j].X;
                            pixel.Normal.Y = sprite.Normal[i, j].Y;
                            pixel.Normal.Z = sprite.Normal[i, j].Z;

                            empty = false;
                            break;
                        }
                    }
                    if (empty && (pixel == null || !double.IsPositiveInfinity(pixel.Depth)))
                    {
                        points.Add(new Point(x, y));
                        pixel.Depth = double.PositiveInfinity;
                    }
                }
            }
            //});
        }

        private void redrawPlayer(State state, ConcurrentBag<Point> points)
        {
            //if (previousState != null)
            //    return;

            Sprite sprite = state.Player.Sprite;
            double xFine = state.Player.Xfine;
            double yFine = state.Player.Yfine;
            double xCam = state.Player.XCam;

            short i, j;
            float xPlayer, yPlayer, zPlayer;
            Pixel pixel;

            for (int x = 0; x < SCREEN_WIDTH; x++)
            //Parallel.ForEach(Enumerable.Range(0, SCREEN_WIDTH), x =>
            {
                for (int y = 0; y < SCREEN_HEIGHT; y++)
                {
                    pixel = player[x, y];
                    i = (short)Math.Floor(32 * (((((double)CAMERA_WIDTH * x * INVERSE_SCREEN_WIDTH) - (CAMERA_WIDTH * 0.5)) * (CAMERA_DISTANCE + yFine) * INVERSE_CAMERA_DISTANCE) + (xCam - xFine)));
                    j = (short)(sprite.Height * (((double)y * INVERSE_SCREEN_HEIGHT - 0.5) * (CAMERA_DISTANCE + yFine) * INVERSE_CAMERA_DISTANCE + 0.5));

                    if (i >= 0 && i < sprite.Width && j >= 0 && j < sprite.Height && sprite.Mask[i, j] > 0)
                    {
                        xPlayer = (float)xFine + (float)i / sprite.Width;
                        yPlayer = (float)yFine + 0.5f;
                        zPlayer = 4 * (float)j / sprite.Height;

                        points.Add(new Point(x, y));

                        pixel.Depth = (float)yFine;
                        pixel.Flat = sprite.Flat[i, j];
                        pixel.Reflect = sprite.Reflect[i, j];
                        pixel.Position.X = xPlayer;
                        pixel.Position.Y = yPlayer;
                        pixel.Position.Z = zPlayer;
                        pixel.Normal.X = sprite.Normal[i, j].X;
                        pixel.Normal.Y = sprite.Normal[i, j].Y;
                        pixel.Normal.Z = sprite.Normal[i, j].Z;
                    }
                    else if (pixel == null || !double.IsPositiveInfinity(pixel.Depth))
                    {
                        points.Add(new Point(x, y));
                        pixel.Depth = double.PositiveInfinity;
                    }
                }
            }
            //});
        }

        public Texture2D Render(GraphicsDevice graphicsDevice, Light[] rays)
        {
            int paletteType = (int)Stealth.Maps[previousState.Player.Room].PalettesType;

            for (int x = 0; x < SCREEN_WIDTH; x++)
                for (int y = 0; y < SCREEN_HEIGHT; y++)
                    screen[x + y * SCREEN_WIDTH] = Stealth.Palettes[paletteType, (short)Math.Max(Math.Min((int)Dither.ToDither((short)(prerender[x, y].Prerender(rays)), x, y), 3), 0)];
            
            Texture2D texture = new Texture2D(graphicsDevice, SCREEN_WIDTH, SCREEN_HEIGHT);
            texture.SetData(screen);
            return texture;
        }

        private class Pixel
        {
            public double Depth;
            public int Flat;
            public int Reflect;
            public Vector3 Position;
            public Vector3 Normal;

            public Pixel()
            {
                Depth = double.PositiveInfinity;
                Flat = 0;
                Reflect = 0;
                Position = Vector3.Zero;
                Normal = Vector3.Forward;
            }

            public Pixel(double depth, int flat, int reflect, Vector3 position, Vector3 normal)
            {
                Depth = depth;
                Flat = flat;
                Reflect = reflect;
                Position = position;
                Normal = normal;
            }

            public sbyte Prerender(Light[] lights)
            {
                float intensity = 0;
                if (Reflect > 0)
                    foreach (Light l in lights)
                        intensity += l.Intensity(Position, Normal);
                
                return (sbyte)Math.Max(0, Math.Min(Dither.DEPTH, Flat * Sprite.bitToDither + Reflect * intensity));
            }
        }
    }
}
