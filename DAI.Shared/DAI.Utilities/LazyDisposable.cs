using System;

namespace DAI.Mod.Manager.Utils {
    public class LazyDisposable<T> : IDisposable where T : IDisposable {
        private Lazy<T> _value;

        public T Value => _value.Value;

        public LazyDisposable(Func<T> factory) {
            _value = new Lazy<T>(factory);
        }

        public void Dispose() {
            if (_value.IsValueCreated) {
                _value.Value.Dispose();
            }
        }
    }
}
