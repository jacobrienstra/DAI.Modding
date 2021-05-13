namespace DAI.FrostbiteAssets
{
	[DescriptorAlignment(4)]
	public class BWAoeCollisionLine : BWAoeCollisionShape
	{
		[FieldOffset(16, 40)]
		public float LineWidth { get; set; }

		[FieldOffset(20, 44)]
		public float LineHeight { get; set; }

		[FieldOffset(24, 48)]
		public float LineLength { get; set; }
	}
}
