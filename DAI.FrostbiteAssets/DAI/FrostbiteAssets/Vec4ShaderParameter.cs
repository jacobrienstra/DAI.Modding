namespace DAI.FrostbiteAssets
{
	[DescriptorAlignment(16)]
	public class Vec4ShaderParameter : ShaderParameter
	{
		[FieldOffset(16, 32)]
		public Vec4 Value { get; set; }
	}
}
