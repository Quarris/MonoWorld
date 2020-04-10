using System;
using Microsoft.Xna.Framework;

namespace MonoWorld.Demo {
    public static class Extensions {

        public static Point Abs(this Point point) {
            return new Point(Math.Abs(point.X), Math.Abs(point.Y));
        }

    }
}