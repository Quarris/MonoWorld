using System.Collections.Generic;
using System.Linq;

namespace MonoWorld.World {
    public class TileStorage : Dictionary<TileLayer, Tile[,]> {
        public readonly IWorld World;

        public TileStorage(IWorld world) {
            this.World = world;
        }

        public IOrderedEnumerable<KeyValuePair<TileLayer, Tile[,]>> Ordered() {
            return this.OrderBy(l => l.Key.Depth);
        }

        public Tile[,] this[string key] => this[this.World[key]];
        public Tile this[string key, int x, int y] {
            get => this[key][x, y];
            set => this[key][x, y] = value;
        }
    }
}