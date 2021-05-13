namespace DAI.FrostbiteAssets
{
	[DescriptorAlignment(4)]
	public class RepulsionAccelerationTune : Asset
	{
		[FieldOffset(12, 72)]
		public float initialAcc { get; set; }

		[FieldOffset(16, 76)]
		public float outerCushionAcc { get; set; }

		[FieldOffset(20, 80)]
		public float innerCushionAcc { get; set; }
	}
}
