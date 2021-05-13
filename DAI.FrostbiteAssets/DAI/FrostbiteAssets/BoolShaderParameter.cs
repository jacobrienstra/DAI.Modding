namespace DAI.FrostbiteAssets
{
	[DescriptorAlignment(4)]
	public class BoolShaderParameter : LinkObject
	{
		[FieldOffset(0, 0)]
		public string ParameterName { get; set; }

		[FieldOffset(4, 8)]
		public bool Value { get; set; }
	}
}
