using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

namespace MonoWorld.World {
    public interface IWorldRenderer {

        // Implement draw order where the dev can choose the order to draw the tiles in
        // RightDown, RightUp, LeftDown, LeftUp
        void Draw(SpriteBatch batch, ContentManager content, IWorld world, Vector2 scale);

    }
}