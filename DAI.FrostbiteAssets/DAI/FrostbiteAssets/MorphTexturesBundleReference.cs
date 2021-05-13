using System.Collections.Generic;

namespace DAI.FrostbiteAssets
{
	[DescriptorAlignment(4)]
	public class MorphTexturesBundleReference : LinkObject
	{
		[FieldOffset(0, 0)]
		public List<MorphTexturesBundleData> TextureBundleData { get; set; }

		public MorphTexturesBundleReference()
		{
			TextureBundleData = new List<MorphTexturesBundleData>();
		}
	}
}
