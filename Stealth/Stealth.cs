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

        public State State;

        public Graphics Graphics;

        public double xCam;

        private double lastGameTime;
        
        private IEnumerable<KeyValuePair<uint, Item>> items;

        private SpriteFont font;

        public Stealth()
        {
            _graphics = new GraphicsDeviceManager(this);
            _graphics.PreparingDeviceSettings += (sender, e) =>
            {
                e.GraphicsDeviceInformation.PresentationParameters.PresentationInterval = PresentInterval.Immediate;
            };
            IsFixedTimeStep = true;
            TargetElapsedTime = TimeSpan.FromSeconds(1.0 / 60);


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

            InitializeMaps();
            Dither.InitDither();

            State = new State();

            State.Player.Room = (int)MapList.bedroom;
            State.Player.X = (sbyte)(Maps[State.Player.Room].Width / 2);
            State.Player.Update(0);

            // Initialize graphics
            Assets.Ceilings.Load(Content, "Ceilings");
            Assets.Floors.Load(Content, "Floors");
            Assets.Walls.Load(Content, "Walls");
            Assets.Players.Load(Content, "Players");
            Assets.Items.Load(Content, "Items");

            font = Content.Load<SpriteFont>("Debug");

            items = State.GetItemsInRoom();

            Graphics = new Graphics();
            Graphics.Prerender(State);

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

            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.Black);

            Light[] lights = new Light[]
                {
                    new IsotropicLight(new Vector3(4.5f, 2.5f, 0.5f), 25 + 0.2f * (float)Math.Cos(0.001 * gameTime.TotalGameTime.TotalMilliseconds) + 0.1f * (float)Math.Cos(0.03 * gameTime.TotalGameTime.TotalMilliseconds)),
                    new IsotropicLight(new Vector3(3f,   2f,   3.5f), 1),
                    new IsotropicLight(new Vector3(6f,   2f,   3.5f), 1),
                    new IsotropicLight(new Vector3(3.5f, 0f,   3.5f), 1),
                    new IsotropicLight(new Vector3(5.5f, 0f,   3.5f), 1),
                    new IsotropicLight(new Vector3(4.5f, 3f,   3.5f), 1),
                };

            Graphics.Prerender(State);

            _spriteBatch.Begin(samplerState: SamplerState.PointClamp);
            _spriteBatch.Draw(Graphics.Render(GraphicsDevice, lights), new Rectangle(new Point(0, 0), new Point(Window.ClientBounds.Width, Window.ClientBounds.Height)), Color.White);
            _spriteBatch.DrawString(font, $"FRAMERATE: {1 / (gameTime.TotalGameTime.TotalSeconds - lastGameTime):N2} FPS", new Vector2(), Color.Red);
            _spriteBatch.End();
            //Debug.WriteLine($"FRAMERATE: {1 / (gameTime.TotalGameTime.TotalSeconds - lastGameTime):N2} FPS");
            lastGameTime = gameTime.TotalGameTime.TotalSeconds;

            base.Draw(gameTime);
        }
    }
}
