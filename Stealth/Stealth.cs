using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.InteropServices;
using System.Threading.Tasks;

namespace Stealth
{
    public partial class Stealth : Game
    {
        private GraphicsDeviceManager _graphics;
        private SpriteBatch _spriteBatch;

        public const int SCREEN_WIDTH = 320 * 2;
        public const int SCREEN_HEIGHT = 180 * 2;

        public const double INVERSE_SCREEN_WIDTH = 1.0 / SCREEN_WIDTH;
        public const double INVERSE_SCREEN_HEIGHT = 1.0 / SCREEN_HEIGHT;

        public const int CAMERA_WIDTH = 9;
        public const int CAMERA_DISTANCE = 5;

        public const double INVERSE_CAMERA_DISTANCE = 1.0 / CAMERA_DISTANCE;

        public State State;

        public double xCam;

        public Random RNG;

        public const double VEL = 0.05;

        private double lastGameTime;
        private float[] xPosInit;
        private float[] yPosInit;
        private float[] xVelInit;
        private float[] yVelInit;

        private IEnumerable<KeyValuePair<uint, Item>> items;

        public Stealth()
        {
            _graphics = new GraphicsDeviceManager(this);
            _graphics.PreparingDeviceSettings += (sender, e) =>
            {
                e.GraphicsDeviceInformation.PresentationParameters.PresentationInterval = PresentInterval.Immediate;
            };
            IsFixedTimeStep = true;
            TargetElapsedTime = TimeSpan.FromSeconds(0.0001);


            Content.RootDirectory = "Content";
            IsMouseVisible = true;
        }

        [DllImport("SDL2.dll", CallingConvention = CallingConvention.Cdecl)]
        public static extern void SDL_MaximizeWindow(IntPtr window);
        protected override void Initialize()
        {
            // TODO: Add your initialization logic here
            _graphics.PreferredBackBufferWidth = GraphicsAdapter.DefaultAdapter.CurrentDisplayMode.Width;
            _graphics.PreferredBackBufferHeight = GraphicsAdapter.DefaultAdapter.CurrentDisplayMode.Height;
            Window.AllowUserResizing = true;
            //_graphics.IsFullScreen = true;
            Window.Position = new Point(0, 0);
            SDL_MaximizeWindow(Window.Handle);
            _graphics.ApplyChanges();

            lastGameTime = 0;

            RNG = new Random();

            InitializeMaps();
            Dither.InitDither();

            State = new State();

            State.Player.Room = (int)MapList.bedroom;
            State.Player.X = (sbyte)(Maps[State.Player.Room].Width / 2);

            // Initialize graphics
            Assets.Ceilings.Load(Content, "Ceilings");
            Assets.Floors.Load(Content, "Floors");
            Assets.Walls.Load(Content, "Walls");
            Assets.Players.Load(Content, "Players");
            Assets.Items.Load(Content, "Items");

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

            items = State.GetItemsInRoom();

            base.Initialize();
        }

        protected override void LoadContent()
        {
            _spriteBatch = new SpriteBatch(GraphicsDevice);

            // TODO: use this.Content to load your game content here
        }

        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            // TODO: Add your update logic here
            byte[,] collision = Maps[State.Player.Room].Collision;
            State.Player.Crouch(Keyboard.GetState().IsKeyDown(Keys.LeftControl), collision);
            State.Player.Run(Keyboard.GetState().IsKeyDown(Keys.LeftShift));
            if (Keyboard.GetState().IsKeyDown(Keys.A))
                State.Player.Move(Animation.left, collision);
            if (Keyboard.GetState().IsKeyDown(Keys.W))
                State.Player.Move(Animation.up, collision);
            if (Keyboard.GetState().IsKeyDown(Keys.D))
                State.Player.Move(Animation.right, collision);
            if (Keyboard.GetState().IsKeyDown(Keys.S))
                State.Player.Move(Animation.down, collision);
            if (Keyboard.GetState().IsKeyDown(Keys.E))
                PickUp();
            if (Keyboard.GetState().IsKeyDown(Keys.Q))
                PutDown();

            State.Player.Update(gameTime.ElapsedGameTime.TotalSeconds);

            xCam = State.Player.Xfine + 0.5;

            if (xCam < Maps[State.Player.Room].CameraXMin)
                xCam = Maps[State.Player.Room].CameraXMin;
            if (xCam > Maps[State.Player.Room].CameraXMax)
                xCam = Maps[State.Player.Room].CameraXMax;

            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.Black);

            short[] screen = new short[SCREEN_HEIGHT * SCREEN_WIDTH];
            double[] depth = Enumerable.Repeat(double.MaxValue, SCREEN_HEIGHT * SCREEN_WIDTH).ToArray();

            //// Declare vars
            //double xPos;
            //double yPos;
            //double xVel;
            //double yVel;

            Light[] lights = new Light[]
                {
                    Light.CreateIsotropic(new Vector3(4.5f, 2.5f, 0.5f), 25),
                    Light.CreateIsotropic(new Vector3(3f,   2f,   3.5f), 1),
                    Light.CreateIsotropic(new Vector3(6f,   2f,   3.5f), 1),
                    Light.CreateIsotropic(new Vector3(3.5f, 0f,   3.5f), 1),
                    Light.CreateIsotropic(new Vector3(5.5f, 0f,   3.5f), 1),
                    Light.CreateIsotropic(new Vector3(4.5f, 3f,   3.5f), 1),
                };
            //Light light = Light.CreateCardioid(new Vector3(4.5f, 2.5f, 0.5f), Vector3.Backward, 25);

            // Render Walls
            Parallel.ForEach(Enumerable.Range(0, SCREEN_WIDTH).ToArray(), x =>
            //for (int x = 0; x < SCREEN_WIDTH; x++)
            {
                float xPos = xPosInit[x];
                float yPos = yPosInit[x];
                float xVel = xVelInit[x];
                float yVel = yVelInit[x];
                xPos += (float)(xCam - CAMERA_WIDTH * 0.5);

                int xPrev = (int)Math.Floor(xPos);

                while (xPos > 0 && xPos < Maps[State.Player.Room].Width && yPos < Maps[State.Player.Room].Height && Maps[State.Player.Room].Walls[(int)Math.Floor(yPos), (int)Math.Floor(xPos)] < 0)
                {
                    xPrev = (int)Math.Floor(xPos);

                    xPos += xVel;
                    yPos += yVel;
                }

                int wall = 0;
                if (xPos >= 0 && xPos < Maps[State.Player.Room].Width && yPos >= 0 && yPos < Maps[State.Player.Room].Height)
                {
                    wall = Maps[State.Player.Room].Walls[(int)yPos, (int)xPos];
                }

                bool orientation = xPrev == Math.Floor(xPos);

                if (orientation)
                    yPos = (float)Math.Round(yPos);
                else
                    xPos = (float)Math.Round(xPos);



                int height = (int)(SCREEN_HEIGHT * CAMERA_DISTANCE / (CAMERA_DISTANCE + yPos));

                // Shortlist sprites
                List<KeyValuePair<uint, Item>> shortItems = new List<KeyValuePair<uint, Item>>();
                foreach (KeyValuePair<uint, Item> kvp in items)
                {
                    uint key = kvp.Key;
                    sbyte itemX = (sbyte)(key & 0xFF);
                    sbyte itemY = (sbyte)((key >> 8) & 0xFF);
                    Item item = kvp.Value;
                    short i = (short)Math.Floor(item.Sprite.Width * (((((double)CAMERA_WIDTH * x * INVERSE_SCREEN_WIDTH) - (CAMERA_WIDTH * 0.5)) * (CAMERA_DISTANCE + itemY) * INVERSE_CAMERA_DISTANCE) + (CAMERA_WIDTH * 0.5 - itemX + xCam - CAMERA_WIDTH * 0.5)));
                    if (i >= 0 && i < item.Sprite.Width)
                        shortItems.Add(kvp);
                }

                // Render play space
                for (int y = 0; y < SCREEN_HEIGHT; y++)
                {
                    int screenIdx = x + y * SCREEN_WIDTH;

                    // Render floors
                    if (y > (SCREEN_HEIGHT + height) * 0.5)
                    {
                        float z = (float)((float)y * INVERSE_SCREEN_HEIGHT - 0.5);
                        float yFloor = (float)(0.5 * CAMERA_DISTANCE / z - CAMERA_DISTANCE);
                        float xFloor = (float)(((x + 0.5) * INVERSE_SCREEN_WIDTH - 0.5) * CAMERA_WIDTH * (CAMERA_DISTANCE + yFloor) * INVERSE_CAMERA_DISTANCE + xCam);
                        short iFloor = (short)Math.Floor(xFloor);
                        short jFloor = (short)Math.Floor(yFloor);
                        short i = (short)(Assets.Floors[Maps[State.Player.Room].Floors[jFloor, iFloor]].Width * (xFloor - Math.Floor(xFloor)));
                        short j = (short)(Assets.Floors[Maps[State.Player.Room].Floors[jFloor, iFloor]].Height * (1 - yFloor + Math.Floor(yFloor)) - 1);
                        if (yFloor < depth[screenIdx])
                        {
                            Vector3[] rays = lights.Select(l => l.Intensity(new Vector3(xFloor, yFloor, 4))).ToArray();
                            rays = rays.Select(ray => new Vector3(ray.X, ray.Y, ray.Z)).ToArray();
                            screen[screenIdx] = Assets.Floors[Maps[State.Player.Room].Floors[jFloor, iFloor]].GetPixel(i, j, rays);
                            depth[screenIdx] = yFloor;
                        }
                    }
                    // Render ceilings
                    else if (y < (SCREEN_HEIGHT - height) * 0.5)
                    {
                        float z = (float)(0.5 - (float)y * INVERSE_SCREEN_HEIGHT);
                        float yCeiling = (float)(0.5 * CAMERA_DISTANCE / z - CAMERA_DISTANCE);
                        float xCeiling = (float)(((x + 0.5) * INVERSE_SCREEN_WIDTH - 0.5) * CAMERA_WIDTH * (CAMERA_DISTANCE + yCeiling) * INVERSE_CAMERA_DISTANCE + xCam);
                        short iCeiling = (short)Math.Floor(xCeiling);
                        short jCeiling = (short)Math.Floor(yCeiling);
                        short iFine = (short)(Assets.Ceilings[Maps[State.Player.Room].Ceilings[jCeiling, iCeiling]].Width * (xCeiling - Math.Floor(xCeiling)));
                        short jFine = (short)(Assets.Ceilings[Maps[State.Player.Room].Ceilings[jCeiling, iCeiling]].Height * (yCeiling - Math.Floor(yCeiling)));
                        if (yCeiling < depth[screenIdx])
                        {
                            Vector3[] rays = lights.Select(l => l.Intensity(new Vector3(xCeiling, yCeiling, 0))).ToArray();
                            rays = rays.Select(ray => new Vector3(ray.X, -ray.Y, -ray.Z)).ToArray();
                            screen[screenIdx] = Assets.Ceilings[Maps[State.Player.Room].Ceilings[jCeiling, iCeiling]].GetPixel(iFine, jFine, rays);
                            depth[screenIdx] = yCeiling;
                        }
                    }
                    // Render Walls
                    else
                    {
                        float zPos = (float)(4 * (y - (SCREEN_HEIGHT - height) * 0.5) / height);
                        Vector3[] rays = lights.Select(l => l.Intensity(new Vector3(xPos, yPos, zPos))).ToArray();

                        short j = (short)(Assets.Walls[wall].Height * (y - (SCREEN_HEIGHT - height) * 0.5) / height);
                        short i = orientation ? (short)(Assets.Walls[wall].Width * (xPos - Math.Floor(xPos))) : (short)(Assets.Walls[wall].Width * ((xVel < 0) ? (yPos - Math.Floor(yPos)) : (1 - yPos + Math.Floor(yPos))));
                        j = Math.Max(Math.Min(j, (short)(Assets.Walls[wall].Height - 1)), (short)0);
                        if (yPos < depth[screenIdx])
                        {
                            rays = orientation ? rays.Select(ray => new Vector3(ray.X, ray.Z, ray.Y)).ToArray() : ((xVel < 0) ? rays.Select(ray => new Vector3(ray.Y, ray.Z, -ray.X)).ToArray() : rays.Select(ray => new Vector3(-ray.Y, ray.Z, ray.X)).ToArray());
                            screen[screenIdx] = Assets.Walls[wall].GetPixel(i, j, rays);
                            depth[screenIdx] = yPos;
                        }
                    }

                    // Render sprites
                    foreach (KeyValuePair<uint, Item> kvp in shortItems)
                    {
                        uint key = kvp.Key;
                        sbyte itemX = (sbyte)(key & 0xFF);
                        sbyte itemY = (sbyte)((key >> 8) & 0xFF);
                        if (itemY - 0.1 > depth[screenIdx])
                            break;
                        Item item = kvp.Value;
                        short i = (short)Math.Floor(item.Sprite.Width * (((((double)CAMERA_WIDTH * x * INVERSE_SCREEN_WIDTH) - (CAMERA_WIDTH * 0.5)) * (CAMERA_DISTANCE + itemY) * INVERSE_CAMERA_DISTANCE) + (CAMERA_WIDTH * 0.5 - itemX + xCam - CAMERA_WIDTH * 0.5)));
                        short j = (short)(item.Sprite.Height * (((double)y * INVERSE_SCREEN_HEIGHT - 0.5) * (CAMERA_DISTANCE + itemY) * INVERSE_CAMERA_DISTANCE + 0.5));

                        if (i >= 0 && i < item.Sprite.Width && j >= 0 && j < item.Sprite.Height && item.Sprite.GetPixel(i, j) >= 0 && itemY - 0.1 < depth[screenIdx])
                        {
                            float xItem = itemX + (float)i / item.Sprite.Width;
                            float yItem = itemY;
                            float zItem = 4 * (float)j / item.Sprite.Height;
                            Vector3[] rays = lights.Select(l => l.Intensity(new Vector3(xItem, yItem, zItem))).ToArray();
                            rays = rays.Select(ray => new Vector3(ray.X, ray.Z, ray.Y)).ToArray();
                            screen[screenIdx] = item.Sprite.GetPixel(i, j, rays);
                            depth[screenIdx] = itemY - 0.1;
                            break;
                        }
                    }

                    // Render State.Player
                    {
                        short i = (short)Math.Floor(48 + 32 * (((((double)CAMERA_WIDTH * x * INVERSE_SCREEN_WIDTH) - (CAMERA_WIDTH * 0.5)) * (CAMERA_DISTANCE + State.Player.Yfine) * INVERSE_CAMERA_DISTANCE) + (xCam - State.Player.Xfine - 1)));
                        short j = (short)(State.Player.Sprite.Height * (((double)y * INVERSE_SCREEN_HEIGHT - 0.5) * (CAMERA_DISTANCE + State.Player.Yfine) * INVERSE_CAMERA_DISTANCE + 0.5));

                        if (i >= 0 && i < State.Player.Sprite.Width && j >= 0 && j < State.Player.Sprite.Height && State.Player.Sprite.GetPixel(i, j) >= 0 && State.Player.Yfine < depth[screenIdx])
                        {
                            float xPlayer = (float)State.Player.Xfine + (float)i / State.Player.Sprite.Width;
                            float yPlayer = (float)State.Player.Yfine + 0.5f;
                            float zPlayer = 4 * (float)j / State.Player.Sprite.Height;
                            Vector3[] rays = lights.Select(l => l.Intensity(new Vector3(xPlayer, yPlayer, zPlayer))).ToArray();
                            rays = rays.Select(ray => new Vector3(ray.X, ray.Z, ray.Y)).ToArray();
                            screen[screenIdx] = State.Player.Sprite.GetPixel(i, j, rays);
                            depth[screenIdx] = State.Player.Yfine;
                        }
                    }
                }
            });

            // Convert to color
            Color[] colors = new Color[SCREEN_WIDTH * SCREEN_HEIGHT];
            for (int i = 0; i < SCREEN_WIDTH * SCREEN_HEIGHT; i++)
            {
                // Dither
                short dither = Dither.ToDither((short)(screen[i] + RNG.Next(-4, 5) * 0.25), i / SCREEN_WIDTH, i % SCREEN_WIDTH);

                // Bound
                dither = (short)Math.Max(Math.Min((int)dither, 3), 0);

                // Color
                colors[i] = Palettes[(int)Maps[State.Player.Room].PalettesType, dither];
            }

            Texture2D texture = new Texture2D(GraphicsDevice, SCREEN_WIDTH, SCREEN_HEIGHT);
            texture.SetData(colors);

            _spriteBatch.Begin();
            _spriteBatch.Draw(texture, new Rectangle(new Point(0, 0), new Point(Window.ClientBounds.Width, Window.ClientBounds.Height)), Color.White);
            //spriteBatch.DrawString(new SpriteFont(, $"FRAMERATE: {1 / (gameTime.TotalGameTime.TotalSeconds - lastGameTime):N2} FPS", new Vector2(), Color.Red);
            _spriteBatch.End();
            //Debug.WriteLine($"FRAMERATE: {1 / (gameTime.TotalGameTime.TotalSeconds - lastGameTime):N2} FPS");
            lastGameTime = gameTime.TotalGameTime.TotalSeconds;

            base.Draw(gameTime);
        }
    }
}
