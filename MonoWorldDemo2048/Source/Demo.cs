using System;
using System.Diagnostics;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using MLEM.Misc;
using MLEM.Startup;
using MonoWorld.Camera;

namespace MonoWorld.Demo {
    public class WorldInqDemo : MlemGame {

        public static WorldInqDemo Inst { get; private set;}

        public Board Board;
        public SpriteFont Font;

        public static Random Random = new Random((int) Stopwatch.GetTimestamp());

        public WorldInqDemo(int windowWidth = 1280, int windowHeight = 720) : base(windowWidth, windowHeight) {
            Inst = this;
        }

        protected override void Initialize() {
            base.Initialize();
            WorldCamera camera = new WorldCamera(this.GraphicsDevice);
            this.Board = new Board(7, camera);
            this.Board.Reset();
        }

        protected override void LoadContent() {
            base.LoadContent();
            this.Font = LoadContent<SpriteFont>("DefaultFont");
        }

        protected override void DoUpdate(GameTime gameTime) {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                this.Exit();

            if (Input.IsKeyPressed(Keys.R)) {
                this.Board.Reset();
            }

            if (Input.IsKeyPressed(Keys.Up)) {
                this.Board.Swipe(gameTime, Direction2.Up);
            }

            if (Input.IsKeyPressed(Keys.Down)) {
                this.Board.Swipe(gameTime, Direction2.Down);
            }

            if (Input.IsKeyPressed(Keys.Left)) {
                this.Board.Swipe(gameTime, Direction2.Left);
            }

            if (Input.IsKeyPressed(Keys.Right)) {
                this.Board.Swipe(gameTime, Direction2.Right);
            }

            base.DoUpdate(gameTime);
        }

        protected override void DoDraw(GameTime gameTime) {
            this.GraphicsDevice.Clear(Color.CornflowerBlue);

            BoardRenderer renderer = new BoardRenderer();

            renderer.Draw(this.SpriteBatch, this.Content, this.Board, new Vector2(Constants.Scale, Constants.Scale));
        }
    }
}