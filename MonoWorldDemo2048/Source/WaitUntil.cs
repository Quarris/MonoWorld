using System;
using Coroutine;

namespace MonoGame {
    public class WaitUntil : IWait {

        private Func<bool> until;

        public WaitUntil(Func<bool> until) {
            this.until = until;
        }

        public WaitType GetWaitType() {
            return WaitType.Tick;
        }

        public bool Tick(double deltaSeconds) {
            return this.until.Invoke();
        }

        public bool OnEvent(Event evt) {
            throw new NotSupportedException();
        }
    }
}