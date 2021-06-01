namespace DAI.FrostbiteAssets
{
	[DescriptorAlignment(4)]
	public class UIPlayerCompData : UIComponentData
	{
		[FieldOffset(32, 136)]
		public float InteractionTargetFullAlphaPercentage { get; set; }

		[FieldOffset(36, 140)]
		public float BarrierBlendParameter { get; set; }

		[FieldOffset(40, 144)]
		public bool UseInteractionRadiusForFullAlpha { get; set; }
	}
}
