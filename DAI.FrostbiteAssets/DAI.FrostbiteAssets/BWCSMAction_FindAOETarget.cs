namespace DAI.FrostbiteAssets
{
	[DescriptorAlignment(16)]
	public class BWCSMAction_FindAOETarget : BWCSMAction_AOETarget
	{
		[FieldOffset(48, 96)]
		public Vec3 StartOffset { get; set; }

		[FieldOffset(64, 112)]
		public float MinDistance { get; set; }

		[FieldOffset(68, 116)]
		public float MaxDistance { get; set; }

		[FieldOffset(72, 120)]
		public bool DetachCamera { get; set; }
	}
}
