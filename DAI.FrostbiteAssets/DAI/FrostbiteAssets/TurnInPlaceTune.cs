namespace DAI.FrostbiteAssets
{
	[DescriptorAlignment(4)]
	public class TurnInPlaceTune : Asset
	{
		[FieldOffset(12, 72)]
		public float whenMovingAngle { get; set; }

		[FieldOffset(16, 76)]
		public float whenStoppedAngle { get; set; }

		[FieldOffset(20, 80)]
		public float speed { get; set; }

		[FieldOffset(24, 84)]
		public bool enableUTurn { get; set; }
	}
}
