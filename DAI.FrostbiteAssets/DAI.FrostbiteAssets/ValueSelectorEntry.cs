namespace DAI.FrostbiteAssets
{
	[DescriptorAlignment(4)]
	public class ValueSelectorEntry : AudioGraphNodePortGroup
	{
		[FieldOffset(8, 24)]
		public AudioGraphNodePort Input { get; set; }

		[FieldOffset(16, 56)]
		public float CaseValue { get; set; }
	}
}
