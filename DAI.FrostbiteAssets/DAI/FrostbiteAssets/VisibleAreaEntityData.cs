using DAI.FrostbiteAssets.Enums;

namespace DAI.FrostbiteAssets
{
	[DescriptorAlignment(16)]
	public class VisibleAreaEntityData : SpatialEntityData
	{
		[FieldOffset(80, 176)]
		public Realm Realm { get; set; }

		[FieldOffset(84, 180)]
		public float VisualCullScreenArea { get; set; }

		[FieldOffset(88, 184)]
		public uint HideTreshold { get; set; }
	}
}
