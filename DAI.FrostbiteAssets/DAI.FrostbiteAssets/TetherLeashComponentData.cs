namespace DAI.FrostbiteAssets
{
	[DescriptorAlignment(16)]
	public class TetherLeashComponentData : GameComponentData
	{
		[FieldOffset(96, 176)]
		public LinearTransform TetherPointOverride { get; set; }

		[FieldOffset(160, 240)]
		public float LeashLength { get; set; }

		[FieldOffset(164, 244)]
		public bool Enabled { get; set; }

		[FieldOffset(165, 245)]
		public bool UseVolumesOnly { get; set; }

		[FieldOffset(166, 246)]
		public bool ResetPointOnEnterCombat { get; set; }
	}
}
