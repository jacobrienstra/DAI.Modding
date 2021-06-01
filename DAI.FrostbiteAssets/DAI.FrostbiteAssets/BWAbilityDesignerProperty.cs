namespace DAI.FrostbiteAssets
{
	[DescriptorAlignment(4)]
	public class BWAbilityDesignerProperty : LinkObject
	{
		[FieldOffset(0, 0)]
		public int Property { get; set; }

		[FieldOffset(4, 8)]
		public ExternalObject<FloatProvider> Value { get; set; }
	}
}
