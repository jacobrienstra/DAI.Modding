namespace DAI.FrostbiteAssets
{
	[DescriptorAlignment(4)]
	public class Crossfader2NodeData : AudioGraphNodeData
	{
		[FieldOffset(8, 48)]
		public AudioGraphNodePort Ctrl { get; set; }

		[FieldOffset(16, 80)]
		public AudioGraphNodePort CtrlOut1 { get; set; }

		[FieldOffset(24, 112)]
		public AudioGraphNodePort CtrlOut2 { get; set; }
	}
}
