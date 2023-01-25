using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Diagnostics;

namespace Stealth
{
    public partial class Stealth : Game
    {
        private GraphicsDeviceManager _graphics;
        private SpriteBatch _spriteBatch;

        public const int SCREEN_WIDTH = 320;
        public const int SCREEN_HEIGHT = 180;

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
        private double[] xPosInit;
        private double[] yPosInit;
        private double[] xVelInit;
        private double[] yVelInit;

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

        protected override void Initialize()
        {
            // TODO: Add your initialization logic here
            _graphics.PreferredBackBufferWidth = GraphicsAdapter.DefaultAdapter.CurrentDisplayMode.Width;
            _graphics.PreferredBackBufferHeight = GraphicsAdapter.DefaultAdapter.CurrentDisplayMode.Height;
            //_graphics.IsFullScreen = true;
            _graphics.ApplyChanges();

            lastGameTime = 0;

            RNG = new Random();

            InitializeMaps();

            State = new State();

            State.Player.X = (sbyte)(Maps[State.Player.Room].Width / 2);

            // Initialize graphics
            Assets.Ceiling.Init();
            Assets.Floor.Init();
            Assets.Wall.Init();
            Assets.Player.Init();
            Assets.Item.Init();

            xPosInit = new double[SCREEN_WIDTH];
            yPosInit = new double[SCREEN_WIDTH];
            xVelInit = new double[SCREEN_WIDTH];
            yVelInit = new double[SCREEN_WIDTH];
            for (int x = 0; x < SCREEN_WIDTH; x++)
            {
                xPosInit[x] = (x + 0.5) * ((double)CAMERA_WIDTH) * INVERSE_SCREEN_WIDTH;
                yPosInit[x] = 0;
                double inverseDist = 1 / Math.Sqrt(Math.Pow(xPosInit[x] - CAMERA_WIDTH * 0.5, 2) + Math.Pow(CAMERA_DISTANCE, 2));
                xVelInit[x] = VEL * ((xPosInit[x] - CAMERA_WIDTH * 0.5) * inverseDist);
                yVelInit[x] = VEL * CAMERA_DISTANCE * inverseDist;
            }

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
            State.Player.Crouch(Keyboard.GetState().IsKeyDown(Keys.LeftControl));
            State.Player.Run(Keyboard.GetState().IsKeyDown(Keys.LeftShift));
            if (Keyboard.GetState().IsKeyDown(Keys.A))
                State.Player.Move(Animation.left);
            if (Keyboard.GetState().IsKeyDown(Keys.D))
                State.Player.Move(Animation.right);
            if (Keyboard.GetState().IsKeyDown(Keys.W))
                State.Player.Move(Animation.up);
            if (Keyboard.GetState().IsKeyDown(Keys.S))
                State.Player.Move(Animation.down);

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
            float[] depth = new float[SCREEN_HEIGHT * SCREEN_WIDTH];

            // Declare vars
            double xPos;
            double yPos;
            double xVel;
            double yVel;

            // Render Walls
            for (int x = 0; x < SCREEN_WIDTH; x++)
            {
                xPos = xPosInit[x];
                yPos = yPosInit[x];
                xVel = xVelInit[x];
                yVel = yVelInit[x];
                xPos += xCam - CAMERA_WIDTH * 0.5;

                int xPrev = (int)Math.Floor(xPos);

                while (xPos > 0 && xPos < Maps[State.Player.Room].Width && yPos < Maps[State.Player.Room].Height && Maps[State.Player.Room].Walls[(int)Math.Floor(yPos), (int)Math.Floor(xPos)] < 0)
                {
                    xPrev = (int)Math.Floor(xPos);

                    xPos += xVel;
                    yPos += yVel;
                }

                int wall = 0;
                if (xPos >= 0 && xPos < Maps[State.Player.Room].Width && yPos > 0 && yPos < Maps[State.Player.Room].Height)
                {
                    wall = Maps[State.Player.Room].Walls[(int)yPos, (int)xPos];
                }

                bool orientation = xPrev == Math.Floor(xPos);

                if (orientation)
                    yPos = Math.Round(yPos);
                else
                    xPos = Math.Round(xPos);


                
                int height = (int)(SCREEN_HEIGHT * CAMERA_DISTANCE / (CAMERA_DISTANCE + yPos));

                // Render play space
                for (int y = 0; y < SCREEN_HEIGHT; y++)
                {
                    int screenIdx = x + y * SCREEN_WIDTH;

                    // Render floors
                    if (y > (SCREEN_HEIGHT + height) * 0.5)
                    {
                        double z = (double)y * INVERSE_SCREEN_HEIGHT - 0.5;
                        double yFloor = 0.5 * CAMERA_DISTANCE / z - CAMERA_DISTANCE;
                        double xFloor = ((x + 0.5) * INVERSE_SCREEN_WIDTH - 0.5) * CAMERA_WIDTH * (CAMERA_DISTANCE + yFloor) * INVERSE_CAMERA_DISTANCE + xCam;
                        short iFloor = (short)Math.Floor(xFloor);
                        short jFloor = (short)Math.Floor(yFloor);
                        short i = (short)(Assets.Floor.Sprites[Maps[State.Player.Room].Ceilings[jFloor, iFloor]].Width * (xFloor - Math.Floor(xFloor)));
                        short j = (short)(Assets.Floor.Sprites[Maps[State.Player.Room].Ceilings[jFloor, iFloor]].Height * (yFloor - Math.Floor(yFloor)));
                        if (ToDepth(yFloor) > depth[screenIdx])
                        {
                            screen[screenIdx] = Assets.Floor.Sprites[Maps[State.Player.Room].Ceilings[jFloor, iFloor]].GetPixel(i, j);
                            depth[screenIdx] = ToDepth(yFloor);
                        }
                    }
                    // Render ceilings
                    else if (y < (SCREEN_HEIGHT - height) * 0.5)
                    {
                        double z = (double)0.5 - y * INVERSE_SCREEN_HEIGHT ;
                        double yCeiling = 0.5 * CAMERA_DISTANCE / z - CAMERA_DISTANCE;
                        double xCeiling = ((x + 0.5) * INVERSE_SCREEN_WIDTH - 0.5) * CAMERA_WIDTH * (CAMERA_DISTANCE + yCeiling) * INVERSE_CAMERA_DISTANCE + xCam;
                        short iCeiling = (short)Math.Floor(xCeiling);
                        short jCeiling = (short)Math.Floor(yCeiling);
                        short iFine = (short)(Assets.Ceiling.Sprites[Maps[State.Player.Room].Ceilings[jCeiling, iCeiling]].Width * (xCeiling - Math.Floor(xCeiling)));
                        short jFine = (short)(Assets.Ceiling.Sprites[Maps[State.Player.Room].Ceilings[jCeiling, iCeiling]].Height * (yCeiling - Math.Floor(yCeiling)));
                        if (ToDepth(yCeiling) > depth[screenIdx])
                        {
                            screen[screenIdx] = Assets.Ceiling.Sprites[Maps[State.Player.Room].Ceilings[jCeiling, iCeiling]].GetPixel(iFine, jFine);
                            depth[screenIdx] = ToDepth(yCeiling);
                        }
                    }
                    // Render Walls
                    else
                    {
                        short j = (short)(Assets.Wall.Sprites[wall].Height * (y - (SCREEN_HEIGHT - height) * 0.5) / height);
                        short i = orientation ? (short)(Assets.Wall.Sprites[wall].Width * (xPos - Math.Floor(xPos))) : (short)(Assets.Wall.Sprites[wall].Width * (yPos - Math.Floor(yPos)));
                        j = Math.Max(Math.Min(j, (short)(Assets.Wall.Sprites[wall].Height-1)), (short)0);
                        if (ToDepth(yPos) > depth[screenIdx])
                        {
                            screen[screenIdx] = Assets.Wall.Sprites[wall].GetPixel(i, j);
                            depth[screenIdx] = ToDepth(yPos);
                        }
                    }

                    //// Render sprites
                    //foreach (Sprites sprite in Maps[State.Player.Room].Sprites)
                    //{
                    //    int i = (int)Math.Floor(Assets.Wall.Sprites[wall].Width * (((((double)CAMERA_WIDTH * x * INVERSE_SCREEN_WIDTH) - (CAMERA_WIDTH * 0.5)) * (CAMERA_DISTANCE + sprite.Location.Y) * INVERSE_CAMERA_DISTANCE) + (CAMERA_WIDTH * 0.5 - sprite.Location.X + xCam - CAMERA_WIDTH * 0.5)));
                    //    int j = (int)(Assets.Wall.Sprites[wall].Height * (((double)y * INVERSE_SCREEN_HEIGHT - 0.5) * (CAMERA_DISTANCE + sprite.Location.Y) * INVERSE_CAMERA_DISTANCE + 0.5));

                    //    if (i >= 0 && i < Assets.Wall.Sprites[wall].Width && j >= 0 && j < Assets.Wall.Sprites[wall].Height && sprite.Texture[j, i] >= 0 && ToDepth(sprite.Location.Y - 0.1) > depth[screenIdx])
                    //    {
                    //        screen[screenIdx] = sprite.Texture[j, i];
                    //        depth[screenIdx] = ToDepth(sprite.Location.Y - 0.1);
                    //    }
                    //}

                    // Render State.Player
                    {
                        short i = (short)Math.Floor(Assets.Player.Sprites[State.Player.Frame].Width + 8 * (((((double)CAMERA_WIDTH * x * INVERSE_SCREEN_WIDTH) - (CAMERA_WIDTH * 0.5)) * (CAMERA_DISTANCE + State.Player.Yfine) * INVERSE_CAMERA_DISTANCE) + (CAMERA_WIDTH * 0.5 - State.Player.Xfine + xCam - CAMERA_WIDTH * 0.5)));
                        short j = (short)(Assets.Player.Sprites[State.Player.Frame].Height * (((double)y * INVERSE_SCREEN_HEIGHT - 0.5) * (CAMERA_DISTANCE + State.Player.Yfine) * INVERSE_CAMERA_DISTANCE + 0.5));

                        if (i >= 0 && i < Assets.Player.Sprites[State.Player.Frame].Width && j >= 0 && j < Assets.Player.Sprites[State.Player.Frame].Height && Assets.Player.Sprites[State.Player.Frame].GetPixel(i, j) >= 0 && ToDepth(State.Player.Yfine) > depth[screenIdx])
                        {
                            screen[screenIdx] = Assets.Player.Sprites[State.Player.Frame].GetPixel(i, j);
                            depth[screenIdx] = ToDepth(State.Player.Yfine);
                        }
                    }
                }
            }

            // Convert to color
            Color[] colors = new Color[SCREEN_WIDTH * SCREEN_HEIGHT];
            for (int i = 0; i < SCREEN_WIDTH * SCREEN_HEIGHT; i++)
            {
                // Jitter
                screen[i] = (short)Math.Max(Math.Min(screen[i] + (short)(RNG.Next(-8, 9) * 0.125), 3), 0);

                colors[i] = Palettes[(int)Maps[State.Player.Room].PalettesType, screen[i]];
            }

            Texture2D texture = new Texture2D(GraphicsDevice, SCREEN_WIDTH, SCREEN_HEIGHT);
            texture.SetData(colors);

            SpriteBatch spriteBatch = new SpriteBatch(GraphicsDevice);
            spriteBatch.Begin();
            spriteBatch.Draw(texture, new Rectangle(new Point(0, 0), new Point(_graphics.PreferredBackBufferWidth, _graphics.PreferredBackBufferHeight)), Color.White);
            //spriteBatch.DrawString(new SpriteFont(, $"FRAMERATE: {1 / (gameTime.TotalGameTime.TotalSeconds - lastGameTime):N2} FPS", new Vector2(), Color.Red);
            spriteBatch.End();
            lastGameTime = gameTime.TotalGameTime.TotalSeconds;

            base.Draw(gameTime);
        }

        private float ToDepth(double depth)
        {
            return (float)Math.Exp(-depth);
        }
    }
}
