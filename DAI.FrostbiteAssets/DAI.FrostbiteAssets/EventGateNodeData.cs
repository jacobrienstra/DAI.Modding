namespace DAI.FrostbiteAssets
{
	[DescriptorAlignment(4)]
	public class EventGateNodeData : AudioGraphNodeData
	{
		[FieldOffset(8, 48)]
		public AudioGraphNodePort In { get; set; }

		[FieldOffset(16, 80)]
		public AudioGraphNodePort Out { get; set; }

		[FieldOffset(24, 112)]
		public AudioGraphNodePort CoolDownTime { get; set; }

		[FieldOffset(32, 144)]
		public AudioGraphNodePort Enable { get; set; }
	}
}
