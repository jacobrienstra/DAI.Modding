namespace DAI.FrostbiteAssets
{
	[DescriptorAlignment(4)]
	public class BoolKeyframe
	{
		[FieldOffset(0, 0)]
		public float Time { get; set; }

		[FieldOffset(4, 4)]
		public bool Value { get; set; }
	}
}
