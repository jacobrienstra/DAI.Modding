namespace DAI.FrostbiteAssets
{
	[DescriptorAlignment(4)]
	public class FloatProvider_FloatInput : FloatProvider
	{
		[FieldOffset(8, 32)]
		public ExternalObject<Dummy> Entity { get; set; }

		[FieldOffset(12, 40)]
		public int Action { get; set; }
	}
}
