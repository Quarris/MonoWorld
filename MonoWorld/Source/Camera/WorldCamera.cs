using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace MonoWorld.Camera {
    public class WorldCamera {

        // World Position based on the center of the Camera
        public Vector2 Position = new Vector2(0, 128);

        private float scale = 1;
        public float Scale {
            get => Math.Min(this.Viewport.Width / (float) this.Viewport.Width, this.Viewport.Height / (float) this.Viewport.Height) * this.scale;
            set => this.scale = MathHelper.Clamp(value, this.MinScale, this.MaxScale);
        }

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

        public WorldCamera(GraphicsDevice graphicsDevice) {
            this.graphicsDevice = graphicsDevice;
        }
    }
}