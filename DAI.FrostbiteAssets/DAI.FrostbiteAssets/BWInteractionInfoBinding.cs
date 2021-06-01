namespace DAI.FrostbiteAssets
{
	[DescriptorAlignment(4)]
	public class BWInteractionInfoBinding : UIDataBinding
	{
		[FieldOffset(8, 24)]
		public UIDataSourceInfo HasInteractionTarget { get; set; }

		[FieldOffset(24, 56)]
		public UIDataSourceInfo InteractionTargetName { get; set; }

		[FieldOffset(40, 88)]
		public UIDataSourceInfo InteractionTargetAlpha { get; set; }

		[FieldOffset(56, 120)]
		public UIDataSourceInfo InteractionVisible { get; set; }
	}
}
