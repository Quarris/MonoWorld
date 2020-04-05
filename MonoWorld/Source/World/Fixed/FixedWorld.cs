using System.Collections.Generic;
using System.Linq;
using Microsoft.Xna.Framework;
using MonoWorld.Camera;
using MonoWorld.Exceptions;
using MonoWorld.Tiles;

namespace MonoWorld.World {
    public abstract class FixedWorld : IWorld {
        public Point Size;
        private readonly Tile[,] tiles;
        private readonly WorldCamera camera;

        public FixedWorld(int width, int height, WorldCamera camera) {
            this.Size = new Point(width, height);
            this.tiles = new Tile[width, height];
            this.camera = camera;
        }

        public T GetTile<T>(Point position) where T : Tile {
            try {
                return (T) this.tiles[position.X, position.Y];
            } catch {
                throw new WorldException($"Illegal Get Tile at {position}");
            }
        }

        public List<T> AllTiles<T>() where T : Tile {
            return this.tiles.Cast<T>().Where(tile => tile != null).ToList();
        }

        public virtual void SetTile(Tile tile) {
            try {
                this.tiles[tile.Position.X, tile.Position.Y] = tile;
            } catch {
                throw new WorldException($"Illegal Set Tile at {tile.Position}");
            }
        }

        public virtual void RemoveTile(Point position) {
            try {
                this.tiles[position.X, position.Y] = null;
            } catch {
                throw new WorldException($"Illegal Remove Tile at {position}");
            }
        }

        public virtual void RemoveTile(Tile tile) {
            this.RemoveTile(tile.Position);
        }

        public WorldCamera GetCamera() {
            return this.camera;
        }

        public virtual void Clear() {
            for (int y = 0; y < this.Size.Y; y++) {
                for (int x = 0; x < this.Size.X; x++) {
                    this.tiles[x, y] = null;
                }
            }
        }
    }
}