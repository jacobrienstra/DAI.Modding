using DAI.FrostbiteAssets.Enums;

namespace DAI.FrostbiteAssets
{
	[DescriptorAlignment(16)]
	public class BehaviorZoneEntityData : SpatialEntityData
	{
		[FieldOffset(80, 176)]
		public BehaviorZoneType TypeOfZone { get; set; }

		[FieldOffset(84, 180)]
		public int Category { get; set; }

		[FieldOffset(88, 184)]
		public float Radius { get; set; }

		[FieldOffset(92, 188)]
		public bool Enabled { get; set; }
	}
}
