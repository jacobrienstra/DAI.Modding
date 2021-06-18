using System;
using System.Collections.Generic;
using System.Drawing;
using System.Threading;
using System.Windows.Forms;

using DAI.AssetLibrary;
using DAI.AssetLibrary.Assets.Bases;
using DAI.AssetLibrary.Assets.References;
using DAI.FrostbiteAssets;
using DAI.Mod.Maker.Utilities;
using DAI.Utilities;

using SlimDX;
using SlimDX.Direct3D11;
using SlimDX.DXGI;

namespace DAI.Mod.Maker.DAIRender {
    public class LevelRenderScene : BaseRenderScene {
        private VertexShader GridVertexShader;

        private PixelShader GridPixelShader;

        private InputLayout GridInputLayout;

        private RasterizerState GridRasterizerState;

        public SlimDX.Direct3D11.Buffer GridVertexBuffer;

        public SlimDX.Direct3D11.Buffer GridIndexBuffer;

        private Matrix World;

        private int GridWidth;

        private int GridHeight;

        private float MaxViewDistance;

        private bool IsLoadingTextures;

        private Thread TextureLoadingThread;

        private SlimDX.Vector2 LastMousePosition;

        private Octree SceneOctree;

        private Dictionary<uint, List<RenderMesh>> LoadedMeshes;

        private Dictionary<uint, ShaderResourceView> LoadedTextures;

        public List<RenderLayer> Layers;

        private RenderLayer CurrentLayer;

        private RenderSubLayer CurrentSubLayer;

        public bool HasFocus;

        public FirstPersonCamera Camera { get; set; }

        public LevelRenderScene() {
            GridWidth = 32;
            GridHeight = 32;
            Camera = new FirstPersonCamera {
                Position = new SlimDX.Vector3(0f, -2f, -15f)
            };
            ViewCamera = Camera;
            HasFocus = false;
            SceneOctree = new Octree();
            LoadedMeshes = new Dictionary<uint, List<RenderMesh>>();
            LoadedTextures = new Dictionary<uint, ShaderResourceView>();
            Layers = new List<RenderLayer>();
            MaxViewDistance = 1000f;
            RenderLayer renderLayer = new RenderLayer("Uncategorized");
            Layers.Add(renderLayer);
            CurrentLayer = renderLayer;
            CurrentSubLayer = new RenderSubLayer("Uncategorized");
            CurrentLayer.SubLayers.Add(CurrentSubLayer);
        }

        public void AddMesh(Mesh Mesh, Matrix ObjectMatrix) {
            if (TextureLoadingThread == null) {
                IsLoadingTextures = true;
                TextureLoadingThread = new Thread(LoadTexturesAsync);
            }
            Matrix matrix = Matrix.Scaling(1f, -1f, 1f);
            if (LoadedMeshes.ContainsKey(Mesh.MeshNameHash)) {
                using (List<RenderMesh>.Enumerator enumerator = LoadedMeshes[Mesh.MeshNameHash].GetEnumerator()) {
                    while (enumerator.MoveNext()) {
                        RenderMesh renderMesh = new RenderMesh(enumerator.Current) {
                            World = ObjectMatrix * matrix
                        };
                        renderMesh.BSphere.Center = SlimDX.Vector3.TransformCoordinate(renderMesh.BSphere.Center, renderMesh.World);
                        SceneOctree.AddMesh(renderMesh);
                        renderMesh.IsVisible = CurrentLayer.IsVisible;
                        CurrentSubLayer.RenderMeshes.Add(renderMesh);
                    }
                }
            } else {
                List<RenderMesh> renderMeshes = AddMesh(Mesh);
                foreach (RenderMesh objectMatrix in renderMeshes) {
                    objectMatrix.World = ObjectMatrix * matrix;
                    objectMatrix.BSphere.Center = SlimDX.Vector3.TransformCoordinate(objectMatrix.BSphere.Center, objectMatrix.World);
                    SceneOctree.AddMesh(objectMatrix);
                    objectMatrix.IsVisible = CurrentLayer.IsVisible;
                    CurrentSubLayer.RenderMeshes.Add(objectMatrix);
                }
                LoadedMeshes.Add(Mesh.MeshNameHash, renderMeshes);
            }
            base.UpdateRender = true;
        }

        public void ClearScene() {
            SceneOctree = new Octree();
            LoadedMeshes.Clear();
            DisposeMeshes();
            foreach (ShaderResourceView value in LoadedTextures.Values) {
                RenderUtils.ReleaseCOM(value);
            }
            LoadedTextures.Clear();
            Layers.Clear();
            CurrentLayer = new RenderLayer("Uncategorized");
            Layers.Add(CurrentLayer);
            CurrentSubLayer = new RenderSubLayer("Uncategorized");
            CurrentLayer.SubLayers.Add(CurrentSubLayer);
        }

        public void CreateAndSetLayer(string LayerName) {
            RenderLayer renderLayer = (CurrentLayer = new RenderLayer(LayerName));
            Layers.Add(renderLayer);
        }

        public void CreateAndSetSubLayer(string LayerName) {
            RenderSubLayer renderSubLayer = new RenderSubLayer(LayerName);
            CurrentLayer.SubLayers.Add(renderSubLayer);
            CurrentSubLayer = renderSubLayer;
        }

        public override void Dispose() {
            IsLoadingTextures = false;
            RenderUtils.ReleaseCOM(GridVertexShader);
            RenderUtils.ReleaseCOM(GridPixelShader);
            RenderUtils.ReleaseCOM(GridInputLayout);
            RenderUtils.ReleaseCOM(GridRasterizerState);
            RenderUtils.ReleaseCOM(GridVertexBuffer);
            RenderUtils.ReleaseCOM(GridIndexBuffer);
            base.Dispose();
        }

        public void FinializeLevelLoad() {
            IsLoadingTextures = false;
            TextureLoadingThread = null;
        }

        private Texture GetTexture(EbxRef Asset) {
            if (Asset != null && Asset.AssetType == "TextureAsset") {
                AssetContainer container = EbxBase.FromEbx(Asset).GetContainer();
                if (container.IsValid()) {
                    long resource = ((TextureAsset)container.RootObject).Resource;
                    if (resource != 0L) {
                        return Texture.FromRes(Library.GetResByResRid(resource));
                    }
                }
            }
            return null;
        }

        public override void Initialize(SlimDX.Direct3D11.Device InDevice) {
            base.Initialize(InDevice);
            int gridWidth = (GridWidth + 1) * (GridHeight + 1);
            int num = GridWidth * GridHeight * 6;
            RenderUtils.LoadShader(base.Device, "Grid.fx", "VS", "PS", out GridVertexShader, out GridPixelShader, out var shaderSignature);
            InputElement[] inputElement = new InputElement[1]
            {
                new InputElement("POSITION", 0, Format.R32G32B32_Float, 0, 0)
            };
            GridInputLayout = new InputLayout(base.Device, shaderSignature, inputElement);
            DataStream dataStream = new DataStream(gridWidth * 12, false, true);
            int num2 = 2;
            float single = 0f - (float)(GridWidth * num2) / 2f;
            float gridHeight = (float)(GridHeight * num2) / 2f;
            for (int i = 0; i < GridHeight + 1; i++) {
                for (int j = 0; j < GridWidth + 1; j++) {
                    dataStream.Write(new SlimDX.Vector3(single + (float)(j * num2), 0f, gridHeight - (float)(i * num2)));
                }
            }
            dataStream.Position = 0L;
            BufferDescription bufferDescription3 = default(BufferDescription);
            bufferDescription3.BindFlags = BindFlags.VertexBuffer;
            bufferDescription3.CpuAccessFlags = CpuAccessFlags.None;
            bufferDescription3.OptionFlags = ResourceOptionFlags.None;
            bufferDescription3.SizeInBytes = gridWidth * 12;
            bufferDescription3.Usage = ResourceUsage.Immutable;
            BufferDescription bufferDescription = bufferDescription3;
            GridVertexBuffer = new SlimDX.Direct3D11.Buffer(base.Device, dataStream, bufferDescription);
            DataStream dataStream2 = new DataStream(num * 2, false, true);
            for (int k = 0; k < GridHeight; k++) {
                for (int l = 0; l < GridWidth; l++) {
                    short gridWidth2 = (short)(l + k * (GridWidth + 1));
                    short gridWidth3 = (short)(l + 1 + k * (GridWidth + 1));
                    short num3 = (short)(l + 1 + (k + 1) * (GridWidth + 1));
                    short gridWidth4 = (short)(l + (k + 1) * (GridWidth + 1));
                    dataStream2.Write(gridWidth2);
                    dataStream2.Write(gridWidth3);
                    dataStream2.Write(gridWidth4);
                    dataStream2.Write(gridWidth3);
                    dataStream2.Write(num3);
                    dataStream2.Write(gridWidth4);
                }
            }
            dataStream2.Position = 0L;
            bufferDescription3 = default(BufferDescription);
            bufferDescription3.BindFlags = BindFlags.IndexBuffer;
            bufferDescription3.CpuAccessFlags = CpuAccessFlags.None;
            bufferDescription3.OptionFlags = ResourceOptionFlags.None;
            bufferDescription3.SizeInBytes = num * 2;
            bufferDescription3.Usage = ResourceUsage.Immutable;
            BufferDescription bufferDescription2 = bufferDescription3;
            GridIndexBuffer = new SlimDX.Direct3D11.Buffer(base.Device, dataStream2, bufferDescription2);
            RasterizerStateDescription rasterizerStateDescription2 = default(RasterizerStateDescription);
            rasterizerStateDescription2.FillMode = FillMode.Wireframe;
            rasterizerStateDescription2.CullMode = CullMode.None;
            rasterizerStateDescription2.IsFrontCounterclockwise = false;
            rasterizerStateDescription2.DepthBias = 0;
            rasterizerStateDescription2.SlopeScaledDepthBias = 0f;
            rasterizerStateDescription2.DepthBiasClamp = 0f;
            rasterizerStateDescription2.IsDepthClipEnabled = true;
            rasterizerStateDescription2.IsScissorEnabled = false;
            rasterizerStateDescription2.IsMultisampleEnabled = false;
            rasterizerStateDescription2.IsAntialiasedLineEnabled = false;
            RasterizerStateDescription rasterizerStateDescription = rasterizerStateDescription2;
            GridRasterizerState = RasterizerState.FromDescription(base.Device, rasterizerStateDescription);
        }

        public void LoadTexturesAsync() {
            int item = 0;
            while (IsLoadingTextures || item < MeshesToRender.Count) {
                while (item >= MeshesToRender.Count && IsLoadingTextures) {
                    Thread.Sleep(100);
                }
                if (!IsLoadingTextures && item >= MeshesToRender.Count) {
                    break;
                }
                Mesh dAIMesh = base.Meshes[MeshesToRender[item][0].MeshIndex];
                if (!LoadedMeshes.ContainsKey(dAIMesh.MeshNameHash)) {
                    continue;
                }
                List<MeshVariationDatabaseEntry> meshVariations = new List<MeshVariationDatabaseEntry>(Globals.GetMeshVariations(dAIMesh.MeshNameHash));
                if (meshVariations != null && meshVariations.Count > 0) {
                    MeshVariationDatabaseEntry meshVariationDatabaseEntry = meshVariations[0];
                    for (int i = 0; i < dAIMesh.LODLevels[0].SubObjects.Count; i++) {
                        LODSubObject dAISubObject = dAIMesh.LODLevels[0].SubObjects[i];
                        if (!(dAISubObject.SubObjectName != "")) {
                            continue;
                        }
                        MeshVariationDatabaseMaterial meshVariationDatabaseMaterial = meshVariationDatabaseEntry.Materials[dAISubObject.Unknown03];
                        if (meshVariationDatabaseMaterial.TextureParameters.Count <= 0) {
                            continue;
                        }
                        foreach (TextureShaderParameter textureParameter in meshVariationDatabaseMaterial.TextureParameters) {
                            EbxRef ebx = Library.GetEbxByGuid(textureParameter.Value.Id.FileGuid);
                            if (!textureParameter.ParameterName.Contains("Diffuse")) {
                                if (!textureParameter.ParameterName.Contains("Normal")) {
                                    continue;
                                }
                                Texture texture = GetTexture(ebx);
                                if (texture != null) {
                                    if (LoadedTextures.ContainsKey(texture.NameHash)) {
                                        MeshesToRender[item][i].NormalTextureSRV = LoadedTextures[texture.NameHash];
                                        MeshesToRender[item][i].TextureSlots.Y = 1f;
                                    } else {
                                        CreateTextureResource(texture, out MeshesToRender[item][i].NormalTextureResource, out MeshesToRender[item][i].NormalTextureSRV);
                                        MeshesToRender[item][i].TextureSlots.Y = 1f;
                                        LoadedTextures.Add(texture.NameHash, MeshesToRender[item][i].NormalTextureSRV);
                                    }
                                }
                                continue;
                            }
                            Texture dAITexture = GetTexture(ebx);
                            if (dAITexture != null) {
                                if (LoadedTextures.ContainsKey(dAITexture.NameHash)) {
                                    MeshesToRender[item][i].DiffuseTextureSRV = LoadedTextures[dAITexture.NameHash];
                                    MeshesToRender[item][i].TextureSlots.X = 1f;
                                } else {
                                    CreateTextureResource(dAITexture, out MeshesToRender[item][i].DiffuseTextureResource, out MeshesToRender[item][i].DiffuseTextureSRV);
                                    MeshesToRender[item][i].TextureSlots.X = 1f;
                                    LoadedTextures.Add(dAITexture.NameHash, MeshesToRender[item][i].DiffuseTextureSRV);
                                }
                            }
                        }
                    }
                }
                item++;
            }
        }

        public override void Reinitialize(int width, int height) {
            base.Reinitialize(width, height);
            Camera.SetLens((float)Math.PI / 4f, (float)width / (float)height, 1f, MaxViewDistance);
        }

        public override void Render(double DeltaTime) {
            if (base.UpdateRender) {
                Camera.UpdateViewMatrix();
                World = Matrix.Identity;
                DirLight.Direction = Camera.Look;
                DirLight.Direction.Normalize();
                Matrix world = World * Camera.View * Camera.Proj;
                BufferDescription bufferDescription2 = default(BufferDescription);
                bufferDescription2.BindFlags = BindFlags.ConstantBuffer;
                bufferDescription2.CpuAccessFlags = CpuAccessFlags.None;
                bufferDescription2.OptionFlags = ResourceOptionFlags.None;
                bufferDescription2.SizeInBytes = 64;
                bufferDescription2.Usage = ResourceUsage.Default;
                BufferDescription bufferDescription1 = bufferDescription2;
                DataStream dataStream = new DataStream(272L, false, true);
                dataStream.Write(Matrix.Transpose(world));
                dataStream.Position = 0L;
                SlimDX.Direct3D11.Buffer buffer = new SlimDX.Direct3D11.Buffer(base.Device, dataStream, bufferDescription1);
                base.DeviceContext.InputAssembler.PrimitiveTopology = PrimitiveTopology.TriangleList;
                base.DeviceContext.Rasterizer.State = GridRasterizerState;
                base.DeviceContext.InputAssembler.InputLayout = GridInputLayout;
                base.DeviceContext.VertexShader.Set(GridVertexShader);
                base.DeviceContext.PixelShader.Set(GridPixelShader);
                base.DeviceContext.VertexShader.SetConstantBuffer(buffer, 0);
                base.DeviceContext.InputAssembler.SetVertexBuffers(0, new VertexBufferBinding(GridVertexBuffer, 12, 0));
                base.DeviceContext.InputAssembler.SetIndexBuffer(GridIndexBuffer, Format.R16_UInt, 0);
                int gridWidth = GridWidth * GridHeight * 6;
                base.DeviceContext.DrawIndexed(gridWidth, 0, 0);
                RenderUtils.ReleaseCOM(buffer);
                RenderMeshes(DeltaTime);
                base.UpdateRender = false;
            }
        }

        private void RenderBranch(OctreeBranch Branch, double DeltaTime) {
            foreach (OctreeBranch branch in Branch.Branches) {
                if (Camera.Visible(Branch.BBox)) {
                    RenderBranch(branch, DeltaTime);
                }
            }
            if (Branch.Meshes.Count <= 0) {
                return;
            }
            foreach (RenderMesh mesh in Branch.Meshes) {
                if (Camera.Visible(mesh.BSphere) && !((mesh.Location - Camera.Position).Length() >= MaxViewDistance) && mesh.IsVisible) {
                    RenderObject(mesh, ViewCamera);
                }
            }
        }

        private void RenderMeshes(double DeltaTime) {
            if (base.Meshes.Count <= 0) {
                return;
            }
            BufferDescription bufferDescription2 = default(BufferDescription);
            bufferDescription2.BindFlags = BindFlags.ConstantBuffer;
            bufferDescription2.CpuAccessFlags = CpuAccessFlags.None;
            bufferDescription2.OptionFlags = ResourceOptionFlags.None;
            bufferDescription2.SizeInBytes = 80;
            bufferDescription2.Usage = ResourceUsage.Default;
            BufferDescription bufferDescription1 = bufferDescription2;
            Matrix view = ViewCamera.View;
            DataStream dataStream = new DataStream(80L, false, true);
            dataStream.Write(DirLight);
            dataStream.Write(new SlimDX.Vector3(view.M41, view.M42, view.M43));
            dataStream.Position = 0L;
            SlimDX.Direct3D11.Buffer buffer = new SlimDX.Direct3D11.Buffer(base.Device, dataStream, bufferDescription1);
            base.DeviceContext.InputAssembler.PrimitiveTopology = PrimitiveTopology.TriangleList;
            base.DeviceContext.Rasterizer.State = DefaultRasterizerState;
            base.DeviceContext.InputAssembler.InputLayout = DefaultInputLayout;
            base.DeviceContext.VertexShader.Set(DefaultVertexShader);
            base.DeviceContext.PixelShader.Set(DefaultPixelShader);
            base.DeviceContext.PixelShader.SetConstantBuffer(buffer, 0);
            foreach (OctreeBranch branch in SceneOctree.Branches) {
                if (Camera.Visible(branch.BBox)) {
                    RenderBranch(branch, DeltaTime);
                }
            }
            RenderUtils.ReleaseCOM(buffer);
        }

        public void SetCameraPosition(SlimDX.Vector3 InPos) {
            InPos.Y *= -1f;
            Camera.Position = InPos;
            base.UpdateRender = true;
        }

        public void SetLayerVisibility(int LayerIndex, bool NewVisible) {
            Layers[LayerIndex].SetVisibility(NewVisible);
            base.UpdateRender = true;
        }

        public void SetSubLayerVisibility(int LayerIndex, int SubLayerIndex, bool NewVisible) {
            Layers[LayerIndex].SubLayers[SubLayerIndex].SetVisibility(NewVisible);
            base.UpdateRender = true;
        }

        public override void Update(double DeltaTime) {
            if (HasFocus) {
                float single3 = (Key.IsKeyDown(Keys.LShiftKey) ? 100f : 10f);
                if (Key.IsKeyDown(Keys.W)) {
                    Camera.Walk(single3 * (float)DeltaTime);
                    base.UpdateRender = true;
                }
                if (Key.IsKeyDown(Keys.S)) {
                    Camera.Walk((0f - single3) * (float)DeltaTime);
                    base.UpdateRender = true;
                }
                if (Key.IsKeyDown(Keys.A)) {
                    Camera.Strafe((0f - single3) * (float)DeltaTime);
                    base.UpdateRender = true;
                }
                if (Key.IsKeyDown(Keys.D)) {
                    Camera.Strafe(single3 * (float)DeltaTime);
                    base.UpdateRender = true;
                }
                if (Key.IsKeyDown(Keys.RButton)) {
                    float radians = (0.25f * ((float)Cursor.Position.X - LastMousePosition.X)).ToRadians();
                    float radians2 = (0.25f * ((float)Cursor.Position.Y - LastMousePosition.Y)).ToRadians();
                    float single = ((!(radians > 0.001f)) ? ((radians < -0.001f) ? (-1f) : 0f) : 1f);
                    radians = single;
                    float single2 = ((!(radians2 > 0.001f)) ? ((radians2 < -0.001f) ? (-1f) : 0f) : 1f);
                    radians2 = single2;
                    Camera.Pitch(radians2 * 2.5f * (float)DeltaTime);
                    Camera.Yaw(radians * 2.5f * (float)DeltaTime);
                    base.UpdateRender = true;
                }
            }
            Point position1 = Cursor.Position;
            LastMousePosition.X = position1.X;
            Point point1 = Cursor.Position;
            LastMousePosition.Y = point1.Y;
        }
    }
}
