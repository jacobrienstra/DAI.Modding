using System;
using System.Windows.Forms;
using DAI.AssetLibrary.Assets.Bases;
using SlimDX;
using SlimDX.Direct3D11;
using SlimDX.DXGI;

namespace DAI.ModMaker.DAIRender
{
	public class TextureRenderScene : RenderScene
	{
		private Texture TextureToDraw;

		private VertexShader TextureVertexShader;

		private PixelShader TexturePixelShader;

		private InputLayout TextureInputLayout;

		private SlimDX.Direct3D11.Buffer TextureVertexBuffer;

		private Texture2D TextureResource;

		private ShaderResourceView TextureSRV;

		private BlendState TextureBlendState;

		private SlimDX.Vector4[] ChannelMask;

		private bool AlphaEnabled;

		private bool IsNormalMap;

		private bool IsSharedExponent;

		public TextureRenderScene(Texture InTexture)
		{
			TextureToDraw = InTexture;
			ChannelMask = new SlimDX.Vector4[4]
			{
				new SlimDX.Vector4(1f, 0f, 0f, 0f),
				new SlimDX.Vector4(0f, 1f, 0f, 0f),
				new SlimDX.Vector4(0f, 0f, 1f, 0f),
				new SlimDX.Vector4(0f, 0f, 0f, 0f)
			};
			AlphaEnabled = false;
		}

		public override void Dispose()
		{
			RenderUtils.ReleaseCOM(TextureSRV);
			RenderUtils.ReleaseCOM(TextureResource);
			RenderUtils.ReleaseCOM(TextureVertexShader);
			RenderUtils.ReleaseCOM(TexturePixelShader);
			RenderUtils.ReleaseCOM(TextureInputLayout);
			RenderUtils.ReleaseCOM(TextureVertexBuffer);
			RenderUtils.ReleaseCOM(TextureBlendState);
		}

		public override void Initialize(SlimDX.Direct3D11.Device InDevice)
		{
			try
			{
				base.Device = InDevice;
				if (TextureToDraw != null)
				{
					RenderUtils.LoadShader(base.Device, "Texture.fx", "VS", "PS", out TextureVertexShader, out TexturePixelShader, out var shaderSignature);
					InputElement[] inputElement = new InputElement[2]
					{
						new InputElement("POSITION", 0, Format.R32G32B32_Float, 0, 0),
						new InputElement("TEXCOORD", 0, Format.R32G32_Float, 12, 0)
					};
					TextureInputLayout = new InputLayout(base.Device, shaderSignature, inputElement);
					DataStream dataStream = new DataStream(120L, false, true);
					QuadVertex[] quadVertex = new QuadVertex[6]
					{
						new QuadVertex(new SlimDX.Vector3(-1f, 1f, 0.5f), new SlimDX.Vector2(0f, 0f)),
						new QuadVertex(new SlimDX.Vector3(1f, 1f, 0.5f), new SlimDX.Vector2(1f, 0f)),
						new QuadVertex(new SlimDX.Vector3(1f, -1f, 0.5f), new SlimDX.Vector2(1f, 1f)),
						new QuadVertex(new SlimDX.Vector3(-1f, 1f, 0.5f), new SlimDX.Vector2(0f, 0f)),
						new QuadVertex(new SlimDX.Vector3(1f, -1f, 0.5f), new SlimDX.Vector2(1f, 1f)),
						new QuadVertex(new SlimDX.Vector3(-1f, -1f, 0.5f), new SlimDX.Vector2(0f, 1f))
					};
					dataStream.WriteRange(quadVertex);
					dataStream.Position = 0L;
					BufferDescription bufferDescription2 = default(BufferDescription);
					bufferDescription2.BindFlags = BindFlags.VertexBuffer;
					bufferDescription2.CpuAccessFlags = CpuAccessFlags.None;
					bufferDescription2.OptionFlags = ResourceOptionFlags.None;
					bufferDescription2.SizeInBytes = 120;
					bufferDescription2.Usage = ResourceUsage.Immutable;
					BufferDescription bufferDescription = bufferDescription2;
					TextureVertexBuffer = new SlimDX.Direct3D11.Buffer(base.Device, dataStream, bufferDescription);
					DataStream dataStream2 = new DataStream(TextureToDraw.Data.Length, true, true);
					dataStream2.WriteRange(TextureToDraw.Data);
					dataStream2.Position = 0L;
					ShaderResourceViewDescription shaderResourceViewDescription = default(ShaderResourceViewDescription);
					shaderResourceViewDescription.Dimension = ShaderResourceViewDimension.Texture2D;
					shaderResourceViewDescription.MipLevels = TextureToDraw.NumSizes;
					shaderResourceViewDescription.MostDetailedMip = 0;
					shaderResourceViewDescription.Format = DAIRenderUtils.GetPixelFormat(TextureToDraw.PixelFormat);
					SampleDescription sampleDescription2 = default(SampleDescription);
					sampleDescription2.Count = 1;
					sampleDescription2.Quality = 0;
					SampleDescription sampleDescription = sampleDescription2;
					Texture2DDescription texture2DDescription2 = default(Texture2DDescription);
					texture2DDescription2.Width = TextureToDraw.Width;
					texture2DDescription2.Height = TextureToDraw.Height;
					texture2DDescription2.MipLevels = 1;
					texture2DDescription2.ArraySize = 1;
					texture2DDescription2.Format = DAIRenderUtils.GetPixelFormat(TextureToDraw.PixelFormat);
					texture2DDescription2.SampleDescription = sampleDescription;
					texture2DDescription2.Usage = ResourceUsage.Default;
					texture2DDescription2.BindFlags = BindFlags.ShaderResource;
					texture2DDescription2.CpuAccessFlags = CpuAccessFlags.None;
					texture2DDescription2.OptionFlags = ResourceOptionFlags.None;
					Texture2DDescription texture2DDescription = texture2DDescription2;
					DataRectangle rect = new DataRectangle(DAIRenderUtils.GetTexturePitch(TextureToDraw.PixelFormat, TextureToDraw.Width), dataStream2);
					TextureResource = new Texture2D(base.Device, texture2DDescription, rect);
					TextureSRV = new ShaderResourceView(base.Device, TextureResource);
					BlendStateDescription blendStateDescription2 = default(BlendStateDescription);
					blendStateDescription2.AlphaToCoverageEnable = false;
					blendStateDescription2.IndependentBlendEnable = false;
					BlendStateDescription blendStateDescription = blendStateDescription2;
					blendStateDescription.RenderTargets[0].BlendEnable = true;
					blendStateDescription.RenderTargets[0].SourceBlend = BlendOption.SourceAlpha;
					blendStateDescription.RenderTargets[0].DestinationBlend = BlendOption.InverseSourceAlpha;
					blendStateDescription.RenderTargets[0].BlendOperation = BlendOperation.Add;
					blendStateDescription.RenderTargets[0].SourceBlendAlpha = BlendOption.InverseDestinationAlpha;
					blendStateDescription.RenderTargets[0].DestinationBlendAlpha = BlendOption.One;
					blendStateDescription.RenderTargets[0].BlendOperationAlpha = BlendOperation.Add;
					blendStateDescription.RenderTargets[0].RenderTargetWriteMask = ColorWriteMaskFlags.All;
					TextureBlendState = BlendState.FromDescription(base.Device, blendStateDescription);
					if (TextureToDraw.PixelFormat == TextureFormat.TF_NormalDXN)
					{
						IsNormalMap = true;
					}
					if (TextureToDraw.PixelFormat == TextureFormat.TF_R9G9B9E5F)
					{
						IsSharedExponent = true;
					}
					base.DeviceContext.Flush();
				}
			}
			catch (Exception)
			{
				MessageBox.Show("An error occured while rendering the texture.", "Oopsie", MessageBoxButtons.OK, MessageBoxIcon.Hand);
			}
		}

		public override void Reinitialize(int width, int height)
		{
		}

		public override void Render(double DeltaTime)
		{
			if (TextureToDraw != null)
			{
				BufferDescription bufferDescription2 = default(BufferDescription);
				bufferDescription2.BindFlags = BindFlags.ConstantBuffer;
				bufferDescription2.CpuAccessFlags = CpuAccessFlags.None;
				bufferDescription2.OptionFlags = ResourceOptionFlags.None;
				bufferDescription2.SizeInBytes = 80;
				bufferDescription2.Usage = ResourceUsage.Default;
				BufferDescription bufferDescription1 = bufferDescription2;
				DataStream dataStream = new DataStream(80L, false, true);
				dataStream.Write(ChannelMask[0]);
				dataStream.Write(ChannelMask[1]);
				dataStream.Write(ChannelMask[2]);
				dataStream.Write(ChannelMask[3]);
				dataStream.Write(new SlimDX.Vector4(AlphaEnabled ? 1f : 0f, IsNormalMap ? 1f : 0f, IsSharedExponent ? 1f : 0f, 0f));
				dataStream.Position = 0L;
				SlimDX.Direct3D11.Buffer buffer = new SlimDX.Direct3D11.Buffer(base.Device, dataStream, bufferDescription1);
				base.DeviceContext.VertexShader.Set(TextureVertexShader);
				base.DeviceContext.PixelShader.SetConstantBuffer(buffer, 0);
				base.DeviceContext.PixelShader.Set(TexturePixelShader);
				base.DeviceContext.PixelShader.SetShaderResource(TextureSRV, 0);
				base.DeviceContext.InputAssembler.PrimitiveTopology = PrimitiveTopology.TriangleList;
				base.DeviceContext.InputAssembler.InputLayout = TextureInputLayout;
				base.DeviceContext.InputAssembler.SetVertexBuffers(0, new VertexBufferBinding(TextureVertexBuffer, 20, 0));
				base.DeviceContext.OutputMerger.BlendState = TextureBlendState;
				base.DeviceContext.OutputMerger.BlendSampleMask = -1;
				base.DeviceContext.OutputMerger.BlendFactor = new Color4(0f, 0f, 0f, 0f);
				base.DeviceContext.Draw(6, 0);
				base.UpdateRender = false;
				RenderUtils.ReleaseCOM(buffer);
			}
		}

		public void SetChannelMaskActive(int InIndex, bool InActive)
		{
			ChannelMask[InIndex].X = ((InIndex != 0 || !InActive) ? 0f : 1f);
			ChannelMask[InIndex].Y = ((InIndex != 1 || !InActive) ? 0f : 1f);
			ChannelMask[InIndex].Z = ((InIndex != 2 || !InActive) ? 0f : 1f);
			ChannelMask[InIndex].W = ((InIndex != 3 || !InActive) ? 0f : 1f);
			if (InIndex == 3)
			{
				AlphaEnabled = ChannelMask[InIndex].W == 1f;
			}
		}

		public void SetChannelMaskAllActive(int InIndex)
		{
			for (int i = 0; i < 4; i++)
			{
				ChannelMask[i].X = ((i == InIndex) ? 1f : 0f);
				ChannelMask[i].Y = ((i == InIndex) ? 1f : 0f);
				ChannelMask[i].Z = ((i == InIndex) ? 1f : 0f);
				ChannelMask[i].W = ((i == InIndex) ? 1f : 0f);
			}
			AlphaEnabled = false;
		}

		public override void Update(double DeltaTime)
		{
			base.UpdateRender = true;
		}
	}
}
