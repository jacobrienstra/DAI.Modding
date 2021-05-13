namespace DAI.FrostbiteAssets
{
	[DescriptorAlignment(4)]
	public class CautionTune : Asset
	{
		[FieldOffset(12, 72)]
		public float speedX { get; set; }

		[FieldOffset(16, 76)]
		public float tightTurnDegrees { get; set; }
	}
}
