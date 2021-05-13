using System.Collections.Generic;
using DAI.FrostbiteAssets.Enums;

namespace DAI.FrostbiteAssets
{
	[DescriptorAlignment(4)]
	public class UIPlatformOnlyMarkupAsset : UIStringMarkupAsset
	{
		[FieldOffset(16, 40)]
		public List<GamePlatform> Platforms { get; set; }

		[FieldOffset(20, 48)]
		public bool Not { get; set; }

		public UIPlatformOnlyMarkupAsset()
		{
			Platforms = new List<GamePlatform>();
		}
	}
}
