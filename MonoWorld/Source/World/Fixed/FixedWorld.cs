using System.Collections.Generic;
using Microsoft.Xna.Framework;
using MonoWorld.Camera;

namespace MonoWorld.World.Fixed {
    public abstract class FixedWorld : IWorld {
        public Point Size;

        public WorldCamera Camera { get; }
        public Dictionary<string, TileLayer> Layers { get; }
        public TileStorage Tiles { get; }

        public FixedWorld(Point size, WorldCamera camera) {
            this.Size = size;

            this.Camera = camera;
            this.Layers = new Dictionary<string, TileLayer>();
            this.Tiles = new TileStorage(this);

            this["Main"] = new TileLayer("Main", 0);
        }

        public void AddLayer(TileLayer layer) {
            this.Layers[layer.Name] = layer;
            this.Tiles[layer] = new Tile[this.Size.X, this.Size.Y];
        }

        public T GetTile<T>(Point position, string layer = "Main") where T : Tile {
            return (T) this[layer, position.X, position.Y];
        }

        public void AddTile(Tile tile) {
            this[tile.Layer.Name, tile.Position.X, tile.Position.Y] = tile;
        }

        public void RemoveTile(Point position, string layer = "Main") {
            this[layer, position.X, position.Y] = null;
        }

        public void RemoveTile(Tile tile) {
            this.RemoveTile(tile.Position, tile.Layer.Name);
        }

        public Tile this[string key, int x, int y] {
            get => this.Tiles[key, x, y];
            set => this.Tiles[key, x, y] = value;
        }

        public TileLayer this[string key] {
            get => this.Layers[key];
            set => this.Layers[key] = value;
        }
    }
}