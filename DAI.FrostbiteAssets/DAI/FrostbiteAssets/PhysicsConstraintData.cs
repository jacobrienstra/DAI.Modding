using DAI.FrostbiteAssets.Enums;

namespace DAI.FrostbiteAssets
{
	[DescriptorAlignment(16)]
	public class PhysicsConstraintData : EntityData
	{
		[FieldOffset(16, 96)]
		public LinearTransform Transform { get; set; }

		[FieldOffset(80, 160)]
		public float BreakThreshold { get; set; }

		[FieldOffset(84, 164)]
		public Realm Realm { get; set; }

		[FieldOffset(88, 168)]
		public bool IsBreakable { get; set; }

		[FieldOffset(89, 169)]
		public bool Stabilized { get; set; }

		[FieldOffset(90, 170)]
		public bool EnableContinuousSimulation { get; set; }
	}
}
