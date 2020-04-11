using Microsoft.Xna.Framework;
using MonoWorld.Camera;
using MonoWorld.Exceptions;

namespace MonoWorld.World {
    public interface IWorld {

        T GetTile<T>(Point position) where T : Tile;

        void SetTile(Tile tile);

        void RemoveTile(Point position);

        void RemoveTile(Tile tile);

        WorldCamera GetCamera();
    }
}