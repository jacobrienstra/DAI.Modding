namespace DAI.FrostbiteAssets
{
	[DescriptorAlignment(16)]
	public class VFXLocationControl
	{
		[FieldOffset(0, 0)]
		public LinearTransform Offset { get; set; }

		[FieldOffset(64, 64)]
		public int Attachment { get; set; }

		[FieldOffset(68, 68)]
		public bool StayAttached { get; set; }

		[FieldOffset(69, 69)]
		public bool PreserveOrientation { get; set; }

		[FieldOffset(70, 70)]
		public bool OffsetFromCharacterForward { get; set; }
	}
}
