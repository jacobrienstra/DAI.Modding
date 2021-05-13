namespace DAI.FrostbiteAssets
{
	[DescriptorAlignment(4)]
	public class FloatProvider_AbilityDesignerProperty : FloatProvider
	{
		[FieldOffset(8, 32)]
		public int Property { get; set; }
	}
}
