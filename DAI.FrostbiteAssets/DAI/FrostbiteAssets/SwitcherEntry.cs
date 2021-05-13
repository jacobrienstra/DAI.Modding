namespace DAI.FrostbiteAssets
{
	[DescriptorAlignment(4)]
	public class SwitcherEntry : AudioGraphNodePortGroup
	{
		[FieldOffset(8, 24)]
		public AudioGraphNodePort CaseTrigger { get; set; }

		[FieldOffset(16, 56)]
		public float CaseValue { get; set; }
	}
}
