using System;
using DAI.FrostbiteAssets.Enums;

namespace DAI.FrostbiteAssets
{
	[DescriptorAlignment(4)]
	public class BT_CheckStackedItemCount : BTEvalFunc
	{
		[FieldOffset(16, 40)]
		public Guid StackedItemAssetGuid { get; set; }

		[FieldOffset(32, 56)]
		public ECompare Comparator { get; set; }

		[FieldOffset(36, 60)]
		public uint Count { get; set; }
	}
}
