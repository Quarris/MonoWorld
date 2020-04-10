using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace MonoWorld.Demo {
    public static class Extensions {
        public static Point Abs(this Point point) {
            return new Point(Math.Abs(point.X), Math.Abs(point.Y));
        }

        public static void DrawCenteredString(this SpriteBatch batch, SpriteFont font, string text, Vector2 position, float scale, Color color, bool horizontal = true, bool vertical = false, float addedScale = 0) {
            var size = font.MeasureString(text);
            var center = new Vector2(
                horizontal ? size.X * scale / 2F : 0,
                vertical ? size.Y * scale / 2F : 0);
            batch.DrawString(font, text,
                position + size * scale / 2 - center,
                color, 0, size / 2, scale + addedScale, SpriteEffects.None, 0);
        }
    }
}