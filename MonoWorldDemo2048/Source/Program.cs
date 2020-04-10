using Microsoft.Xna.Framework;
using MLEM.Misc;

namespace MonoWorld.Demo {
    public static class Program {
        public static void Main() {
            TextInputWrapper.Current = new TextInputWrapper.DesktopGl<TextInputEventArgs>((w, c) => w.TextInput += c);
            using (WorldInqDemo game = new WorldInqDemo())
                game.Run();
        }
    }
}