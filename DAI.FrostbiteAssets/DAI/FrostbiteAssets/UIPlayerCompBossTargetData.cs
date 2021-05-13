namespace DAI.FrostbiteAssets
{
	[DescriptorAlignment(4)]
	public class UIPlayerCompBossTargetData : UIComponentData
	{
		[FieldOffset(32, 136)]
		public float InteractionTargetFullAlphaPercentage { get; set; }

		[FieldOffset(36, 140)]
		public bool UseInteractionRadiusForFullAlpha { get; set; }
	}
}
