namespace DAI.AssetLibrary.Assets.Bases {
    public class Vertex {
        public Vector3 Position;

        public Vector3 Normals;

        public Vector3 Tangents;

        public Vector3 Bitangents;

        public Vector2 TexCoords;

        public int[] BoneIndices;

        public float[] BoneWeights;

        public Vertex() {
            Position = new Vector3();
            Normals = new Vector3();
            Tangents = new Vector3();
            Bitangents = new Vector3();
            TexCoords = new Vector2();
        }
    }
}
