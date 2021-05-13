namespace DAI.FrostbiteAssets
{
	[DescriptorAlignment(4)]
	public class ValueCurveNodeData : AudioGraphNodeData
	{
		[FieldOffset(8, 48)]
		public AudioGraphNodePort Lookup { get; set; }

		[FieldOffset(16, 80)]
		public AudioCurve LookupCurve { get; set; }

		[FieldOffset(24, 96)]
		public AudioGraphNodePort Output { get; set; }
	}
}
