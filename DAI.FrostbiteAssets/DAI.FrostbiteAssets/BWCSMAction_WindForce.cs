using DAI.FrostbiteAssets.Enums;

namespace DAI.FrostbiteAssets
{
	[DescriptorAlignment(16)]
	public class BWCSMAction_WindForce : BWCSMAction
	{
		[FieldOffset(28, 72)]
		public Realm Realm { get; set; }

		[FieldOffset(32, 80)]
		public Vec4 WindForceStrengthMultiplier { get; set; }

		[FieldOffset(48, 96)]
		public ExternalObject<LocalWindForceSphereEntityData> WindForceData { get; set; }

		[FieldOffset(52, 104)]
		public ExternalObject<TransformProvider> WindForceTransform { get; set; }

		[FieldOffset(56, 112)]
		public bool UpdateWindForceTransform { get; set; }

		[FieldOffset(57, 113)]
		public bool FlipZ { get; set; }
	}
}
