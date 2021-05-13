using DAI.FrostbiteAssets.Enums;

namespace DAI.FrostbiteAssets
{
	[DescriptorAlignment(4)]
	public class DilationEntityData : EntityData
	{
		[FieldOffset(16, 96)]
		public Realm Realm { get; set; }

		[FieldOffset(20, 100)]
		public float FadeInTime { get; set; }

		[FieldOffset(24, 104)]
		public float FadeOutTime { get; set; }

		[FieldOffset(28, 108)]
		public DilationPriority Priority { get; set; }

		[FieldOffset(32, 112)]
		public float DilationValue { get; set; }

		[FieldOffset(36, 116)]
		public TimeDeltaType TimeDeltaType { get; set; }

		[FieldOffset(40, 120)]
		public int OverrideID { get; set; }
	}
}
