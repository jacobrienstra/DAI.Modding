namespace DAI.FrostbiteAssets
{
	[DescriptorAlignment(4)]
	public class MinMaxValueSelectorEntry : AudioGraphNodePortGroup
	{
		[FieldOffset(8, 24)]
		public AudioGraphNodePort Input { get; set; }
	}
}
