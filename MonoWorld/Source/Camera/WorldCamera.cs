using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace MonoWorld.Camera {
    public class WorldCamera {

        // World Position based on the center of the Camera
        public Vector2 Position;

        private float scale = 1;
        public float Scale {
            get {
                float sc = this.scale;
                if (this.ScaleWithScreen) {
                    sc *= Math.Min(this.Viewport.Width / this.InitialScreenSize.X, this.Viewport.Height / this.InitialScreenSize.Y);
                }
                return sc;
            }
            set => this.scale = MathHelper.Clamp(value, this.MinScale, this.MaxScale);
        }

        public readonly Vector2 InitialScreenSize;
        public readonly bool ScaleWithScreen;

        public float MinScale = 0.1f;
        public float MaxScale = float.MaxValue;

        public Matrix TransformMatrix {
            get {
                Vector2 pos = this.Position * new Vector2(0, -1) - this.ScaledViewport / 2;
                return Matrix.CreateScale(this.Scale, this.Scale, 1) * Matrix.CreateTranslation(new Vector3(-pos * this.Scale, 0));
            }
        }

        private readonly GraphicsDevice graphicsDevice;
        public Rectangle Viewport => this.graphicsDevice.Viewport.Bounds;
        public Vector2 ScaledViewport => this.Viewport.Size.ToVector2() / this.Scale;

        public WorldCamera(GraphicsDevice graphicsDevice, bool scaleWithScreen = true) {
            this.graphicsDevice = graphicsDevice;
            this.ScaleWithScreen = scaleWithScreen;
            this.InitialScreenSize = this.Viewport.Size.ToVector2();
        }
    }
}