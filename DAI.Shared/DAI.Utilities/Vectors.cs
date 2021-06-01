using DAI.AssetLibrary.Assets.Bases;

namespace DAI.Utilities {
    public class Vectors {
        public static SlimDX.Vector3 ToSlimDXVector3(this Vector3 vec3) {
            return new SlimDX.Vector3(vec3.X, vec3.Y, vec3.Z);
        }

        public static SlimDX.Vector2 ToSlimDXVector2(this Vector2 vec2) {
            return new SlimDX.Vector2(vec2.X, vec2.Y);
        }

        public static SlimDX.Vector4 ToSlimDXVector4(this Vector4 vec4) {
            return new SlimDX.Vector4(vec4.X, vec4.Y, vec4.Z, vec4.W);
        }
    }
}
