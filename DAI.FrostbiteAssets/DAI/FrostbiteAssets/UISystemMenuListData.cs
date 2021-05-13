using System.Collections.Generic;

namespace DAI.FrostbiteAssets
{
	[DescriptorAlignment(4)]
	public class UISystemMenuListData : LinkObject
	{
		[FieldOffset(0, 0)]
		public LocalizedStringReference DisplayString { get; set; }

		[FieldOffset(4, 24)]
		public LocalizedStringReference Description { get; set; }

		[FieldOffset(8, 48)]
		public string Id { get; set; }

		[FieldOffset(12, 56)]
		public List<HeroMenuItemLockEntry> Locks { get; set; }

		[FieldOffset(16, 64)]
		public bool SinglePlayerOnly { get; set; }

		public UISystemMenuListData()
		{
			Locks = new List<HeroMenuItemLockEntry>();
		}
	}
}
