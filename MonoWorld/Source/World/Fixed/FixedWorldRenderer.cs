using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using MonoWorld.Camera;

namespace MonoWorld.World.Fixed {
    public abstract class FixedWorldRenderer : IWorldRenderer {

        public void Draw(SpriteBatch batch, ContentManager content, IWorld world, Vector2 scale) {
            FixedWorld fixedWorld = (FixedWorld) world;
            WorldCamera camera = fixedWorld.GetCamera();
            batch.Begin(transformMatrix: camera?.TransformMatrix);
            this.DrawBackground(batch, content, fixedWorld, scale);
            for (int y = 0; y < fixedWorld.Size.Y; y++) {
                for (int x = 0; x < fixedWorld.Size.X; x++) {
                    Point point = new Point(x, y);
                    Tile tile = world.GetTile<Tile>(point);
                    this.DrawTile(batch, content, fixedWorld, tile, point.ToVector2() * scale, scale);
                }
            }
            batch.End();
        }

        protected abstract void DrawBackground(SpriteBatch batch, ContentManager content, FixedWorld world, Vector2 scale);

        protected virtual void DrawTile(SpriteBatch batch, ContentManager content, FixedWorld world, Tile tile, Vector2 drawPos, Vector2 scale) {
            tile.Draw(batch, content, drawPos, scale);
        }

    }
}