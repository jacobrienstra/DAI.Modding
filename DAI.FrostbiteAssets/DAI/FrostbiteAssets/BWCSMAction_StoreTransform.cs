namespace DAI.FrostbiteAssets
{
	[DescriptorAlignment(4)]
	public class BWCSMAction_StoreTransform : BWCSMAction
	{
		[FieldOffset(28, 72)]
		public int Slot { get; set; }

		[FieldOffset(32, 80)]
		public ExternalObject<TransformProvider> Transform { get; set; }
	}
}
