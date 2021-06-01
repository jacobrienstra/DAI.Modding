using System.Collections.Generic;
using DAI.FrostbiteAssets.Enums;

namespace DAI.FrostbiteAssets
{
	[DescriptorAlignment(4)]
	public class UITreeFlowAsset : DataContainerPolicyAsset
	{
		[FieldOffset(12, 72)]
		public LocalizedStringReference Title { get; set; }

		[FieldOffset(16, 96)]
		public LocalizedStringReference Description { get; set; }

		[FieldOffset(20, 120)]
		public string ItemId { get; set; }

		[FieldOffset(24, 128)]
		public string ParentAssetPath { get; set; }

		[FieldOffset(28, 136)]
		public List<GamePlatform> Platforms { get; set; }

		[FieldOffset(32, 144)]
		public List<ExternalObject<UITreeFlowAsset>> NodeChildren { get; set; }

		[FieldOffset(36, 152)]
		public UITextureAtlasTextureReference AtlasListTexture { get; set; }

		[FieldOffset(56, 192)]
		public TreeFlowMouseSelectionMode ChildListMouseSelectionMode { get; set; }

		[FieldOffset(60, 196)]
		public bool IsLeaf { get; set; }

		public UITreeFlowAsset()
		{
			Platforms = new List<GamePlatform>();
			NodeChildren = new List<ExternalObject<UITreeFlowAsset>>();
		}
	}
}
