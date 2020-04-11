using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using MonoGame.Extended;
using MonoWorld.World;
using MonoWorld.World.Fixed;

namespace MonoWorld.Demo {
    public class BoardRenderer : FixedWorldRenderer {

        public const int GridThickness = 3;

        protected override void DrawBackground(SpriteBatch batch, ContentManager content, FixedWorld world, Vector2 scale) {
            Vector2 size = world.Size.ToVector2();
            Vector2 drawSize = size * (scale + new Vector2(GridThickness));
            batch.FillRectangle(-drawSize/2, drawSize, Color.YellowGreen);
            for (int y = 0; y < size.X; y++) {
                for (int x = 0; x < size.Y; x++) {
                    Point pos = new Point(x, y);
                    Vector2 drawPos = pos.ToVector2() * scale + pos.ToVector2() * GridThickness - drawSize/2;
                    batch.DrawRectangle(drawPos, scale + new Vector2(2 * GridThickness), Color.Black, GridThickness);
                }
            }
        }

        protected override void DrawTile(SpriteBatch batch, ContentManager content, FixedWorld world, Tile tile, Vector2 drawPos, Vector2 scale) {
            Vector2 size = world.Size.ToVector2();
            Vector2 drawSize = size * (scale + new Vector2(GridThickness));
            tile?.Draw(batch, content, drawPos + (tile.Position.ToVector2() + Vector2.One) * new Vector2(GridThickness) - drawSize/2, scale);
        }
    }
}