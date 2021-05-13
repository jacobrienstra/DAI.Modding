namespace DAI.FrostbiteAssets
{
	[DescriptorAlignment(4)]
	public class RagdollBinding : LinkObject
	{
		[FieldOffset(0, 0)]
		public AntRef RagdollOnBack { get; set; }

		[FieldOffset(20, 48)]
		public AntRef RagdollBlend { get; set; }

		[FieldOffset(40, 96)]
		public AntRef RagdollBlendEarly { get; set; }

		[FieldOffset(60, 144)]
		public AntRef RagdollForceBlendDisabled { get; set; }

		[FieldOffset(80, 192)]
		public AntRef RagdollActiveTime { get; set; }

		[FieldOffset(100, 240)]
		public AntRef RagdollFullyBlendedIn { get; set; }
	}
}
