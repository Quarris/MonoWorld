using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

namespace MonoWorld.World {
    public abstract class Tile {

        public static Point InvalidPoint = new Point(int.MaxValue, int.MaxValue);

        public readonly IWorld World;

        private TileLayer layer;
        public TileLayer Layer {
            get => this.layer;
            set {
                this.World.RemoveTile(this);
                this.layer = value;
                this.World.AddTile(this);
            }
        }

        private Point position = InvalidPoint;
        public Point Position {
            get => this.position;
            set {
                this.World.RemoveTile(this);
                this.position = value;
                this.World.AddTile(this);
            }
        }

        public Tile(IWorld world, string layer = "Main") {
            this.World = world;
            this.layer = world[layer];
        }

        public Tile(IWorld world, Point pos, string layer = "Main") : this(world, layer) {
            this.position = pos;
        }

        public bool IsInvalid() {
            return this.Position == InvalidPoint;
        }

        public abstract void Draw(SpriteBatch batch, ContentManager content, Vector2 drawPos, Vector2 scale);
    }
}