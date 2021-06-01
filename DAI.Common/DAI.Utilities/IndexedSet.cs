using System.Collections.Generic;

namespace DAI.Utilities {
    internal class IndexedSet<T> {
        private Dictionary<T, int> set = new Dictionary<T, int>();

        private int count = 0;

        public IndexedSet() {
        }

        public IndexedSet(IEnumerable<T> values) {
            foreach (T value in values) {
                if (!set.ContainsKey(value)) {
                    Add(value);
                }
            }
        }

        public int Add(T value) {
            int result = count;
            set.Add(value, count);
            count++;
            return result;
        }

        public int IndexOf(T value) {
            if (set.TryGetValue(value, out var value2)) {
                return value2;
            }
            return -1;
        }
    }
}
