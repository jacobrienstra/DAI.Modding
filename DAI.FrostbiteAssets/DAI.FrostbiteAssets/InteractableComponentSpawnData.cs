using DAI.FrostbiteAssets.Enums;

namespace DAI.FrostbiteAssets
{
	[DescriptorAlignment(4)]
	public class InteractableComponentSpawnData : ExtraSpawnData
	{
		[FieldOffset(8, 24)]
		public BWInteractionType InteractionType { get; set; }

		[FieldOffset(12, 32)]
		public LocalizedStringReference InteractionText { get; set; }

		[FieldOffset(16, 56)]
		public bool Enabled { get; set; }
	}
}
