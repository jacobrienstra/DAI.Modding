namespace DAI.FrostbiteAssets
{
	[DescriptorAlignment(16)]
	public class GameInteractionEntityData : InteractionEntityData
	{
		[FieldOffset(112, 208)]
		public float DelayBetweenUses { get; set; }

		[FieldOffset(116, 212)]
		public float HoldToInteractTime { get; set; }

		[FieldOffset(120, 216)]
		public float InteractionVerticalOffset { get; set; }
	}
}
