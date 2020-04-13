using System.Collections.Generic;
using Microsoft.Xna.Framework;
using MonoWorld.Camera;

namespace MonoWorld.World {
    public interface IWorld {
        WorldCamera Camera { get; }
        Dictionary<string, TileLayer> Layers { get; }
        TileStorage Tiles { get; }

        void AddLayer(TileLayer layer);

        T GetTile<T>(Point position, string layer) where T : Tile;
        void AddTile(Tile tile);
        void RemoveTile(Point position, string layer);
        void RemoveTile(Tile tile);
        Tile this[string key, int x, int y] { get; set; }
        TileLayer this[string key] { get; }
    }
}