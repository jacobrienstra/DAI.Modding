using System;
using Flaxen.SlimDXControlLib;
using SlimDX;
using SlimDX.Direct3D11;

namespace DAI.ModMaker.DAIRender
{
	public class MyRenderEngine : SimpleRenderEngine
	{
		private Color4 ClearColor;

		public RenderScene Scene { get; set; }

		public MyRenderEngine(RenderScene InScene)
		{
			ClearColor = new Color4(0f, 0f, 0f);
			Scene = InScene;
		}

		protected override void DisposeManaged()
		{
			Scene.Dispose();
			RenderUtils.ReleaseCOM(base.SharedTexture);
			base.DisposeManaged();
		}

		public override void Initialize(SlimDXControl control)
		{
			base.Initialize(control);
			Scene.Initialize(base.Device);
		}

		public override void Reinitialize(int width, int height)
		{
			base.Reinitialize(width, height);
			Scene.Reinitialize(width, height);
		}

		public override void Render(double DeltaTime)
		{
			try
			{
				if (base.Device != null)
				{
					Scene.Update(DeltaTime);
					base.DeviceContext.OutputMerger.SetTargets(base.SampleDepthView, base.SampleRenderView);
					base.DeviceContext.Rasterizer.SetViewports(new Viewport(0f, 0f, base.WindowWidth, base.WindowHeight, 0f, 1f));
					if (Scene.UpdateRender)
					{
						base.DeviceContext.ClearDepthStencilView(base.SampleDepthView, DepthStencilClearFlags.Stencil | DepthStencilClearFlags.Depth, 1f, 0);
						base.DeviceContext.ClearRenderTargetView(base.SampleRenderView, ClearColor);
						Scene.Render(DeltaTime);
					}
					base.DeviceContext.Flush();
				}
			}
			catch (Exception)
			{
			}
		}
	}
}
