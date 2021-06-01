namespace DAI.ModManager.Utils {
    public class Vector {
        public float X;

        public float Y;

        public float Z;

        public Vector(float inX, float inY, float inZ) {
            X = inX;
            Y = inY;
            Z = inZ;
        }

        public Vector() {
            X = (Y = (Z = 0f));
        }

        public static Vector operator *(Vector A, float B) {
            Vector vector = A;
            vector.X *= B;
            vector = A;
            vector.Y *= B;
            vector = A;
            vector.Z *= B;
            return A;
        }
    }
}
