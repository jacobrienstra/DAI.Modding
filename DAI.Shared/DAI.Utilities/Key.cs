using System;
using System.Collections.Generic;
using System.Text;
using System.Security.Cryptography;

namespace DAI.Utilities {
    class Key {

        [DllImport("user32.dll")]
        private static extern short GetAsyncKeyState(Keys vKey);

        public static bool IsKeyDown(Keys key) {
            return (GetAsyncKeyState(key) & 0x8000) != 0;
        }
    }
}
