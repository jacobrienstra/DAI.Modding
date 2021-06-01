using System.Collections.Generic;

namespace DAI.AssetLibrary.Assets.Bases {
    public class MeshBuffer {
        public List<Vertex> VertexBuffer;

        public List<FaceElement> IndexBuffer;

        public MeshBuffer() {
            VertexBuffer = new List<Vertex>();
            IndexBuffer = new List<FaceElement>();
        }
    }
}
