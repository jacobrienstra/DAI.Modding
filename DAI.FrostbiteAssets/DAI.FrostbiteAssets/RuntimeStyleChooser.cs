using System.Collections.Generic;

namespace DAI.FrostbiteAssets
{
	[DescriptorAlignment(4)]
	public class RuntimeStyleChooser : LinkObject
	{
		[FieldOffset(0, 0)]
		public List<RuntimeStyleVec4> RuntimeColorStyle { get; set; }

		[FieldOffset(4, 8)]
		public List<RuntimeStyleVec4> RuntimeChannelStyle { get; set; }

		[FieldOffset(8, 16)]
		public List<RuntimeStyleSlider> RuntimeSliderStyle { get; set; }

		[FieldOffset(12, 24)]
		public List<RuntimeStyleTexture> RuntimeTextureStyle { get; set; }

		[FieldOffset(16, 32)]
		public List<RuntimeStyleShape> RuntimeUniqueShapeStyle { get; set; }

		[FieldOffset(20, 40)]
		public List<RuntimeStyleShape> RuntimeUniversalShapeStyle { get; set; }

		[FieldOffset(24, 48)]
		public List<RuntimeStylePreset> RuntimePresetStyle { get; set; }

		public RuntimeStyleChooser()
		{
			RuntimeColorStyle = new List<RuntimeStyleVec4>();
			RuntimeChannelStyle = new List<RuntimeStyleVec4>();
			RuntimeSliderStyle = new List<RuntimeStyleSlider>();
			RuntimeTextureStyle = new List<RuntimeStyleTexture>();
			RuntimeUniqueShapeStyle = new List<RuntimeStyleShape>();
			RuntimeUniversalShapeStyle = new List<RuntimeStyleShape>();
			RuntimePresetStyle = new List<RuntimeStylePreset>();
		}
	}
}
