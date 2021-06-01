namespace DAI.FrostbiteAssets
{
	[DescriptorAlignment(16)]
	public class LocalWindForceConeEntityData : LocalWindForceEntityBaseData
	{
		[FieldOffset(112, 208)]
		public float InnerRadius { get; set; }

		[FieldOffset(116, 212)]
		public float OuterRadius { get; set; }

		[FieldOffset(120, 216)]
		public float ConeInnerAngle { get; set; }

		[FieldOffset(124, 220)]
		public float ConeOuterAngle { get; set; }
	}
}
