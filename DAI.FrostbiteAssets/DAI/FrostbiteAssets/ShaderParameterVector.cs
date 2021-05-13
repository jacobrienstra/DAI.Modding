namespace DAI.FrostbiteAssets
{
	[DescriptorAlignment(16)]
	public class ShaderParameterVector : LinkObject
	{
		[FieldOffset(0, 0)]
		public Vec4 Value { get; set; }

		[FieldOffset(16, 16)]
		public string ParameterName { get; set; }
	}
}
