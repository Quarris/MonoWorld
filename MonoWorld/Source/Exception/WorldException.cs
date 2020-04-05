using System;

namespace MonoWorld.Exceptions {
    public class WorldException : Exception {

        public WorldException() {
        }

        public WorldException(string message) : base(message) {
        }
    }
}