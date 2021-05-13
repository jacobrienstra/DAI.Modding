using System.Collections.Generic;

namespace DAI.ModMaker.DAIRender
{
	public class RenderLayer
	{
		public string Name;

		public List<RenderSubLayer> SubLayers;

		public bool IsVisible;

		public RenderLayer(string InName)
		{
			Name = InName;
			SubLayers = new List<RenderSubLayer>();
			IsVisible = true;
		}

		public void SetVisibility(bool NewVisible)
		{
			IsVisible = NewVisible;
			foreach (RenderSubLayer subLayer in SubLayers)
			{
				subLayer.SetVisibility(NewVisible);
			}
		}

		public override string ToString()
		{
			return "[" + (IsVisible ? "X" : "") + "] " + Name;
		}
	}
}
