using DAI.FrostbiteAssets.Enums;

namespace DAI.FrostbiteAssets
{
	[DescriptorAlignment(4)]
	public class BWScaleClampData : EntityData
	{
		[FieldOffset(16, 96)]
		public Realm Realm { get; set; }

		[FieldOffset(20, 100)]
		public float In { get; set; }

		[FieldOffset(24, 104)]
		public float InMin { get; set; }

		[FieldOffset(28, 108)]
		public float InMax { get; set; }

		[FieldOffset(32, 112)]
		public float OutMin { get; set; }

		[FieldOffset(36, 116)]
		public float OutMax { get; set; }
	}
}
