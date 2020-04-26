using System.Collections.Generic;
using Microsoft.Xna.Framework;
using MonoWorld.Camera;

namespace MonoWorld.World.Fixed {
    public class FixedWorld : AbstractWorld {
        public Point Size;
        public Dictionary<string, TileLayer> Layers { get; }

        public FixedWorld(Point size, WorldCamera camera) {
            this.Size = size;

            this.Camera = camera;
            this.Layers = new Dictionary<string, TileLayer>();
        }

        public void AddLayer(TileLayer layer) {
            this.Layers.Add(layer.Name, layer);
        }

        public override T GetTile<T>(Point position, string layer = "Main") {
            return (T) this.Layers[layer][position];
        }

        public override void AddTile(Tile tile) {
            this.Layers[tile.Layer.Name][tile.Position] = tile;
        }

        public override void RemoveTile(Point position, string layer = "Main") {
            this.Layers[layer][position] = null;
        }
    }
}