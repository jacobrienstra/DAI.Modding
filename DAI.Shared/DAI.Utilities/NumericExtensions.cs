using System;

namespace DAI.Utilities {
    public static class NumericExtensions {
        public static float ToRadians(this float val) {
            return (float)Math.PI / 180f * val;
        }

        public static double ToRadians(this double val) {
            return Math.PI / 180.0 * val;
        }
    }
}
