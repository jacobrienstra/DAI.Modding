using System;
using System.Collections.Generic;
using System.Linq;

namespace DAI.ModManager.Utils {
    public class IndexedMultiMap<TKey, TValue> {
        private Dictionary<TKey, List<Tuple<int, TValue>>> map = new Dictionary<TKey, List<Tuple<int, TValue>>>();

        private int count = 0;

        public int Add(TKey key, TValue value) {
            int result = count;
            List<Tuple<int, TValue>> list3;
            if (!map.ContainsKey(key)) {
                List<Tuple<int, TValue>> list2 = (map[key] = new List<Tuple<int, TValue>>());
                list3 = list2;
            } else {
                list3 = map[key];
            }
            List<Tuple<int, TValue>> list4 = list3;
            list4.Add(new Tuple<int, TValue>(count, value));
            count++;
            return result;
        }

        public int FindIndex(TKey key, Func<TValue, bool> func) {
            if (map.TryGetValue(key, out var value)) {
                Tuple<int, TValue> tuple = value.FirstOrDefault((Tuple<int, TValue> t) => func(t.Item2));
                if (tuple != null) {
                    return tuple.Item1;
                }
            }
            return -1;
        }

        public int FindIndex(Func<TValue, bool> func) {
            return map.SelectMany((KeyValuePair<TKey, List<Tuple<int, TValue>>> kvp) => kvp.Value).FirstOrDefault((Tuple<int, TValue> t) => func(t.Item2))?.Item1 ?? (-1);
        }

        public List<TValue> ToList() {
            return (from t in map.SelectMany((KeyValuePair<TKey, List<Tuple<int, TValue>>> kvp) => kvp.Value)
                    orderby t.Item1
                    select t.Item2).ToList();
        }
    }
}
