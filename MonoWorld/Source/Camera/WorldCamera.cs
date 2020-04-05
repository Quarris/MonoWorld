using Microsoft.Xna.Framework;

namespace MonoWorld.Camera {
    public class WorldCamera {

        public Vector2 Position;

        private float scale = 1;
        public float Scale {
            get => this.scale;
            set => MathHelper.Clamp(this.scale, this.MinScale, this.MaxScale);
        }

        public float MinScale = 0;
        public float MaxScale = float.MaxValue;

        public Matrix TransformMatrix => Matrix.CreateTranslation(new Vector3(this.Position, 0)) * Matrix.CreateScale(this.Scale, this.Scale, 1);
    }
}