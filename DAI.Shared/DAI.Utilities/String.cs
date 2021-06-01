using System;
using System.Collections.Generic;
using System.Text;

namespace DAI.Utilities {
    class String {

        public static byte[] DQWordToBytes(DQWord Value) {
            byte[] bytes = BitConverter.GetBytes(Value.Value1);
            byte[] bytes2 = BitConverter.GetBytes(Value.Value2);
            List<byte> list = new List<byte>();
            list.AddRange(bytes);
            list.AddRange(bytes2);
            return list.ToArray();
        }
    }
}
