namespace DAI.FrostbiteAssets
{
	[DescriptorAlignment(4)]
	public class SpeedModifierData
	{
		[FieldOffset(0, 0)]
		public float ForwardConstant { get; set; }

		[FieldOffset(4, 4)]
		public float BackwardConstant { get; set; }

		[FieldOffset(8, 8)]
		public float LeftConstant { get; set; }

		[FieldOffset(12, 12)]
		public float RightConstant { get; set; }
	}
}
