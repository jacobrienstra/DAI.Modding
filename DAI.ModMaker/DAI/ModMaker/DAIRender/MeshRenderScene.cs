using System;
using System.Collections.Generic;

using DAI.AssetLibrary.Assets.Bases;
using DAI.ModMaker.Utilities;

using SlimDX;
using SlimDX.Direct3D11;

namespace DAI.ModMaker.DAIRender
{
    public class MeshRenderScene : BaseRenderScene
    {
        private RenderMesh HighlightedMesh;

        public OrbitCamera Camera { get; set; }

        public MeshRenderScene()
        {
            Camera = new OrbitCamera();
            ViewCamera = Camera;
        }

        public override List<RenderMesh> AddMesh(Mesh Mesh)
        {
            List<RenderMesh> renderMeshes = base.AddMesh(Mesh);
            GetMeshExtents(out var vector3, out var vector4);
            foreach (RenderMesh item in renderMeshes)
            {
                item.World = Matrix.Translation(-((vector4 + vector3) / 2f));
            }
            return renderMeshes;
        }

        public override void Dispose()
        {
            base.Dispose();
        }

        private void GetMeshExtents(out SlimDX.Vector3 MinExtent, out SlimDX.Vector3 MaxExtent)
        {
            MinExtent = new SlimDX.Vector3(float.MaxValue, float.MaxValue, float.MaxValue);
            MaxExtent = new SlimDX.Vector3(float.MinValue, float.MinValue, float.MinValue);
            foreach (Mesh mesh in base.Meshes)
            {
                SlimDX.Vector3 slimDXVector3 = mesh.MinPosition.ToSlimDXVector3();
                SlimDX.Vector3 vector3 = mesh.MaxPosition.ToSlimDXVector3();
                if (slimDXVector3.X < MinExtent.X)
                {
                    MinExtent.X = slimDXVector3.X;
                }
                if (slimDXVector3.Y < MinExtent.Y)
                {
                    MinExtent.Y = slimDXVector3.Y;
                }
                if (slimDXVector3.Z < MinExtent.Z)
                {
                    MinExtent.Z = slimDXVector3.Z;
                }
                if (vector3.X > MaxExtent.X)
                {
                    MaxExtent.X = vector3.X;
                }
                if (vector3.Y > MaxExtent.Y)
                {
                    MaxExtent.Y = vector3.Y;
                }
                if (!(vector3.Z <= MaxExtent.Z))
                {
                    MaxExtent.Z = vector3.Z;
                }
            }
        }

        public override void Initialize(Device InDevice)
        {
            base.Initialize(InDevice);
        }

        public override void Reinitialize(int width, int height)
        {
            base.Reinitialize(width, height);
            Camera.SetPerspective((float)Math.PI / 4f, (float)width / (float)height, 0.01f, 100f);
        }

        public override void Render(double DeltaTime)
        {
            Matrix view = Camera.View;
            view.Invert();
            SlimDX.Vector3 vector3 = new SlimDX.Vector3(view.M41, view.M42, view.M43);
            SlimDX.Vector3 vector4 = new SlimDX.Vector3(0f, 0f, 0f);
            DirLight.Direction = vector4 - vector3;
            DirLight.Direction.Normalize();
            base.Render(DeltaTime);
        }

        public void SetHighlightedMesh(int MeshIndex, int SubObjectIndex)
        {
            if (HighlightedMesh == MeshesToRender[MeshIndex][SubObjectIndex])
            {
                HighlightedMesh.IsHighlighted = !HighlightedMesh.IsHighlighted;
                return;
            }
            if (HighlightedMesh != null)
            {
                HighlightedMesh.IsHighlighted = false;
            }
            HighlightedMesh = MeshesToRender[MeshIndex][SubObjectIndex];
            HighlightedMesh.IsHighlighted = true;
        }

        public void SetMeshDiffuseTexture(int MeshIndex, int SubObjectIndex, Texture Texture)
        {
            if (SubObjectIndex < MeshesToRender[MeshIndex].Count)
            {
                RenderMesh item = MeshesToRender[MeshIndex][SubObjectIndex];
                if (Texture != null)
                {
                    RenderUtils.ReleaseCOM(item.DiffuseTextureResource);
                    RenderUtils.ReleaseCOM(item.DiffuseTextureSRV);
                    CreateTextureResource(Texture, out item.DiffuseTextureResource, out item.DiffuseTextureSRV);
                    item.TextureSlots.X = 1f;
                }
                else
                {
                    item.TextureSlots.X = 0f;
                }
            }
        }

        public void SetMeshNormalTexture(int MeshIndex, int SubObjectIndex, Texture Texture)
        {
            if (SubObjectIndex < MeshesToRender[MeshIndex].Count)
            {
                RenderMesh item = MeshesToRender[MeshIndex][SubObjectIndex];
                if (Texture != null)
                {
                    RenderUtils.ReleaseCOM(item.NormalTextureResource);
                    RenderUtils.ReleaseCOM(item.NormalTextureSRV);
                    CreateTextureResource(Texture, out item.NormalTextureResource, out item.NormalTextureSRV);
                    item.TextureSlots.Y = 1f;
                }
                else
                {
                    item.TextureSlots.Y = 0f;
                }
            }
        }

        public override void Update(double DeltaTime)
        {
            base.Update(DeltaTime);
            base.UpdateRender = true;
        }
    }
}
