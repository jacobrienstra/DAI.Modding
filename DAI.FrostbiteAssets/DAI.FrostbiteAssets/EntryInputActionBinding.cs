using DAI.FrostbiteAssets.Enums;

namespace DAI.FrostbiteAssets
{
	[DescriptorAlignment(4)]
	public class EntryInputActionBinding
	{
		[FieldOffset(0, 0)]
		public int Action { get; set; }

		[FieldOffset(4, 4)]
		public int Alias { get; set; }

		[FieldOffset(8, 8)]
		public EntryInputActionType ActionType { get; set; }

		[FieldOffset(12, 12)]
		public bool Networked { get; set; }
	}
}
