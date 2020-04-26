using Microsoft.Xna.Framework;

namespace MonoWorld.World {
    public class TileLayer {

        public readonly string Name;
        public readonly int Depth;

        public readonly Tile[,] Tiles;

        public TileLayer(string name, Point size, int depth) {
            this.Name = name;
            this.Depth = depth;
            this.Tiles = new Tile[size.X, size.Y];
        }

        public Tile this[Point point] {
            get => this.Tiles[point.X, point.Y];
            set => this.Tiles[point.X, point.Y] = value;
        }
    }
}