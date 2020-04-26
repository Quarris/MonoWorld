using System.Collections.Generic;
using Microsoft.Xna.Framework;
using MonoWorld.Camera;
using MonoWorld.Exception;

namespace MonoWorld.World {
    public abstract class AbstractWorld {
        public WorldCamera Camera { get; protected set; }

        public abstract T GetTile<T>(Point position, string layer = "Main") where T : Tile;

        public virtual T TryGetTile<T>(Point point, string layer = "Main") where T : Tile {
            try {
                return (T) this[layer, point];
            } catch (WorldException) {
            }

            return null;
        }

        public abstract void AddTile(Tile tile);

        public abstract void RemoveTile(Point position, string layer = "Main");

        public void RemoveTile(Tile tile) {
            if (tile == null) {
                return;
            }

            this.RemoveTile(tile.Position, tile.Layer.Name);
        }

        public virtual Tile this[string layer, Point point] => this.GetTile<Tile>(point, layer);
    }
}