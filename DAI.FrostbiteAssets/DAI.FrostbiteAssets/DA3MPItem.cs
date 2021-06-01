using System.Collections.Generic;

namespace DAI.FrostbiteAssets
{
	[DescriptorAlignment(4)]
	public class DA3MPItem : LinkObject
	{
		[FieldOffset(0, 0)]
		public uint UID { get; set; }

		[FieldOffset(4, 4)]
		public int ItemCount { get; set; }

		[FieldOffset(8, 8)]
		public string UserAssignedName { get; set; }

		[FieldOffset(12, 16)]
		public List<Dummy> AvailableAbilities { get; set; }

		[FieldOffset(16, 24)]
		public List<DA3MPItemStat> Stats { get; set; }

		[FieldOffset(20, 32)]
		public uint RecipeId { get; set; }

		[FieldOffset(24, 36)]
		public int Version { get; set; }

		[FieldOffset(28, 40)]
		public string AssetName { get; set; }

		[FieldOffset(32, 48)]
		public int ItemType { get; set; }

		[FieldOffset(36, 56)]
		public List<DA3MPItemProperty> Properties { get; set; }

		[FieldOffset(40, 64)]
		public List<DA3MPItemSlot> Slots { get; set; }

		[FieldOffset(44, 72)]
		public string IconId { get; set; }

		[FieldOffset(48, 80)]
		public string SmallImageId { get; set; }

		[FieldOffset(52, 88)]
		public string LargeImageId { get; set; }

		[FieldOffset(56, 96)]
		public string ShortDescription { get; set; }

		[FieldOffset(60, 104)]
		public string LongDescription { get; set; }

		[FieldOffset(64, 112)]
		public bool IsNew { get; set; }

		[FieldOffset(65, 113)]
		public bool IsMeltable { get; set; }

		[FieldOffset(66, 114)]
		public bool IsCraftable { get; set; }

		[FieldOffset(67, 115)]
		public bool IsVetted { get; set; }

		public DA3MPItem()
		{
			AvailableAbilities = new List<Dummy>();
			Stats = new List<DA3MPItemStat>();
			Properties = new List<DA3MPItemProperty>();
			Slots = new List<DA3MPItemSlot>();
		}
	}
}
