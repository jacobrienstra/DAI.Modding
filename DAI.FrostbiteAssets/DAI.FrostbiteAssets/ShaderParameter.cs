namespace DAI.FrostbiteAssets
{
	[DescriptorAlignment(4)]
	public class ShaderParameter : DataContainer
	{
		[FieldOffset(8, 24)]
		public string ParameterName { get; set; }
	}
}
