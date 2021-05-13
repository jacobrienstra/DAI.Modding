using System.Collections.Generic;

namespace DAI.ModMaker.DAIRender
{
    public class RenderSubLayer
    {
        public string Name;

        public List<RenderMesh> RenderMeshes;

        public bool IsVisible;

        public RenderSubLayer(string InName)
        {
            Name = InName;
            RenderMeshes = new List<RenderMesh>();
            IsVisible = true;
        }

        public void SetVisibility(bool NewVisible)
        {
            IsVisible = NewVisible;
            foreach (RenderMesh renderMesh in RenderMeshes)
            {
                renderMesh.IsVisible = NewVisible;
            }
        }

        public override string ToString()
        {
            return "[" + (IsVisible ? "X" : "") + "] " + Name;
        }
    }
}
