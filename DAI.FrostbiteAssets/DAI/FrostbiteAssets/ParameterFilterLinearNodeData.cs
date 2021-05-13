using DAI.FrostbiteAssets.Enums;

namespace DAI.FrostbiteAssets
{
	[DescriptorAlignment(4)]
	public class ParameterFilterLinearNodeData : AudioGraphNodeData
	{
		[FieldOffset(8, 48)]
		public AudioGraphNodePort In { get; set; }

		[FieldOffset(16, 80)]
		public AudioGraphNodePort Out { get; set; }

		[FieldOffset(24, 112)]
		public AudioGraphNodePort AttackSpeed { get; set; }

		[FieldOffset(32, 144)]
		public AudioGraphNodePort ReleaseSpeed { get; set; }

		[FieldOffset(40, 176)]
		public ParameterFilterLinearNodeVersion Version { get; set; }

		[FieldOffset(44, 180)]
		public float DefaultOutputValue { get; set; }

		[FieldOffset(48, 184)]
		public bool KeepActive { get; set; }
	}
}
