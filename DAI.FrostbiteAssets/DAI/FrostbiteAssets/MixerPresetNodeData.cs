namespace DAI.FrostbiteAssets
{
	[DescriptorAlignment(4)]
	public class MixerPresetNodeData : LinkObject
	{
		[FieldOffset(0, 0)]
		public ExternalObject<Dummy> Node { get; set; }

		[FieldOffset(4, 8)]
		public float Value { get; set; }
	}
}
