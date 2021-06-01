using System;
using System.Collections.Generic;

using DAI.AssetLibrary.Assets.Bases;
using DAI.ModMaker.Utilities;

using SlimDX;
using SlimDX.Direct3D11;
using SlimDX.DXGI;

namespace DAI.ModMaker.DAIRender {
    public class BaseRenderScene : RenderScene {
        protected VertexShader DefaultVertexShader;

        protected PixelShader DefaultPixelShader;

        protected InputLayout DefaultInputLayout;

        protected VertexShader WireframeVertexShader;

        protected PixelShader WireframePixelShader;

        protected InputLayout WireframeInputLayout;

        protected RasterizerState DefaultRasterizerState;

        protected RasterizerState WireframeRasterizerState;

        protected SamplerState DefaultSamplerState;

        protected BlendState DefaultBlendState;

        protected Material ObjectMat;

        protected Material HighlightMat;

        protected DirectionalLight DirLight;

        protected List<List<RenderMesh>> MeshesToRender;

        protected Camera ViewCamera;

        public List<Mesh> Meshes { get; set; }

        public bool WireframeOverlay { get; set; }

        public BaseRenderScene() {
            Meshes = new List<Mesh>();
            Material material3 = new Material {
                Ambient = new Color4(1f, 0.25f, 0.25f, 0.25f),
                Diffuse = new Color4(1f, 0.75f, 0.75f, 0.75f),
                Specular = new Color4(2f, 0.2f, 0.2f, 0.2f)
            };
            Material material = (ObjectMat = material3);
            material3 = new Material {
                Ambient = new Color4(1f, 0.25f, 0.25f, 0.25f),
                Diffuse = new Color4(1f, 1f, 0.84f, 0.29f),
                Specular = new Color4(2f, 0.2f, 0.2f, 0.2f)
            };
            Material material2 = (HighlightMat = material3);
            DirectionalLight directionalLight = (DirLight = new DirectionalLight {
                Ambient = new Color4(0.2f, 0.2f, 0.2f),
                Diffuse = new Color4(0.5f, 0.5f, 0.5f),
                Specular = new Color4(0.5f, 0.5f, 0.5f),
                Direction = new SlimDX.Vector3(0f, 0f, -1f)
            });
            MeshesToRender = new List<List<RenderMesh>>();
            base.UpdateRender = true;
        }

        public virtual List<RenderMesh> AddMesh(Mesh Mesh) {
            Meshes.Add(Mesh);
            List<RenderMesh> renderMeshes = new List<RenderMesh>();
            for (int i = 0; i < Mesh.LODLevels[0].SubObjects.Count; i++) {
                LODSubObject item = Mesh.LODLevels[0].SubObjects[i];
                if (!(item.SubObjectName != "")) {
                    continue;
                }
                SlimDX.Vector3 zero = SlimDX.Vector3.Zero;
                DataStream dataStream = new DataStream(item.VertexCount * 44, false, true);
                foreach (DAI.AssetLibrary.Assets.Bases.Vertex vertexBuffer in item.MeshBuffer.VertexBuffer) {
                    SlimDX.Vector3 slimDXVector3 = vertexBuffer.Position.ToSlimDXVector3();
                    zero += slimDXVector3;
                    dataStream.Write(new Vertex(slimDXVector3, vertexBuffer.Normals.ToSlimDXVector3(), vertexBuffer.Tangents.ToSlimDXVector3(), vertexBuffer.TexCoords.ToSlimDXVector2()));
                }
                zero /= (float)item.MeshBuffer.VertexBuffer.Count;
                dataStream.Position = 0L;
                float single = 0f;
                foreach (DAI.AssetLibrary.Assets.Bases.Vertex item2 in item.MeshBuffer.VertexBuffer) {
                    float single2 = (item2.Position.ToSlimDXVector3() - zero).LengthSquared();
                    if (!(single2 <= single)) {
                        single = single2;
                    }
                }
                single = (float)Math.Sqrt(single);
                BufferDescription bufferDescription3 = default(BufferDescription);
                bufferDescription3.BindFlags = BindFlags.VertexBuffer;
                bufferDescription3.CpuAccessFlags = CpuAccessFlags.None;
                bufferDescription3.OptionFlags = ResourceOptionFlags.None;
                bufferDescription3.SizeInBytes = 44 * item.VertexCount;
                bufferDescription3.Usage = ResourceUsage.Immutable;
                BufferDescription bufferDescription = bufferDescription3;
                SlimDX.Direct3D11.Buffer buffer = new SlimDX.Direct3D11.Buffer(base.Device, dataStream, bufferDescription);
                DataStream dataStream2 = new DataStream(3 * item.TriangleCount * 2, false, true);
                foreach (FaceElement indexBuffer in item.MeshBuffer.IndexBuffer) {
                    dataStream2.Write((ushort)indexBuffer.V1);
                    dataStream2.Write((ushort)indexBuffer.V2);
                    dataStream2.Write((ushort)indexBuffer.V3);
                }
                dataStream2.Position = 0L;
                bufferDescription3 = default(BufferDescription);
                bufferDescription3.BindFlags = BindFlags.IndexBuffer;
                bufferDescription3.CpuAccessFlags = CpuAccessFlags.None;
                bufferDescription3.OptionFlags = ResourceOptionFlags.None;
                bufferDescription3.SizeInBytes = 2 * item.TriangleCount * 3;
                bufferDescription3.Usage = ResourceUsage.Immutable;
                BufferDescription bufferDescription2 = bufferDescription3;
                SlimDX.Direct3D11.Buffer buffer2 = new SlimDX.Direct3D11.Buffer(base.Device, dataStream2, bufferDescription2);
                RenderMesh renderMesh = new RenderMesh {
                    VertexBuffer = buffer,
                    IndexBuffer = buffer2,
                    NumIndices = item.TriangleCount * 3,
                    TextureSlots = new SlimDX.Vector4(0f, 0f, 0f, 0f),
                    World = Matrix.Identity,
                    Center = zero,
                    Radius = single,
                    MeshIndex = Meshes.Count - 1,
                    BSphere = new BoundingSphere(zero, single)
                };
                renderMeshes.Add(renderMesh);
            }
            MeshesToRender.Add(renderMeshes);
            base.DeviceContext.Flush();
            base.UpdateRender = true;
            return renderMeshes;
        }

        protected void CreateTextureResource(Texture Texture, out Texture2D TextureResource, out ShaderResourceView TextureSRV) {
            if (Texture.Data == null) {
                TextureResource = null;
                TextureSRV = null;
                return;
            }
            DataStream dataStream = new DataStream(Texture.Data.Length, false, true);
            dataStream.WriteRange(Texture.Data);
            dataStream.Position = 0L;
            ShaderResourceViewDescription shaderResourceViewDescription = default(ShaderResourceViewDescription);
            shaderResourceViewDescription.Dimension = ShaderResourceViewDimension.Texture2D;
            shaderResourceViewDescription.MipLevels = Texture.NumSizes;
            shaderResourceViewDescription.MostDetailedMip = 0;
            shaderResourceViewDescription.Format = DAIRenderUtils.GetPixelFormat(Texture.PixelFormat);
            Texture2DDescription texture2DDescription3 = default(Texture2DDescription);
            texture2DDescription3.Width = Texture.Width;
            texture2DDescription3.Height = Texture.Height;
            texture2DDescription3.MipLevels = 1;
            texture2DDescription3.ArraySize = 1;
            texture2DDescription3.Format = DAIRenderUtils.GetPixelFormat(Texture.PixelFormat);
            Texture2DDescription texture2DDescription = texture2DDescription3;
            SampleDescription sampleDescription2 = default(SampleDescription);
            sampleDescription2.Count = 1;
            sampleDescription2.Quality = 0;
            SampleDescription sampleDescription = (texture2DDescription.SampleDescription = sampleDescription2);
            texture2DDescription.Usage = ResourceUsage.Default;
            texture2DDescription.BindFlags = BindFlags.ShaderResource;
            texture2DDescription.CpuAccessFlags = CpuAccessFlags.None;
            texture2DDescription.OptionFlags = ResourceOptionFlags.None;
            Texture2DDescription texture2DDescription2 = texture2DDescription;
            TextureResource = new Texture2D(base.Device, texture2DDescription2, new DataRectangle(DAIRenderUtils.GetTexturePitch(Texture.PixelFormat, Texture.Width), dataStream));
            TextureSRV = new ShaderResourceView(base.Device, TextureResource);
        }

        public override void Dispose() {
            RenderUtils.ReleaseCOM(DefaultVertexShader);
            RenderUtils.ReleaseCOM(DefaultPixelShader);
            RenderUtils.ReleaseCOM(DefaultInputLayout);
            RenderUtils.ReleaseCOM(DefaultRasterizerState);
            RenderUtils.ReleaseCOM(DefaultSamplerState);
            RenderUtils.ReleaseCOM(DefaultBlendState);
            RenderUtils.ReleaseCOM(WireframeVertexShader);
            RenderUtils.ReleaseCOM(WireframePixelShader);
            RenderUtils.ReleaseCOM(WireframeInputLayout);
            RenderUtils.ReleaseCOM(WireframeRasterizerState);
            DisposeMeshes();
        }

        public void DisposeMeshes() {
            for (int i = 0; i < MeshesToRender.Count; i++) {
                for (int j = 0; j < MeshesToRender[i].Count; j++) {
                    RenderUtils.ReleaseCOM(MeshesToRender[i][j].VertexBuffer);
                    RenderUtils.ReleaseCOM(MeshesToRender[i][j].IndexBuffer);
                    RenderUtils.ReleaseCOM(MeshesToRender[i][j].DiffuseTextureResource);
                    RenderUtils.ReleaseCOM(MeshesToRender[i][j].DiffuseTextureSRV);
                    RenderUtils.ReleaseCOM(MeshesToRender[i][j].NormalTextureResource);
                    RenderUtils.ReleaseCOM(MeshesToRender[i][j].NormalTextureSRV);
                }
            }
            MeshesToRender.Clear();
        }

        public override void Initialize(SlimDX.Direct3D11.Device InDevice) {
            base.Device = InDevice;
            RenderUtils.LoadShader(base.Device, "MiniTri.fx", "VS", "PS", out DefaultVertexShader, out DefaultPixelShader, out var shaderSignature);
            RenderUtils.LoadShader(base.Device, "MiniTri.fx", "VS", "PSWireframe", out WireframeVertexShader, out WireframePixelShader, out shaderSignature);
            InputElement[] inputElementArray = new InputElement[4]
            {
                new InputElement("POSITION", 0, Format.R32G32B32_Float, 0, 0),
                new InputElement("NORMAL", 0, Format.R32G32B32_Float, 12, 0),
                new InputElement("TANGENT", 0, Format.R32G32B32_Float, 24, 0),
                new InputElement("TEXCOORD", 0, Format.R32G32_Float, 36, 0)
            };
            DefaultInputLayout = new InputLayout(base.Device, shaderSignature, inputElementArray);
            WireframeInputLayout = new InputLayout(base.Device, shaderSignature, inputElementArray);
            RasterizerStateDescription rasterizerStateDescription2 = default(RasterizerStateDescription);
            rasterizerStateDescription2.FillMode = FillMode.Solid;
            rasterizerStateDescription2.CullMode = CullMode.Back;
            rasterizerStateDescription2.IsFrontCounterclockwise = true;
            rasterizerStateDescription2.DepthBias = 0;
            rasterizerStateDescription2.SlopeScaledDepthBias = 0f;
            rasterizerStateDescription2.DepthBiasClamp = 0f;
            rasterizerStateDescription2.IsDepthClipEnabled = true;
            rasterizerStateDescription2.IsScissorEnabled = false;
            rasterizerStateDescription2.IsMultisampleEnabled = false;
            rasterizerStateDescription2.IsAntialiasedLineEnabled = false;
            RasterizerStateDescription rasterizerStateDescription1 = rasterizerStateDescription2;
            DefaultRasterizerState = RasterizerState.FromDescription(base.Device, rasterizerStateDescription1);
            rasterizerStateDescription1.FillMode = FillMode.Wireframe;
            rasterizerStateDescription1.IsAntialiasedLineEnabled = true;
            WireframeRasterizerState = RasterizerState.FromDescription(base.Device, rasterizerStateDescription1);
            SamplerDescription samplerDescription2 = default(SamplerDescription);
            samplerDescription2.AddressU = TextureAddressMode.Wrap;
            samplerDescription2.AddressV = TextureAddressMode.Wrap;
            samplerDescription2.AddressW = TextureAddressMode.Wrap;
            samplerDescription2.Filter = Filter.Anisotropic;
            samplerDescription2.MaximumAnisotropy = 16;
            SamplerDescription samplerDescription = samplerDescription2;
            DefaultSamplerState = SamplerState.FromDescription(base.Device, samplerDescription);
            BlendStateDescription blendStateDescription2 = default(BlendStateDescription);
            blendStateDescription2.AlphaToCoverageEnable = false;
            blendStateDescription2.IndependentBlendEnable = false;
            BlendStateDescription blendStateDescription = blendStateDescription2;
            blendStateDescription.RenderTargets[0].BlendEnable = true;
            blendStateDescription.RenderTargets[0].SourceBlend = BlendOption.SourceAlpha;
            blendStateDescription.RenderTargets[0].DestinationBlend = BlendOption.InverseSourceAlpha;
            blendStateDescription.RenderTargets[0].BlendOperation = BlendOperation.Add;
            blendStateDescription.RenderTargets[0].SourceBlendAlpha = BlendOption.DestinationAlpha;
            blendStateDescription.RenderTargets[0].DestinationBlendAlpha = BlendOption.One;
            blendStateDescription.RenderTargets[0].BlendOperationAlpha = BlendOperation.Add;
            blendStateDescription.RenderTargets[0].RenderTargetWriteMask = ColorWriteMaskFlags.All;
            DefaultBlendState = BlendState.FromDescription(base.Device, blendStateDescription);
        }

        public override void Reinitialize(int width, int height) {
            base.UpdateRender = true;
        }

        public override void Render(double DeltaTime) {
            if (!base.UpdateRender) {
                return;
            }
            if (Meshes.Count > 0) {
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
                foreach (List<RenderMesh> item in MeshesToRender) {
                    foreach (RenderMesh renderMesh in item) {
                        RenderObject(renderMesh, ViewCamera);
                    }
                }
                if (WireframeOverlay) {
                    base.DeviceContext.Rasterizer.State = WireframeRasterizerState;
                    base.DeviceContext.InputAssembler.InputLayout = WireframeInputLayout;
                    base.DeviceContext.VertexShader.Set(WireframeVertexShader);
                    base.DeviceContext.PixelShader.Set(WireframePixelShader);
                    base.DeviceContext.PixelShader.SetConstantBuffer(buffer, 0);
                    foreach (List<RenderMesh> item2 in MeshesToRender) {
                        foreach (RenderMesh renderMesh2 in item2) {
                            RenderObject(renderMesh2, ViewCamera);
                        }
                    }
                }
                RenderUtils.ReleaseCOM(buffer);
            }
            base.UpdateRender = false;
        }

        public void RenderObject(RenderMesh SubMesh, Camera InCamera) {
            Matrix world = SubMesh.World * InCamera.View * InCamera.Proj;
            Matrix matrix = Matrix.Invert(Matrix.Transpose(SubMesh.World));
            BufferDescription bufferDescription2 = default(BufferDescription);
            bufferDescription2.BindFlags = BindFlags.ConstantBuffer;
            bufferDescription2.CpuAccessFlags = CpuAccessFlags.None;
            bufferDescription2.OptionFlags = ResourceOptionFlags.None;
            bufferDescription2.SizeInBytes = 272;
            bufferDescription2.Usage = ResourceUsage.Default;
            BufferDescription bufferDescription1 = bufferDescription2;
            DataStream dataStream = new DataStream(272L, false, true);
            dataStream.Write(Matrix.Transpose(world));
            dataStream.Write(Matrix.Transpose(matrix));
            dataStream.Write(Matrix.Transpose(SubMesh.World));
            dataStream.Write(SubMesh.IsHighlighted ? HighlightMat : ObjectMat);
            dataStream.Write(SubMesh.TextureSlots);
            dataStream.Position = 0L;
            SlimDX.Direct3D11.Buffer buffer = new SlimDX.Direct3D11.Buffer(base.Device, dataStream, bufferDescription1);
            base.DeviceContext.VertexShader.SetConstantBuffer(buffer, 0);
            base.DeviceContext.PixelShader.SetConstantBuffer(buffer, 1);
            base.DeviceContext.PixelShader.SetShaderResource(SubMesh.DiffuseTextureSRV, 0);
            base.DeviceContext.PixelShader.SetSampler(DefaultSamplerState, 0);
            base.DeviceContext.PixelShader.SetShaderResource(SubMesh.NormalTextureSRV, 1);
            base.DeviceContext.PixelShader.SetSampler(DefaultSamplerState, 1);
            base.DeviceContext.InputAssembler.SetVertexBuffers(0, new VertexBufferBinding(SubMesh.VertexBuffer, 44, 0));
            base.DeviceContext.InputAssembler.SetIndexBuffer(SubMesh.IndexBuffer, Format.R16_UInt, 0);
            base.DeviceContext.OutputMerger.BlendSampleMask = -1;
            base.DeviceContext.OutputMerger.BlendFactor = new Color4(0f, 0f, 0f, 0f);
            base.DeviceContext.DrawIndexed(SubMesh.NumIndices, 0, 0);
            RenderUtils.ReleaseCOM(buffer);
        }

        public override void Update(double DeltaTime) {
        }
    }
}
