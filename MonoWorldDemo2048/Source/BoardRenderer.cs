using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using MonoGame;
using MonoGame.Extended;
using MonoWorld.Tiles;
using MonoWorld.World;

namespace MonoWorld {
    public class BoardRenderer : FixedWorldRenderer {
        public static Vector2 ScreenSize => new Vector2(WorldInqDemo.Inst.GraphicsDevice.Viewport.Width, WorldInqDemo.Inst.GraphicsDevice.Viewport.Height);

        public const int GridThickness = 3;

        protected override void DrawBackground(SpriteBatch batch, ContentManager content, FixedWorld world, Vector2 scale) {
            Vector2 size = world.Size.ToVector2();
            Vector2 drawSize = size * (scale + new Vector2(GridThickness));
            batch.FillRectangle((ScreenSize - drawSize)/2, drawSize, Color.YellowGreen);
            for (int y = 0; y < size.X; y++) {
                for (int x = 0; x < size.Y; x++) {
                    Point pos = new Point(x, y);
                    Vector2 drawPos = pos.ToVector2() * scale + pos.ToVector2() * GridThickness + (ScreenSize - drawSize)/2;
                    batch.DrawRectangle(drawPos, scale + new Vector2(2 * GridThickness), Color.Black, GridThickness);
                }
            }
        }

        protected override void DrawTile(SpriteBatch batch, ContentManager content, FixedWorld world, Tile tile, Vector2 drawPos, Vector2 scale) {
            Vector2 size = world.Size.ToVector2();
            Vector2 drawSize = size * (scale + new Vector2(GridThickness));
            tile?.Draw(batch, content, drawPos + (tile.Position.ToVector2() + Vector2.One) * new Vector2(GridThickness) + (ScreenSize-drawSize)/2, scale);
        }
    }
}