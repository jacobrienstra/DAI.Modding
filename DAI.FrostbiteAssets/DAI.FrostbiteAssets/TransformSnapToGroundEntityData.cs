using DAI.FrostbiteAssets.Enums;

namespace DAI.FrostbiteAssets
{
	[DescriptorAlignment(16)]
	public class TransformSnapToGroundEntityData : EntityData
	{
		[FieldOffset(16, 96)]
		public LinearTransform In { get; set; }

		[FieldOffset(80, 160)]
		public Realm Realm { get; set; }

		[FieldOffset(84, 164)]
		public float DistanceToGround { get; set; }

		[FieldOffset(88, 168)]
		public float RayCastLength { get; set; }

		[FieldOffset(92, 172)]
		public float RayCastUpOffset { get; set; }

		[FieldOffset(96, 176)]
		public bool AlignWithGroundNormal { get; set; }

		[FieldOffset(97, 177)]
		public bool IgnoreWater { get; set; }
	}
}
