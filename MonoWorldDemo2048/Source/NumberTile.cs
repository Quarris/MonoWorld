using System;
using System.Collections.Generic;
using Coroutine;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using MLEM.Extensions;
using MonoGame.Extended;
using MonoWorld;
using MonoWorld.Tiles;
using MonoWorld.World;

namespace MonoGame {
    public class Number : Tile {
        public Point LastPosition;
        public float Animation;

        public static float MaxAnimation = 0.1f;

        public int Value;

        public Number(IWorld world, Point pos, int value) : base(world, pos) {
            this.LastPosition = pos;
            this.Value = value;
        }

        public override string ToString() {
            return this.Value.ToString();
        }

        public override bool Equals(object obj) {
            return obj is Number number && this.Value == number.Value;
        }

        public override void Draw(SpriteBatch batch, ContentManager content, Vector2 drawPos, Vector2 scale) {
            Vector2 lastDrawPos =
                this.LastPosition.ToVector2() * scale
                + new Vector2(BoardRenderer.GridThickness) * (this.LastPosition.ToVector2() + Vector2.One)
                + (BoardRenderer.ScreenSize - ((Board)this.World).Size.ToVector2() * (scale + new Vector2(BoardRenderer.GridThickness)))/2;
            Vector2 lerped = Vector2.Lerp(lastDrawPos, drawPos, this.Animation / MaxAnimation);
            batch.FillRectangle(lerped, scale, Color.Lerp(Color.Black, Color.White, 1 / (float) Math.Log(this.Value, 2)));
            batch.DrawCenteredString(content.Load<SpriteFont>("DefaultFont"), this.Value.ToString(), lerped + scale / 2f, 0.1f, Color.Black, true, true);
        }

        public IEnumerator<IWait> Animate(GameTime time) {
            this.Animation = 0f;
            while (this.Animation < MaxAnimation) {
                this.Animation += time.GetElapsedSeconds();
                yield return new WaitSeconds(time.GetElapsedSeconds());
            }

            this.LastPosition = this.Position;
            this.Animation = MaxAnimation;

            yield return new WaitSeconds(0);
        }
    }
}