namespace DAI.FrostbiteAssets
{
	[DescriptorAlignment(4)]
	public class ParameterRouterEntry : AudioGraphNodePortGroup
	{
		[FieldOffset(8, 24)]
		public AudioGraphNodePort In { get; set; }

		[FieldOffset(16, 56)]
		public AudioGraphNodePort Out { get; set; }
	}
}
