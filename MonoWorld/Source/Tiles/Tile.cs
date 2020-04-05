using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using MonoWorld.World;

namespace MonoWorld.Tiles {
    public abstract class Tile {

        public static Point InvalidPoint = new Point(int.MaxValue, int.MaxValue);

        public readonly IWorld World;

        private Point position = InvalidPoint;
        public Point Position {
            get => this.position;
            set {
                this.World.RemoveTile(this);
                this.position = value;
                this.World.SetTile(this);
            }
        }

        public Tile(IWorld world) {
            this.World = world;
        }

        public Tile(IWorld world, Point pos) : this(world) {
            this.position = pos;
        }

        public bool IsInvalid() {
            return this.Position == InvalidPoint;
        }

        public abstract void Draw(SpriteBatch batch, ContentManager content, Vector2 drawPos, Vector2 scale);
    }
}