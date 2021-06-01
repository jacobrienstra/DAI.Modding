namespace DAI.FrostbiteAssets
{
	[DescriptorAlignment(4)]
	public class CharGenPaperdollCameraControls
	{
		[FieldOffset(0, 0)]
		public float MaxAdditionalFov { get; set; }

		[FieldOffset(4, 4)]
		public float FOVInterpolationSpeed { get; set; }

		[FieldOffset(8, 8)]
		public float RotationSpeed { get; set; }

		[FieldOffset(12, 12)]
		public float FOVStep { get; set; }
	}
}
